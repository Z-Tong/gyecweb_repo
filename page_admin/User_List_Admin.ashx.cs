using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYECWeb.page_admin
{
    /// <summary>
    /// User_List_Admin 的摘要说明
    /// </summary>
    public class User_List_Admin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            VelocityHelper vh = new VelocityHelper();
            vh.Init("~/template/admin");

            vh.Display("user-list.html");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}