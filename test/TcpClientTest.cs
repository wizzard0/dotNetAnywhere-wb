using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace test
{
    class TcpClientTest
    {
        static string sockettest()
        {
            try
            {
                //System.Net.Sockets.Socket tc = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //tc.Connect(new IPEndPoint(IPAddress.Parse("209.85.149.147"),80));
                TcpClient tc = new TcpClient();
                tc.Connect(new IPEndPoint(IPAddress.Parse("209.85.149.147"), 80));
                var stm = tc.GetStream();
                //				var stm = tc.
                byte[] bytes =Program. getbytesascii("GET / HTTP/1.1\nHost: www.google.com\nConnection: close\n\n");
                //	tc.Send(bytes,0,bytes.Length, SocketFlags.None);
                stm.Write(bytes, 0, bytes.Length);
                byte[] b2 = new byte[100000];
                int r = 0;
                var s = "";
                //				while((r=tc.Receive(b2,0,b2.Length,SocketFlags.None))>0){
                while ((r = stm.Read(b2, 0, b2.Length)) > 0)
                {
                    s += Program.getstring(b2, 0, r);
                }
                Console.WriteLine(s);
                tc.Close();

                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.ToString();
            }
        }
    }
}
