using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net.LifeCycle
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<string> EventList = new List<string>();
        private List<string> EventListAll = new List<string>();

        public const string DefaultThemeName = "Skin2";

        /// <summary>
        /// Check the IsPostBack property to determine whether this is the first time the page is being processed. The IsCallback and IsCrossPagePostBack properties have also been set at this time.
        /// Create or re-create dynamic controls.
        /// Set a master page dynamically.
        /// Set the Theme property dynamically.
        /// Read or set profile property values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreInit(object sender, EventArgs e)
        {
            string themeName = DefaultThemeName;
            string materPageFile = "";
           
            if (Request.QueryString["theme"] != null)
            {
                themeName = Request.QueryString["theme"];
            }

            //string clientScriptBlock = "var CurrentThemeCookieName = \"" + GetThemeCookieName() + "\";";
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CurrentThemeCookieName", clientScriptBlock, true);

            this.Theme = themeName;
            this.MasterPageFile = materPageFile;
            EventListAll = ((List<string>)Application["EventList"]);
            EventListAll.Add("Page_PreInit");
            EventList.Add("Page_PreInit");
            
        }

        /// <summary>
        /// Use this event to read or initialize control properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            EventListAll.Add("Page_Init");
            EventList.Add("Page_Init");
        }

        /// <summary>
        /// Use this event to make changes to view state that you want to make sure are persisted after the next postback.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            EventListAll.Add("Page_InitComplete");
            EventList.Add("Page_InitComplete");
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            EventListAll.Add("Page_PreLoad");
            EventList.Add("Page_PreLoad");
        }
        
        /// <summary>
        /// Use the OnLoad event method to set properties in controls and to establish database connections.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            skinChange.Value = Request["theme"];
            EventListAll.Add("Page_Load");
            EventList.Add("Page_Load");
           
        }

        /// <summary>
        /// Use this event for tasks that require that all other controls on the page be loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            EventListAll.Add("Page_LoadComplete");
            EventList.Add("Page_LoadComplete");
        }

        /// <summary>
        /// Use the event to make final changes to the contents of the page or its controls before the rendering stage begins.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            EventListAll.Add("Page_PreRender");
            EventList.Add("Page_PreRender");
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            EventListAll.Add("Page_PreRenderComplete");
            EventList.Add("Page_PreRenderComplete");
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            EventListAll.Add("Page_SaveStateComplete");
            EventList.Add("Page_SaveStateComplete");
        }

        protected override void Render(HtmlTextWriter writer)
        {
            EventListAll.Add("Render");
            EventList.Add("Render");
            eventRepeater.DataSource = EventList;
            eventRepeater.DataBind();
            eventRepeaterAll.DataSource = ((List<string>) Application["EventList"]);
            eventRepeaterAll.DataBind();
            base.Render(writer);
        }

        /// <summary>
        /// use this event to do final cleanup work, such as closing open files and database connections, or finishing up logging or other request-specific tasks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Unload(object sender, EventArgs e)
        {
            EventListAll.Add("Page_Unload");
            EventList.Add("Page_Unload");
        }

    }
}