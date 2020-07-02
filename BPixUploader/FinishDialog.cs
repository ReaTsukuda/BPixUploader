using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPixUploader
{
  public partial class FinishDialog : Form
  {
    private Dictionary<string, string> Urls;

    public FinishDialog()
    {
      InitializeComponent();
    }

    public FinishDialog(Dictionary<string, string> uploadedUrls)
    {
      InitializeComponent();
      Urls = uploadedUrls;
      AddRemoveTags(null, null);
      tagsCheckbox.CheckedChanged += AddRemoveTags;
    }

    private void OkButtonClicked(object sender, EventArgs args)
    {
      this.Close();
    }

    private void AddRemoveTags(object sender, EventArgs args)
    {
      if (tagsCheckbox.Checked == true)
      {
        urls.Text = string.Empty;
        foreach (var url in Urls)
        {
          urls.Text += string.Format("{0},[img]{1}[/img]\n", url.Key, url.Value);
        }
      }
      else
      {
        foreach (var url in Urls)
        {
          urls.Text += string.Format("{0},{1}\n", url.Key, url.Value);
        }
      }
    }
  }
}
