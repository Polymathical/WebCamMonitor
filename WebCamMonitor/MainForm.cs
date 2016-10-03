using System;
using System.Linq;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.Collections.Generic;


namespace WebCamMonitor
{
  
    public partial class MainForm : Form
    {
        private FilterInfoCollection _videoDevices;
        private List<VideoCaptureDevice> _videoSources = new List<VideoCaptureDevice>();
        private List<DeviceViewInformation> _deviceViewAssociation = new List<DeviceViewInformation>();

        private DateTime _lastWebUpdate = DateTime.Now;

        public bool Started { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                CreateVideoFilterViewAssociations();
            }
        }

        private bool FiltersHaveChanged()
        {
            var requiresUpdate = false;

            if (_videoDevices == null || _videoDevices.Count == 0)
                return true;

            foreach (FilterInfo fi in _videoDevices)
            {
                var found = _deviceViewAssociation.Any(vd => vd.CaptureDevice.Source == fi.MonikerString);
                if (found == false)
                {
                    requiresUpdate = true;
                    break;
                }
            }
            return requiresUpdate;
        }

        private void CreateVideoFilterViewAssociations()
        {
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            
            if (FiltersHaveChanged() == false)
                return;

            _deviceViewAssociation.Clear();
            cameraTableLayoutPanel.Controls.Clear();
            
            int filterNumber = 1;

            foreach (FilterInfo fi in _videoDevices)
            {
                var newVideoSource = new VideoCaptureDevice(fi.MonikerString);
                newVideoSource.VideoSourceError += new VideoSourceErrorEventHandler(videoSource_VideoSourceError);
                newVideoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                newVideoSource.VideoResolution = newVideoSource.VideoCapabilities.Where(vc => vc.FrameSize.Width == 320).FirstOrDefault();

                var newCameraDisplay = new CameraDisplay();
                newCameraDisplay.CameraName = fi.Name;
                newCameraDisplay.VideoSource = newVideoSource;
                newCameraDisplay.BorderStyle = BorderStyle.FixedSingle;
                newCameraDisplay.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
                cameraTableLayoutPanel.Controls.Add(newCameraDisplay);

                _deviceViewAssociation.Add(new DeviceViewInformation() { DeviceId = filterNumber, CaptureDevice = newVideoSource, CameraDisplay = newCameraDisplay });

                filterNumber++;
            }

            if (String.IsNullOrWhiteSpace(Properties.Settings.Default.IpCamera1Url) == false)
            {
                var newIpCamera = new JPEGStream(Properties.Settings.Default.IpCamera1Url);
                newIpCamera.Login = Properties.Settings.Default.IpCamera1UserName;
                newIpCamera.Password = Properties.Settings.Default.IpCamera1Password;

                  var newCameraDisplay = new CameraDisplay();
                newCameraDisplay.CameraName = newIpCamera.Source;
                newCameraDisplay.VideoSource = newIpCamera;
                newCameraDisplay.BorderStyle = BorderStyle.FixedSingle;
                newCameraDisplay.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
                cameraTableLayoutPanel.Controls.Add(newCameraDisplay);

                _deviceViewAssociation.Add(new DeviceViewInformation() { DeviceId = filterNumber, CaptureDevice = newIpCamera, CameraDisplay = newCameraDisplay });
            }

            cameraTableLayoutPanel.Refresh();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseAllSources();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;

            CloseAllSources();

            if (Started == false)
            {
                CreateVideoFilterViewAssociations();
                StartCapturing();
            }

            Started = !Started;

            btnStart.Text = Started ? "Stop" : "Start";

            btnStart.Enabled = true;
        }


        private void CloseAllSources()
        {
            foreach (IVideoSource vcd in _deviceViewAssociation.Select(dva => dva.CaptureDevice))
            {
                CloseVideoSource(vcd);
            }

            GC.Collect();
        }

        private void CloseVideoSource(IVideoSource vs)
        {

            if (vs == null || vs.IsRunning == false)
                return;

            vs.SignalToStop();
            vs.WaitForStop();
            vs = null;
        }


        private void StartCapturing()
        {
            foreach(DeviceViewInformation dva in _deviceViewAssociation)
            {
                if (dva.CaptureDevice.IsRunning == false)
                {
                    dva.CaptureDevice.Start();
                    var camDisp = dva.CameraDisplay.CameraPictureBox.Image = Properties.Resources.LoadingImage;
                }
            }
        }

        bool WebUpdateIntervalPassed(DateTime lastUpdate)
        {
            return (DateTime.Now - lastUpdate).TotalMilliseconds > Properties.Settings.Default.WebImageUpdateIntervalMs;
        }

        bool ConsoleUpdateIntervalPassed(DateTime lastUpdate)
        {
            return (DateTime.Now - lastUpdate).TotalMilliseconds > Properties.Settings.Default.ConsoleImageUpdateIntervalMs;
        }

        void videoSource_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            MessageBox.Show(eventArgs.Description);
        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            
            var thisVcdAssociation = (from vcd in _deviceViewAssociation where vcd.CaptureDevice == sender as IVideoSource select vcd).FirstOrDefault();
            var cameraDisp = thisVcdAssociation.CameraDisplay;

            if (cameraDisp.VideoSource is JPEGStream)
                Debug.WriteLine("ip cam");

            var thisFrameImage = eventArgs.Frame.Clone() as Image;

            if (Properties.Settings.Default.RenderDateTimes)
            {
                thisFrameImage.DrawText(DateTime.Now.ToString());
            }

            // optionally write images for web monitoring
            if (chkWriteImages.Checked && WebUpdateIntervalPassed(_lastWebUpdate))
            {
                WriteImageToOutputDir("Camera" + thisVcdAssociation.DeviceId.ToString() + ".jpg", thisFrameImage as Bitmap);
                _lastWebUpdate = DateTime.Now;
            }

            if (ConsoleUpdateIntervalPassed(cameraDisp.LastUpdateDateTime))
            {
                cameraDisp.CameraImage = thisFrameImage;
            }



        }

        private void chkWriteImages_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WriteImageToOutputDir(string fileName, Bitmap bmp)
        {
            if (bmp == null)
                return;

            try
            {
                var outputDir = Properties.Settings.Default.ImageOutputDirectory;
                if (outputDir.EndsWith(@"\\") == false)
                    outputDir += "\\";

                var quality = Convert.ToInt64(Properties.Settings.Default.JpgImageQuality);
                bmp.SaveJPG(outputDir + fileName, quality);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }


    }
}