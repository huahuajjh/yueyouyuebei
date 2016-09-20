using NLog;
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
        private ILogger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = HttpContext.Current.Server.GetLastError();
            if(ex != null)
            { 
                logger.Error("error={0}    url={1}  user_ip={2}  stacktrace={3}",ex.Message,HttpContext.Current.Request.RawUrl,HttpContext.Current.Request.UserHostAddress,ex.StackTrace);
            }
        }
    }
}