using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCamMonitor
{
    public class VideoResolutionListItem
    {
        public string Name { get; set; }
        public VideoCapabilities Value { get; set; }
    }
}
