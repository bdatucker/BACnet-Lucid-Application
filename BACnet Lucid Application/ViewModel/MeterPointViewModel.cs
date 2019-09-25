using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using BACnet_Lucid_Application.Model;

namespace BACnet_Lucid_Application.ViewModel
{
    class MeterPointViewModel
    {
        int UDPPort = 47808;

        IPEndPoint localEP;
        IPAddress localIP = IPAddress.Parse("137.190.101.122");

        IPEndPoint remoteEP;
        IPAddress remoteIP = IPAddress.Parse("172.17.40.10");
        //IPAddress remoteIP = IPAddress.Parse("172.17.84.13");

        UdpClient sendUDP;

        UdpClient receiveUDP;

        public MeterPointViewModel()
        {
            localEP = new IPEndPoint(localIP, UDPPort);
            remoteEP = new IPEndPoint(remoteIP, UDPPort);

            sendUDP = new UdpClient();
            sendUDP.ExclusiveAddressUse = false;
            sendUDP.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            sendUDP.Client.Bind(localEP);

            receiveUDP = new UdpClient(UDPPort, AddressFamily.InterNetwork);
        }


 
        public void getPresentValue(MeterPoint p)
        {
            byte[] testByte = new byte[17];

            // Send the request
            try
            {
                //PEP Use NPDU.Create and APDU.Create (when written)
                //BVLC
                testByte[0] = 0x81;     // BVLC Type (0x81 = BACNet/IP)
                testByte[1] = 0x0A;     // BVLC Function (0x0B = BROADCAST)
                testByte[2] = 0x00;     // BVLC Length (2 bytes)
                testByte[3] = 0x11;     // BVLC Length 

                //NPDU
                testByte[4] = 0x01;     // Version
                testByte[5] = 0x04;     // Control Flags =  0010 0000
                                        //                  0... .... = NSDU contains: BACnet APDU, message type field absent.
                                        //                  .0.. .... = Reserved: Shall be zero and is zero.
                                        //                  ..1. .... = Destination Specifier: DNET, DLEN and Hop Count present. If DLEN=0: broadcast, dest. address field absent.
                                        //                  ...0 .... = Reserved: Shall be zero and is zero.
                                        //                  .... 0... = Source specifier: SNET, SLEN and SADR absent
                                        //                  .... .0.. = Expecting Reply: Other than a BACnet-Confirmed-Request-PDU, segment of BACnet-ComplexACK-PDU or network layer message expecting a reply present.
                                        //                  .... ..0. = Priority: Not a Life Safety or Critical Equipment message.
                                        //                  .... ...0 = Priority: Normal message

                testByte[6] = 0x02;     // DNET - 2-octet ultimate destination network number.
                testByte[7] = 0x75;     // DNET

                testByte[8] = 0x7C;     // DLEN - 1-octet length of ultimate destination MAC layer address (A value of 0 indicates a broadcast on the destination network.)

                testByte[9] = 0x0C;     // Hop Count (FF = 255)

                //APDU
                testByte[10] = 0x0C;    // APDU Type : Unconfirmed Request
                testByte[11] = 0x00;    // Unconfirmed Service Choice: 8, who is. (pg 794)
                testByte[12] = 0x6D;
                testByte[13] = 0xE8;
                testByte[14] = 0xAD;
                testByte[15] = 0x19;
                testByte[16] = 0x55;


                sendUDP.EnableBroadcast = false;
                sendUDP.Send(testByte, 17, remoteEP);
                while (true)
                {
                    var remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    var recvBytes = sendUDP.Receive(ref remoteEP);
                    Console.WriteLine(remoteEP.Address.ToString());
                    Console.WriteLine("this many bytes: " + recvBytes.Length);
                    //BACnetFrame b = new BACnetFrame(Array.ConvertAll(recvBytes, c => (int)c));
                    //Parse and save the BACnet data
                    for (int i = 0; i < recvBytes.Length; i++)
                    {
                        Console.WriteLine(recvBytes[i].ToString("X2"));
                    }
                    Console.WriteLine("-----------");
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void testc()
        {
            int x = 3145728;
            double m = 0.000000119209289550781;
            Console.WriteLine(x * m + 1);
        }

        public void readPropertyTest()
        {
            byte[] testByte = { 0x81, 0x0a, 0x00, 0x11, 0x01, 0x04, 0x02, 0x75, 0x00, 0x0c, 0x0c, 0x00, 0x2d, 0xc6, 0xf6, 0x19, 0x55 };


            // Send the request
            try
            {

                sendUDP.EnableBroadcast = false;
                sendUDP.Send(testByte, 17, remoteEP);
                while (true)
                {
                    var remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    var recvBytes = sendUDP.Receive(ref remoteEP);
                    // Parse and save the BACnet data
                    for (int i = 0; i < recvBytes.Length; i++)
                    {
                        Console.WriteLine(recvBytes[i].ToString("X2"));
                    }
                    Console.WriteLine("-----------");
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}