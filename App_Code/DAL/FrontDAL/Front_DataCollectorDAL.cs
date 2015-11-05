using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// 获取原始数据
/// </summary>
public class Front_DataCollectorDAL
{
    /// <summary>
    /// 获取菜单列表项
    /// </summary>
    /// <returns></returns>
    public static DataTable GetMenuItemDAL()
    {
        string sql = SqlStrClass.SelectAllFromMenutb();
        DataBaseAccess dba = new DataBaseAccess();
        return dba.RunSQLStringWithSQLDataTable(sql);
    }

    /// <summary>
    /// 获取工程中心介绍
    /// </summary>
    /// <returns></returns>
    public static DataTable GetIntroDAL()
    {
        string sql = SqlStrClass.SelectAllFromIntrotb();
        DataBaseAccess dba = new DataBaseAccess();
        return dba.RunSQLStringWithSQLDataTable(sql);
    }

    /// <summary>
    /// 获取科研成果列表
    /// </summary>
    /// <returns></returns>
    public static DataTable GetIndexProductListDAL()
    {
        string sql = SqlStrClass.SelectIndexListFromProducttb();
        DataBaseAccess dba = new DataBaseAccess();
        DataTable dt = dba.RunSQLStringWithSQLDataTable(sql);
        return dt;
    }

    /// <summary>
    /// 获取产品详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static DataTable GetProductInfoDAL(int id)
    {
        string sql = SqlStrClass.SelectByIdFromProducttb(id);
        DataBaseAccess dba = new DataBaseAccess();
        return dba.RunSQLStringWithSQLDataTable(sql);
    }
}
