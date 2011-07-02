using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace test
{
    public class TcpServerTest
    {
        public TcpServerTest()
        {
            this.listener = new TcpListener(4080);
            this.running = true;
        }

        public void Serve()
        {
            listener.Start();
            while (running)
            {
                var client = listener.AcceptTcpClient();
                Thread ct = new Thread(new ParameterizedThreadStart(serveClient));
                ct.Start(client);
            }
        }

        public void serveClient(object client_)
        {
            try
            {
                Console.WriteLine("Request receievd");
                var client = (TcpClient)client_;
                var stm = client.GetStream();
                byte[] b2 = new byte[10];
                int r = 0;
                var s = "";
                //				while((r=tc.Receive(b2,0,b2.Length,SocketFlags.None))>0){
                while ((r = stm.Read(b2, 0, b2.Length)) > 0)
                {
                    s += Program.getstring(b2, 0, r);
                    Console.Write(".");
                    //for (int i = 0; i < 10; i++)
                    //{
                    //    Console.Write(b2[r - 10 + i].ToString("X2") + " ");
                    //}
                    if (s.EndsWith("\r\n\r\n")) break;
                }
                Console.WriteLine(s+">END");
            
                Console.WriteLine();
                var resp = "HELLO WORLD!";
                var bs = Program.getbytesascii(resp);
                var cl = bs.Length;
                var reply = "HTTP/1.1 200 OK\n"
                    + "Content-Length: " + cl.ToString() + "\n"
                    + "Content-Type: text/plain\n"
                    + "\n";
                var breply = Program.getbytesascii(reply);
                stm.Write(breply, 0, breply.Length);
                stm.Write(bs, 0, cl);
                stm.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("SC E {0}", e.ToString());
            }
        }

        public TcpListener listener { get; set; }

        public bool running { get; set; }
    }
}
