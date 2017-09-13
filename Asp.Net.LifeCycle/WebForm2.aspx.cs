using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net.LifeCycle
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
                lblMessage.Text = "Your reservation has been processed";
        }
    }
}