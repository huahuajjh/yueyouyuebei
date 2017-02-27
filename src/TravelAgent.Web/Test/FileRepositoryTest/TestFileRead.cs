using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgent.FileRepository;
using System.IO;
using System.Configuration;
using TravelAgent.Model;

namespace Test.FileRepositoryTest
{
    [TestClass]
    public class TestFileRead
    {
        [TestMethod]
        public void TestRead()
        {
            Console.WriteLine(FileRepository.GetInstance().Read<DistributorContent>("DistributorContent.json").ToString());
        }

        [TestMethod]
        public void TestWrite()
        {
            DistributorContent o = new DistributorContent() {
             Content4BeADistributor="asdasdasdasas",
              DistributorUrl="asd",
              Id=123
            };

            FileRepository.GetInstance().Write<DistributorContent>(o, "DistributorContent.json");

        }

        [TestMethod]
        public void TestPath()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }
    }
}
