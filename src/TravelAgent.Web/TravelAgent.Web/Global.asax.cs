using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TravelAgent.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Error(object sender, EventArgs e)
        {
            //test code,should be deleted
            Exception ex = HttpContext.Current.Server.GetLastError();
            if(ex != null)
            { 
                FileStream fs = File.OpenWrite("d:/log.txt");
                byte[] bs = Encoding.UTF8.GetBytes(ex.InnerException.ToString());
                fs.Write(bs,0,bs.Length);
                fs.Flush();
            }
        }
    }
}