using System;
using System.Collections.Generic;
using System.Text;
using CustomDevice;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace test
{
  
    class Program
    {
        class Descriptor {
            public Descriptor xd(JsObject o) {  return null; }
            public JsDictionaryObject d;
        }
        abstract class JsInstance { }
        abstract class JsDictionaryObject :JsInstance
        {
            public JsDictionaryObject()
            {
                Console.WriteLine("hmm");
            }

            protected static Descriptor prototypeDescriptor = new Descriptor();//JsUndefined.Get());


       
        }
        class JsObject : JsDictionaryObject//,IEnumerable<KeyValuePair<string,JsInstance>>
        {
        }
    
        class EVisitor
        {
            public JsDictionaryObject dict { get; set; }
            public JsObject obj { get; set; }
            public EVisitor()
            {
                obj = new JsGlobal(this, "aaa");
            }
        }
        class JsGlobal : JsObject {
            public EVisitor Visitor { get; set; }

            public JsGlobal(EVisitor vis, string s)
            {
            }
        }

        static Dictionary<string, object> ds = new Dictionary<string, object>();
        
        static object l { get; set; }
        static Program()
        {

            ds["a"] = l = new JsObject();
        }
        class cc { public cc(string s) { }  }
        static void Main(string[] args)
        {
            JsGlobal dummy;
            var k = new EVisitor();
            Console.WriteLine(k.obj);
        //    throw new NotImplementedException();

           // f3();
            //var x = new xxx();
            //x.yy();x.xx();
            Console.WriteLine("aaa!");
         //   Console.ReadLine();
            var x = new TcpServerTest();
            x.Serve();


        //    var g = DeviceGraphics.GetScreen();
        //    var running=true;
        //    var f = new Font("Nezjrkaddrsuiurzndpnjxkuax", 10);
        //    var s=File.ReadAllText("a.txt");
        //    try
        //    {
        //        var so = File.OpenRead("a.txt");
        //        var so2 = File.OpenWrite("b.txt");
        //        byte[] buf = new byte[1024];
        //        int bytes = 0;
        //        while ((bytes = so.Read(buf, 0, 1024)) > 0)
        //        {
        //            so2.Write(buf, 0, bytes);
        //        }
        //        so.Close();
        //        so2.Close();
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        ////	s=sockettest();
        //   while (running)
        //    {
        //        g.Clear(Color.Black);
        //        //for (uint i = 0; i < 255; i++)
        //        //{
        //        //    g.DrawLine(Pens.White, 0, 0, 100, 100 + (int)i*2);
        //        //}//
        //        var ss = "";
        //        if (CustomDevice.KeyPad.IsKeyDown(KeyPadKey.C)) ss = "EEE";
        //        g.DrawString(ss, f, Brushes.White, 0f, 0f);
        //        g.DrawString(s, f, Brushes.White, 0f, 20f);
        //        Thread.Sleep(40);
        //    }
            
            // File.Copy("a.txt", "b.txt");
            //var x = CustomDevice.KeyPad.ReadKey();
            Thread.Sleep(10000);
            //if (x == null) return;
//            CustomDevice.KeyPad.IsKeyDown(KeyPadKey.OK);
        }
        public static byte[] getbytesascii(string s)
        {
            var b = new byte[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                b[i] = (byte)(s[i] & 0xff);
            }
            return b;
        }
        public static string getstring(byte[] b, int ofs, int cnt)
        {
            char[] c = new char[cnt];
            for (int i = 0; i < cnt; i++) c[i] = (char)b[i + ofs];
            return new String(c, 0, cnt);
        }

    }
}
