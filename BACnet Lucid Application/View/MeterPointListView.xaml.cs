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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BACnet_Lucid_Application.Model;

namespace BACnet_Lucid_Application.View
{
    /// <summary>
    /// Interaction logic for MeterPointListView.xaml
    /// </summary>
    public partial class MeterPointListView : UserControl
    {
        public PointList pointList { get; set; }
        public MeterPointListView()
        {
            this.pointList = new PointList();
            InitializeComponent();
            this.DataContext = this;
            this.pointList.Add(new MeterPoint() { BACnetDevice = "NAE-1", BACnetID = "123123", BACnetIP = "123.123.123.123", BACnetName = "whatever", LucidID = "wber_blah", LastPosted = new DateTime(), LastUpdated = new DateTime()});
            this.pointList.Add(new MeterPoint() { BACnetDevice = "NAE-2", BACnetID = "123123", BACnetIP = "123.123.123.123", BACnetName = "whatever", LucidID = "wber_blah", LastPosted = new DateTime(), LastUpdated = new DateTime()});
            this.pointList.Add(new MeterPoint() { BACnetDevice = "NAE-3", BACnetID = "123123", BACnetIP = "123.123.123.123", BACnetName = "whatever", LucidID = "wber_blah", LastPosted = new DateTime(), LastUpdated = new DateTime()});
            this.pointList.Add(new MeterPoint() { BACnetDevice = "NAE-4", BACnetID = "123123", BACnetIP = "123.123.123.123", BACnetName = "whatever", LucidID = "wber_blah", LastPosted = new DateTime(), LastUpdated = new DateTime()});

        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            this.pointList.Add(new MeterPoint());
            PointWindow pointWindow = new PointWindow(pointList[pointList.Count()-1]);
            pointWindow.ShowDialog();
            Console.WriteLine(pointList.Count());
        }
        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            PointWindow pointWindow = new PointWindow((MeterPoint)lvPointList.SelectedItem);
            pointWindow.ShowDialog();
        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            pointList.Remove((MeterPoint)lvPointList.SelectedItem);
        }
    }
}
