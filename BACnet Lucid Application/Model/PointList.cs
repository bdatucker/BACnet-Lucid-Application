using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BACnet_Lucid_Application.Model
{
    [Serializable]
    public class PointList : ObservableCollection<MeterPoint>
    {
    }
}
