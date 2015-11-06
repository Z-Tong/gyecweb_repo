using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GYECWeb.page_front
{
    /// <summary>
    /// Index 的摘要说明
    /// </summary>
    public class Index :FrontBasePage, IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            VelocityHelper vh = new VelocityHelper();
            vh.Init("~/template/front");    //模板路径

            #region 获取head.html中菜单项
            vh.Put("menu", this.Menu);
            vh.Put("submenu", this.SubMenu);
            vh.Put("parentmenu", this.ParentMenu);
            #endregion

            #region 工程中心简介
            string ec_title;
            string ec_content;
            string ec_date;
            Front_DataHandlerBLL.GetIntroBLL(out ec_title, out ec_content, out ec_date);

            vh.Put("ec_content",ec_content);
            #endregion

            #region 科研成果
            vh.Put("productlist", Front_DataHandlerBLL.GetIndexProductListBLL());
            #endregion

            vh.Display("index.html");
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