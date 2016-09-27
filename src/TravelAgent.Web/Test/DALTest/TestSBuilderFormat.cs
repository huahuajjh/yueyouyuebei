using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.DALTest
{
    [TestClass]
    public class TestSBuilderFormat
    {
        public int JJH { get; set; }

        [TestMethod]
        public void TestFormat()
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("this is {0}","sam");
            Console.WriteLine(sb.ToString());
        }   

        [TestMethod]
        public void TestReflection()
        { 
            Type t = this.GetType();
            PropertyInfo p = t.GetProperties()[0];
            Console.WriteLine(p.Name);
        }
    }
}
