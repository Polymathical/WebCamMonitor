using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCamMonitor
{
    public class DeviceViewInformation
    {
        public IVideoSource CaptureDevice { get; set; }
        public CameraDisplay CameraDisplay { get; set; }
        public int DeviceId { get; set; }
    }
}
