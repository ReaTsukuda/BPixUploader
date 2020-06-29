using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPixUploader
{
  public partial class MainForm : Form
  {
    private static readonly HttpClient client = new HttpClient();

    // Only files with these extensions are allowed to be uploaded.
    private static readonly string[] AllowedFileExtensions = new string[] { ".png", ".jpg" };

    private List<string> QueuedFiles = new List<string>();

    private static readonly string EndpointUrl = "https://lpbeach.co.uk/piwigo/ws.php";
    private static readonly string Format = "format=json";
    private static readonly string MethodFormat = "&method={0}";
    private static readonly string LoginMethod = "pwg.session.login";
    private static readonly string GetStatusMethod = "pwg.session.getStatus";
    private static readonly string UploadMethod = "pwg.images.upload";

    private string BpixUsername
    {
      get
      {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        if (config.AppSettings.Settings.AllKeys.Contains("BpixUsername")) { return config.AppSettings.Settings["BpixUsername"].Value; }
        else { return null; }
      }
    }

    private string BpixPassword
    {
      get
      {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        if (config.AppSettings.Settings.AllKeys.Contains("BpixPassword")) { return config.AppSettings.Settings["BpixPassword"].Value; }
        else { return null; }
      }
    }

    private int BpixGalleryId
    {
      get
      {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        if (config.AppSettings.Settings.AllKeys.Contains("BpixGalleryId")) { return int.Parse(config.AppSettings.Settings["BpixGalleryId"].Value); }
        else { return -1; }
      }
    }

    public MainForm()
    {
      InitializeComponent();
      AllowDrop = true;
      DragEnter += DragEnterHandler;
      DragDrop += DragDropHandler;
      fileList.AutoGenerateColumns = false;

      client.BaseAddress = new Uri(EndpointUrl);
    }

    private void DragEnterHandler(object sender, DragEventArgs args)
    {
      args.Effect = DragDropEffects.Copy;
    }

    private void DragDropHandler(object sender, DragEventArgs args)
    { 
      // If files were dropped in, we've got the go-ahead to cast the data to a list of strings.
      if (args.Data.GetDataPresent(DataFormats.FileDrop))
      {
        var filenames = args.Data.GetData(DataFormats.FileDrop) as string[];
        // Filter the filenames down to only allowed image formats.
        QueuedFiles.AddRange(filenames.Where(filename => AllowedFileExtensions.Contains(Path.GetExtension(filename).ToLower())));
        // Make sure we're not adding duplicate files.
        QueuedFiles = QueuedFiles.Distinct().ToList();
        // Clear out the current GUI rows, and then set it to what we have in QueuedFiles.
        fileList.Rows.Clear();
        int rowCounter = 0;
        foreach (var filename in QueuedFiles)
        {
          fileList.Rows.Add(new DataGridViewRow());
          fileList[0, rowCounter].Value = Path.GetFileName(filename);
          rowCounter += 1;
        }
      }
    }

    private void UploadButtonClicked(object sender, EventArgs args)
    {
      if (BpixUsername != null
        && BpixPassword != null
        && BpixGalleryId != -1)
      {
        new Thread(UploadLogic).Start();
      }
      else
      {
        MessageBox.Show("Your settings haven't been set up properly. Please click on Options and make sure you have entered your BPix username, password, and gallery ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private async void UploadLogic()
    {
      // Login.
      statusText.Text = "Logging in...";
      var formdata = new MultipartFormDataContent
      {
        { new StringContent(BpixUsername), "username" },
        { new StringContent(BpixPassword), "password" }
      };
      var uriBuilder = new UriBuilder(EndpointUrl)
      {
        Query = Format
        + string.Format(MethodFormat, LoginMethod)
      };
      var result = await client.PostAsync(uriBuilder.Uri, formdata);
      var body = await result.Content.ReadAsStringAsync();
      var successful = (JsonConvert.DeserializeObject(body) as JObject)["stat"].Value<string>() == "ok";
      if (successful == false)
      {
        MessageBox.Show("Couldn't login to BPix. Check your username/password.",
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }
      // GetStatus.
      formdata = new MultipartFormDataContent();
      uriBuilder.Query = Format
        + string.Format(MethodFormat, GetStatusMethod);
      result = await client.PostAsync(uriBuilder.Uri, formdata);
      body = await result.Content.ReadAsStringAsync();
      var token = (JsonConvert.DeserializeObject(body) as JObject)["result"]["pwg_token"].Value<string>();
      // Upload.
      statusText.Text = "Uploading...";
      var urls = new string[QueuedFiles.Count];
      var countdown = new CountdownEvent(QueuedFiles.Count);
      for (int imageIndex = 0; imageIndex < QueuedFiles.Count; imageIndex += 1)
      {
        ThreadPool.QueueUserWorkItem(UploadThread, new object[] {
          token,
          QueuedFiles[imageIndex],
          urls,
          imageIndex,
          countdown
        });
      }
      countdown.Wait();
      statusText.Text = string.Empty;
      new FinishDialog(urls).ShowDialog();
    }

    private async void UploadThread(object state)
    {
      var stateArray = state as object[];
      var token = (string)stateArray[0];
      var filename = (string)stateArray[1];
      var urls = (string[])stateArray[2];
      var threadId = (int)stateArray[3];
      var countdown = (CountdownEvent)stateArray[4];
      var formdata = new MultipartFormDataContent()
      {
        { new StringContent(token), "pwg_token" },
        { new StreamContent(new FileStream(filename, FileMode.Open)), "file", Path.GetFileName(filename) },
        { new StringContent(BpixGalleryId.ToString()), "category" },
        { new StringContent(Path.GetFileNameWithoutExtension(filename)), "name" }
      };
      var uriBuilder = new UriBuilder(EndpointUrl)
      {
        Query = Format
        + string.Format(MethodFormat, UploadMethod)
      };
      fileList[1, threadId].Value = "Uploading...";
      var result = await client.PostAsync(uriBuilder.Uri, formdata);
      var body = await result.Content.ReadAsStringAsync();
      var initialUrl = (JsonConvert.DeserializeObject(body) as JObject)["result"]["src"].Value<string>();
      // Now, we make a GET request to the initial URL, so we can get the direct link to the file.
      var getResult = await client.GetAsync(initialUrl);
      urls[threadId] = getResult.RequestMessage.RequestUri.AbsoluteUri;
      fileList[1, threadId].Value = "Done!";
      countdown.Signal();
    }

    private void OptionsClicked(object sender, EventArgs args)
    {
      new ConfigDialog().ShowDialog();
    }
  }
}
