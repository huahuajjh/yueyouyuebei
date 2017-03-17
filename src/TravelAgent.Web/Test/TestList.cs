using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.WeiPay;

namespace Test
{
    [TestClass]
    public class TestList
    {
        [TestMethod]
        public void TestL()
        {
            string ids = "";
            for (int i = 0; i < 10; i++)
            {
                if(string.IsNullOrEmpty(ids))
                { 
                    ids += i;
                }
                else
                { 
                    ids += ("."+i);
                }
            }

            Console.WriteLine(ids);

        }

        [TestMethod]
        public void TestMd5()
        {
            Console.WriteLine(MD5Util.GetMD5("appid=wx462bea8643df9214&body=test-2017-03-15&mch_id=1394199702&nonce_str=b73dfe25b4b8714c029b37a6ad3006fa&notify_url=http://www.yueyouyuebei.com/mTravel/weipay/Notify.aspx&openid=o63zqwPkD9uFvwcWI7y6NSbYMsTI&out_trade_no=O20170314151027607&spbill_create_ip=171.221.142.196&total_fee=100&trade_type=JSAPI&key=yueyouyuebei8888yueyouyuebei8888", "utf-8"));
        }
    }
}
