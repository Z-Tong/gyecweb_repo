using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GYECWeb.page_front
{
    /// <summary>
    /// Product_Info 的摘要说明
    /// </summary>
    public class Product_Info : FrontBasePage,IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            VelocityHelper vh = new VelocityHelper();
            vh.Init("~/template/front");
            int pid=0;
            try
            {
                pid = Convert.ToInt32(context.Request["id"].ToString());
            }
            catch (Exception)
            {
            }
            string ptitle;
            string pinfo;
            string pdes;
            string pimage;
            string psort;
            Front_DataHandlerBLL.GetProductInfoBLL(pid, out ptitle, out pinfo, out pdes, out pimage, out psort);

            vh.Put("title", ptitle);
            vh.Put("info", pinfo);
            vh.Put("des", pdes);
            vh.Put("image", pimage);
            vh.Put("sort", psort);

            #region 获取head.html中菜单项

            vh.Put("menu", this.Menu);
            vh.Put("submenu", this.SubMenu);
            vh.Put("parentmenu", this.ParentMenu);

            #endregion



            vh.Display("product_detail.html");
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