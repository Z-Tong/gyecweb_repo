﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GYECWeb.page_front;

namespace GYECWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                Response.Redirect("page_front/Index.ashx");
            }
            catch (Exception ee)
            {
            }
        }
    }
}