using System;
using System.Collections.Generic;
using System.Text;
using Jint;
using Jint.Native;
using System.IO;
using System.Threading;
using System.Net;

namespace Astral
{
    class Program
    {

        static void Main(string[] args)
        {

            JsGlobal dummy;
            JintEngine eng = new JintEngine();
            JsArray root = null;
      

            root = new JsArray();
            eng.GlobalScope["PersistentRoot"] = root;
            

            eng.SetDebugMode(true);
            eng.SetFunction("log"
                , new Jint.Delegates.Func<JsInstance, JsInstance>((JsInstance  obj) =>
                {
                    Console.WriteLine(obj==null?"NULL":obj.Value==null?"NULL 2":obj.Value.ToString());
                    return JsUndefined.Instance;
                }));
            

//            ((JsFunction)eng.GlobalScope["log"]).Execute(eng.Visitor, null, new JsInstance[] { new JsUndefined() });

         //   Console.WriteLine("\r\n" + eng.Run(File.ReadAllText(@"Scripts\func_jsonifier.js")));
            Console.WriteLine("\r\n" + eng.Run(File.ReadAllText(@"Scripts\test.js")));
            while (true)
            {
                Console.Write("] ");
                var l = Console.ReadLine();
                if (l.Length == 0) break;
                var res = eng.Run(l);
                Console.WriteLine(res == null ? "<.NET NULL>" : res.ToString());
            }
            Console.WriteLine("Saving...");
            //            Console.ReadLine();
            //    root.Modify();
            //   s.Close();
            //    Console.Write("Enter to close");
            //  Console.ReadLine();
        }

    }
}
