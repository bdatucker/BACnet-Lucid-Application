using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BACnet_Lucid_Application.Model
{
    public class MeterPoint
    {
        public MeterPoint()
        {
            Status = false;
            Interval = 15;
        }

        public MeterPoint(MeterPoint p)
        {
            Status = false;
            BACnetIP = p.BACnetIP;
            BACnetDevice = p.BACnetDevice;
            BACnetName = p.BACnetName;
            BACnetID = p.BACnetID;
            LucidID = p.LucidID;
            LastPosted = p.LastPosted;
            LastUpdated = p.LastUpdated;
            Interval = 15;
        }


        public bool Status { get; set; }
        public string BACnetIP { get; set; }
        public string BACnetDevice { get; set; }
        public string BACnetName { get; set; }
        public string BACnetID { get; set; }
        public string LucidID { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime LastPosted { get; set; }
        public float Interval { get; set; }
    }
}
