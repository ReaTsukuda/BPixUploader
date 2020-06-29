namespace BPixUploader
{
  partial class MainForm
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.status = new System.Windows.Forms.StatusStrip();
      this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
      this.fileList = new System.Windows.Forms.DataGridView();
      this.filenameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.uploadButton = new System.Windows.Forms.Button();
      this.menuStrip1.SuspendLayout();
      this.status.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.fileList)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(293, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
      this.optionsToolStripMenuItem.Text = "Options";
      this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsClicked);
      // 
      // status
      // 
      this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText});
      this.status.Location = new System.Drawing.Point(0, 407);
      this.status.Name = "status";
      this.status.Size = new System.Drawing.Size(293, 22);
      this.status.TabIndex = 1;
      // 
      // statusText
      // 
      this.statusText.Name = "statusText";
      this.statusText.Size = new System.Drawing.Size(0, 17);
      // 
      // fileList
      // 
      this.fileList.AllowUserToAddRows = false;
      this.fileList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.fileList.BackgroundColor = System.Drawing.Color.White;
      this.fileList.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.fileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.fileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filenameColumn,
            this.statusColumn});
      this.fileList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fileList.Location = new System.Drawing.Point(0, 24);
      this.fileList.Name = "fileList";
      this.fileList.ReadOnly = true;
      this.fileList.RowHeadersVisible = false;
      this.fileList.Size = new System.Drawing.Size(293, 383);
      this.fileList.TabIndex = 2;
      // 
      // filenameColumn
      // 
      this.filenameColumn.HeaderText = "Filename";
      this.filenameColumn.Name = "filenameColumn";
      this.filenameColumn.ReadOnly = true;
      // 
      // statusColumn
      // 
      this.statusColumn.HeaderText = "Status";
      this.statusColumn.Name = "statusColumn";
      this.statusColumn.ReadOnly = true;
      // 
      // uploadButton
      // 
      this.uploadButton.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.uploadButton.Location = new System.Drawing.Point(0, 384);
      this.uploadButton.Name = "uploadButton";
      this.uploadButton.Size = new System.Drawing.Size(293, 23);
      this.uploadButton.TabIndex = 3;
      this.uploadButton.Text = "Upload";
      this.uploadButton.UseVisualStyleBackColor = true;
      this.uploadButton.Click += new System.EventHandler(this.UploadButtonClicked);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(293, 429);
      this.Controls.Add(this.uploadButton);
      this.Controls.Add(this.fileList);
      this.Controls.Add(this.status);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.Text = "BPixUploader";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.status.ResumeLayout(false);
      this.status.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.fileList)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.DataGridView fileList;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.DataGridViewTextBoxColumn filenameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusColumn;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}

