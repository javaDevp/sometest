using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Asp.Net.LifeCycle
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //Application["EventList"] = new List<string>();
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "http://apps.bdimg.com/libs/jquery/2.1.4/jquery.min.js",
                DebugPath = "http://apps.bdimg.com/libs/jquery/2.1.4/jquery.js",
                CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.7.2.min.js",
                CdnDebugPath =
                    "http://ajax.microsoft.com/ajax/jQuery/jquery-1.7.2.js"
            });  
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //if (Application["EventList"] == null)
                Application["EventList"] = new List<string>();
        }
    }
}