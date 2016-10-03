namespace WebCamMonitor
{
    partial class CameraDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCameraName = new System.Windows.Forms.Label();
            this.btnSetupCamera = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbVideoResolutions = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCameraName
            // 
            this.lblCameraName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCameraName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCameraName.Location = new System.Drawing.Point(2, 246);
            this.lblCameraName.Name = "lblCameraName";
            this.lblCameraName.Size = new System.Drawing.Size(283, 23);
            this.lblCameraName.TabIndex = 0;
            this.lblCameraName.Text = "Camera Name";
            this.lblCameraName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSetupCamera
            // 
            this.btnSetupCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetupCamera.AutoSize = true;
            this.btnSetupCamera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSetupCamera.Location = new System.Drawing.Point(291, 246);
            this.btnSetupCamera.Name = "btnSetupCamera";
            this.btnSetupCamera.Size = new System.Drawing.Size(26, 23);
            this.btnSetupCamera.TabIndex = 1;
            this.btnSetupCamera.Text = "...";
            this.btnSetupCamera.UseVisualStyleBackColor = true;
            this.btnSetupCamera.Click += new System.EventHandler(this.btnSetupCamera_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(317, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // cbVideoResolutions
            // 
            this.cbVideoResolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVideoResolutions.DropDownWidth = 200;
            this.cbVideoResolutions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVideoResolutions.FormattingEnabled = true;
            this.cbVideoResolutions.Location = new System.Drawing.Point(167, 248);
            this.cbVideoResolutions.Name = "cbVideoResolutions";
            this.cbVideoResolutions.Size = new System.Drawing.Size(118, 21);
            this.cbVideoResolutions.TabIndex = 3;
            this.cbVideoResolutions.SelectedIndexChanged += new System.EventHandler(this.cbVideoResolutions_SelectedIndexChanged);
            // 
            // CameraDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbVideoResolutions);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSetupCamera);
            this.Controls.Add(this.lblCameraName);
            this.Name = "CameraDisplay";
            this.Size = new System.Drawing.Size(320, 279);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCameraName;
        private System.Windows.Forms.Button btnSetupCamera;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbVideoResolutions;
    }
}
