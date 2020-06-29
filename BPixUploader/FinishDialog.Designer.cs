namespace BPixUploader
{
  partial class FinishDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.urls = new System.Windows.Forms.RichTextBox();
      this.okButton = new System.Windows.Forms.Button();
      this.tagsCheckbox = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(230, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "All of the uploads have completed successfully!";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 26);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(156, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "The URLs can be found below:";
      // 
      // urls
      // 
      this.urls.Location = new System.Drawing.Point(12, 42);
      this.urls.Name = "urls";
      this.urls.ReadOnly = true;
      this.urls.Size = new System.Drawing.Size(233, 304);
      this.urls.TabIndex = 2;
      this.urls.Text = "";
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(12, 376);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(232, 23);
      this.okButton.TabIndex = 3;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButtonClicked);
      // 
      // tagsCheckbox
      // 
      this.tagsCheckbox.AutoSize = true;
      this.tagsCheckbox.Location = new System.Drawing.Point(13, 353);
      this.tagsCheckbox.Name = "tagsCheckbox";
      this.tagsCheckbox.Size = new System.Drawing.Size(111, 17);
      this.tagsCheckbox.TabIndex = 4;
      this.tagsCheckbox.Text = "Append [img] tags";
      this.tagsCheckbox.UseVisualStyleBackColor = true;
      // 
      // FinishDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(257, 409);
      this.Controls.Add(this.tagsCheckbox);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.urls);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "FinishDialog";
      this.Text = "Done!";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox urls;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox tagsCheckbox;
    }
}