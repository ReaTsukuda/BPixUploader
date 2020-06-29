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
    private string[] Urls;

    public FinishDialog()
    {
      InitializeComponent();
    }

    public FinishDialog(string[] uploadedUrls)
    {
      InitializeComponent();
      Urls = uploadedUrls;
      urls.Text = string.Join("\n", Urls);
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
          urls.Text += string.Format("[img]{0}[/img]\n", url);
        }
      }
      else
      {
        urls.Text = string.Join("\n", Urls);
      }
    }
  }
}
