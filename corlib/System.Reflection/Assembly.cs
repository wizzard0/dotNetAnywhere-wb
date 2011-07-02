using System;
using System.Collections.Generic;
using System.Text;

namespace System.Reflection
{
    public class Assembly
    {
        internal static Assembly GetExecutingAssembly()
        {
            return new Assembly();
        }

        internal Type GetType(string cpName)
        {
            throw new NotImplementedException();
        }
    }
}
