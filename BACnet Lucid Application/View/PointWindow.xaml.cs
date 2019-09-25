using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BACnet_Lucid_Application.Model;
using BACnet_Lucid_Application;
using BACnet_Lucid_Application.View;


namespace BACnet_Lucid_Application.View
{
    /// <summary>
    /// Interaction logic for PointWindow.xaml
    /// </summary>
    public partial class PointWindow : Window
    {
        public MeterPoint point;
        public String test = "test";
        public PointWindow()
        {
            this.point = new MeterPoint();
            this.point.BACnetIP = "123";
            InitializeComponent();
            this.DataContext = point;
        }

        public PointWindow(MeterPoint p)
        {
            InitializeComponent();
            this.DataContext = p;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
