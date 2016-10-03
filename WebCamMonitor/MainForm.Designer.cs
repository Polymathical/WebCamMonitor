namespace WebCamMonitor
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
            this.btnStart = new System.Windows.Forms.Button();
            this.cameraTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.chkWriteImages = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(15, 604);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cameraTableLayoutPanel
            // 
            this.cameraTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cameraTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.cameraTableLayoutPanel.ColumnCount = 3;
            this.cameraTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.cameraTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.cameraTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.cameraTableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.cameraTableLayoutPanel.Name = "cameraTableLayoutPanel";
            this.cameraTableLayoutPanel.RowCount = 2;
            this.cameraTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cameraTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cameraTableLayoutPanel.Size = new System.Drawing.Size(984, 569);
            this.cameraTableLayoutPanel.TabIndex = 17;
            // 
            // chkWriteImages
            // 
            this.chkWriteImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWriteImages.AutoSize = true;
            this.chkWriteImages.Location = new System.Drawing.Point(111, 608);
            this.chkWriteImages.Name = "chkWriteImages";
            this.chkWriteImages.Size = new System.Drawing.Size(88, 17);
            this.chkWriteImages.TabIndex = 18;
            this.chkWriteImages.Text = "Write Images";
            this.chkWriteImages.UseVisualStyleBackColor = true;
            this.chkWriteImages.CheckedChanged += new System.EventHandler(this.chkWriteImages_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 650);
            this.Controls.Add(this.chkWriteImages);
            this.Controls.Add(this.cameraTableLayoutPanel);
            this.Controls.Add(this.btnStart);
            this.MinimumSize = new System.Drawing.Size(400, 380);
            this.Name = "MainForm";
            this.Text = "WebCam Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TableLayoutPanel cameraTableLayoutPanel;
        private System.Windows.Forms.CheckBox chkWriteImages;
    }
}

