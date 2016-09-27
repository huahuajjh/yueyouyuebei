using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgent.DALSQL;
using TravelAgent.IDAL;
using System.Collections.Generic;
using TravelAgent.Tool;
using System.Configuration;

namespace Test.DALTest
{
    [TestClass]
    public class TestArea
    {
        [TestMethod]
        public void Add()
        {
            IArea area = new Area();
            IList<TravelAgent.Model.Area> list = area.Get("Pid = 510000");
            //Assert.IsNotNull(list);
            foreach (TravelAgent.Model.Area item in list)
            {
                Console.WriteLine(item.Name);
            }
        }

        [TestMethod]
        public void TestWebConfig()
        {
            Console.WriteLine(ConfigurationManager.ConnectionStrings["ConnectionSQLString"].ConnectionString);
        }

        [TestMethod]
        public void TestGetPage()
        {
            IArea area = new Area();
            int count = 0;
            IList<TravelAgent.Model.Area> list = area.Get("",2,10,out count);
            foreach (TravelAgent.Model.Area item in list)
            {
                Console.WriteLine(item.ShortName);
            }
        }
    }
}
