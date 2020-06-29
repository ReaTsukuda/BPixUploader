using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPixUploader
{
  public partial class ConfigDialog : Form
  {
    public ConfigDialog()
    {
      var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      InitializeComponent();
      if (config.AppSettings.Settings.AllKeys.Contains("BpixUsername")) { usernameInput.Text = config.AppSettings.Settings["BpixUsername"].Value; }
      if (config.AppSettings.Settings.AllKeys.Contains("BpixPassword")) { passwordInput.Text = config.AppSettings.Settings["BpixPassword"].Value; }
      if (config.AppSettings.Settings.AllKeys.Contains("BpixGalleryId"))
      {
        galleryIdInput.Value = int.Parse(config.AppSettings.Settings["BpixGalleryId"].Value);
      }
    }

    private void OkClicked(object sender, EventArgs e)
    {
      var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      if (config.AppSettings.Settings.AllKeys.Contains("BpixUsername")) { config.AppSettings.Settings["BpixUsername"].Value = usernameInput.Text; }
      else { config.AppSettings.Settings.Add("BpixUsername", usernameInput.Text); }
      if (config.AppSettings.Settings.AllKeys.Contains("BpixPassword")) { config.AppSettings.Settings["BpixPassword"].Value = passwordInput.Text; }
      else { config.AppSettings.Settings.Add("BpixPassword", passwordInput.Text); }
      if (config.AppSettings.Settings.AllKeys.Contains("BpixGalleryId")) { config.AppSettings.Settings["BpixGalleryId"].Value = galleryIdInput.Value.ToString(); }
      else { config.AppSettings.Settings.Add("BpixGalleryId", galleryIdInput.Value.ToString()); }
      config.Save();
    }
  }
}
