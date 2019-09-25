using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BACnet_Lucid_Application;
using BACnet_Lucid_Application.Model;
using BACnet_Lucid_Application.View;
using BACnet_Lucid_Application.ViewModel;


namespace BACnet_Lucid_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<MeterPoint> items;
        //public View.MeterPointListView uc_lv_Points = new MeterPointListView();

        public MainWindow()
        {
            InitializeComponent();
            //List<MeterPoint> items = new List<MeterPoint>();
            //items.Add(new MeterPoint() { BACnetDevice = "NAE-1", BACnetID = "123123", BACnetIP = "123.123.123.123", BACnetName = "whatever", LucidID = "wber_blah", LastPosted = "12/12/12", LastUpdated = "12/12/12" });
            //items.Add(new MeterPoint() { BACnetDevice = "NAE-2", BACnetID = "123123", BACnetIP = "123.123.123.123", BACnetName = "whatever", LucidID = "wber_blah", LastPosted = "12/12/12", LastUpdated = "12/12/12" });
            //items.Add(new MeterPoint() { BACnetDevice = "NAE-3", BACnetID = "123123", BACnetIP = "123.123.123.123", BACnetName = "whatever", LucidID = "wber_blah", LastPosted = "12/12/12", LastUpdated = "12/12/12" });
            //items.Add(new MeterPoint() { BACnetDevice = "NAE-4", BACnetID = "123123", BACnetIP = "123.123.123.123", BACnetName = "whatever", LucidID = "wber_blah", LastPosted = "12/12/12", LastUpdated = "12/12/12" });
            //Console.WriteLine(items.Count());
            ////lvPoints.ItemsSource = items;
            //Console.WriteLine(items.Count());

            MeterPointViewModel test = new MeterPointViewModel();

            //test.testPoint();
            test.testc();

            NotifyIcon ni = new NotifyIcon();

            ni.Icon = new Icon("C:\\Users\\briantucker2\\source\\repos\\BACnet Lucid Application\\BACnet Lucid Application\\Main.ico");
            ni.Visible = true;
            ni.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }
    }
}
