using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GYECWeb.page_front
{
    /// <summary>
    /// Products 的摘要说明
    /// </summary>
    public class Products : FrontBasePage,IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            VelocityHelper vh = new VelocityHelper();
            vh.Init("~/template/front");    //模板路径

            #region 科研成果列表
            vh.Put("pl",Front_DataHandlerBLL.GetIndexProductListBLL());
            #endregion

            #region 获取head.html中菜单项
            vh.Put("menu", this.Menu);
            vh.Put("submenu", this.SubMenu);
            vh.Put("parentmenu", this.ParentMenu);

            #endregion


            vh.Display("products.html");
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