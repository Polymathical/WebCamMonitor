using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCamMonitor
{
    public static class VideoCapabilitiesExtensions
    {
        public static string ToFriendlyString(this VideoCapabilities vc)
        {
            return vc.FrameSize.Width.ToString() + " x " + vc.FrameSize.Height.ToString() + ", " + vc.AverageFrameRate + "fps";
        }
    }
}
