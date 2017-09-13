using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net.LifeCycle
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        private List<string> EventList = new List<string>();
        private List<string> EventListAll = new List<string>();

        protected void Page_Init(object sender, EventArgs e)
        {
            EventListAll = ((List<string>) Application["EventList"]);
            EventListAll.Add("Control_Page_Init");
            EventList.Add("Page_Init");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            EventListAll.Add("Control_Page_Load");
            EventList.Add("Page_Load");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            EventListAll.Add("Control_Page_PreRender");
            EventList.Add("Page_PreRender");
            eventRepeater.DataSource = EventList;
            eventRepeater.DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            EventListAll.Add("Control_Page_Unload");
            EventList.Add("Page_Unload");
        }
    }
}