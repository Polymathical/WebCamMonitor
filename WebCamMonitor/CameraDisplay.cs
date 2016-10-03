using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Diagnostics;
using AForge.Video;

namespace WebCamMonitor
{
    public partial class CameraDisplay : UserControl
    {
        public string CameraName { get { return lblCameraName.Text; } set { lblCameraName.Text = value; } }
        public Image CameraImage
        {
            get { return pictureBox1.Image; }
            set
            {
                UpdateCameraImage(value);
            }
        }

        public PictureBox CameraPictureBox { get { return pictureBox1; } }
        public DateTime LastUpdateDateTime { get; private set; }

        public bool IsWebCamera { get { return _videoSource != null && _videoSource is VideoCaptureDevice; } }

        public bool IsIpCamera { get { return _videoSource != null && _videoSource is JPEGStream; } }

        public IVideoSource VideoSource
        {
            get { return _videoSource; }
            set
            {
                _videoSource = value;

                if (IsWebCamera)
                    _webCamera = _videoSource as VideoCaptureDevice;
                else if (IsIpCamera)
                    _ipCamera = _videoSource as JPEGStream;

                PopulateVideoCapabilities();
            }
        }

        private JPEGStream _ipCamera { get; set; }
        private VideoCaptureDevice _webCamera { get; set; }

        private IVideoSource _videoSource;

        public CameraDisplay()
        {
            InitializeComponent();
            cbVideoResolutions.SelectedIndexChanged += cbVideoResolutions_SelectedIndexChanged;
        }

        
        void UpdateCameraImage(Image newImage)
        {
            pictureBox1.Image = newImage;
            this.LastUpdateDateTime = DateTime.Now;
        }

        private void cbVideoResolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRes = cbVideoResolutions.SelectedItem as VideoResolutionListItem;

            if (selectedRes == null)
            {
                Debug.WriteLine("cbVideoResolutions.SelectedItem == null");
                return;
            }
             
            var restartCamera = _videoSource.IsRunning;

            if (restartCamera)
            {
                _videoSource.SignalToStop();
                _videoSource.WaitForStop();
            }

            if(IsWebCamera)
                _webCamera.VideoResolution = selectedRes.Value;

            if (restartCamera)
                _videoSource.Start();

        }

        private void btnSetupCamera_Click(object sender, EventArgs e)
        {
            if (VideoSource == null)
                return;

            if (IsWebCamera)
            {
                _webCamera.DisplayPropertyPage(this.Handle);
            }
        }

        private void PopulateVideoCapabilities()
        {
            if (_videoSource == null)
                return;

            if (IsWebCamera)
            {
                if (_webCamera.VideoResolution == null && _webCamera.VideoCapabilities != null)
                    _webCamera.VideoResolution = _webCamera.VideoCapabilities.FirstOrDefault();

                var orderVideoCapabilities = from vidCaps in _webCamera.VideoCapabilities orderby vidCaps.FrameSize.Width orderby vidCaps.FrameSize.Height select vidCaps;
                foreach (VideoCapabilities vc in orderVideoCapabilities)
                {
                    cbVideoResolutions.Items.Add(new VideoResolutionListItem { Name = vc.ToFriendlyString(), Value = vc });
                    cbVideoResolutions.DisplayMember = "Name";
                    cbVideoResolutions.ValueMember = "Value";
                }

                if (_webCamera.VideoResolution != null)
                {
                    var liToSelect = from li in cbVideoResolutions.Items.Cast<VideoResolutionListItem>() where li.Value.Equals(_webCamera.VideoResolution) select li;

                    cbVideoResolutions.SelectedItem = liToSelect.FirstOrDefault();
                }
            }

        }
    }
}
