using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// 对DAL层获取的数据进行加工处理
/// </summary>
public class Front_DataHandlerBLL
{

    /// <summary>
    /// 菜单列表项
    /// </summary>
    /// <param name="menutb">level=0的一级菜单</param>
    /// <param name="subMenutb">level=1的二级菜单</param>
    /// <param name="parentMenutb">isparent=1的具有二级菜单的一级菜单</param>
    public static void GetMenuItemBLL(out DataTable menutb,out DataTable subMenutb,out DataTable parentMenutb)
    {
        DataTable dt = Front_DataCollectorDAL.GetMenuItemDAL();
        menutb = dt.Clone();//存放level=0的1层菜单
        subMenutb = dt.Clone();//存放level=1的子菜单
        parentMenutb = dt.Clone();//存放isparent=1的1层菜单
        if (dt!=null && dt.Rows.Count>0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (dr["menu_level"].ToString()=="0")
                {
                    menutb.ImportRow(dr);
                    if (dr["menu_isparent"].ToString()=="1")
                    {
                        parentMenutb.ImportRow(dr);
                    }
                }
                else if(dr["menu_level"].ToString()=="1")
                {
                    subMenutb.ImportRow(dr);
                }
            }
        }
    }

    /// <summary>
    ///  工程中心简介
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="content">内容</param>
    /// <param name="date">日期</param>
    public static void GetIntroBLL(out string title,out string content,out string date)
    {
        DataTable dt = Front_DataCollectorDAL.GetIntroDAL();
        if (dt!=null && dt.Rows.Count>0)
        {
            title = dt.Rows[0]["intro_title"].ToString();
            content = dt.Rows[0]["intro_content"].ToString();
            date = dt.Rows[0]["intro_date"].ToString();
        }
        else
        {
            title = "";
            content = "";
            date = "";
        }
    }

    /// <summary>
    /// 科研成果列表
    /// </summary>
    /// <returns></returns>
    public static DataTable GetIndexProductListBLL()
    {
        return Front_DataCollectorDAL.GetIndexProductListDAL();
    }

    /// <summary>
    /// 获取产品详情
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ptitle"></param>
    /// <param name="pinfo"></param>
    /// <param name="pdes"></param>
    /// <param name="pimage"></param>
    /// <param name="psort"></param>
    public static void GetProductInfoBLL(int id, out string ptitle,out string pinfo,out string pdes,out string pimage,out string psort)
    {
        DataTable dt = Front_DataCollectorDAL.GetProductInfoDAL(id);
        if (dt!=null && dt.Rows.Count>0)
        {
            ptitle = dt.Rows[0]["product_title"].ToString();
            pinfo = dt.Rows[0]["product_info"].ToString();
            pdes = dt.Rows[0]["product_des"].ToString();
            pimage = dt.Rows[0]["product_image"].ToString();
            psort = dt.Rows[0]["productsort_name"].ToString();
        }
        else
        {
            ptitle = "";
            pinfo = "";
            pdes = "";
            pimage="";
            psort = "";
        }

    }
}
