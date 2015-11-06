using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class SqlStrClass
{
    public SqlStrClass()
    {

    }

    #region menutb 菜单列表
    public static string SelectAllFromMenutb()
    {
        return string.Format("select* from menutb");
    }
    #endregion

    #region introtb 工程中心简介表
    public static string SelectAllFromIntrotb()
    {
        return string.Format("select * from introtb");
    }
    #endregion

    #region producttb 科研成果表

    public static string SelectIndexListFromProducttb()
    {
        return string.Format("select product_id,product_title,product_image from producttb order by product_id ASC");
    }

    public static string SelectByIdFromProducttb(int id)
    {
        return string.Format("select * from (select * from producttb where product_id={0}) AS A inner join productsorttb on A.product_sortid = productsorttb.productsort_id", id);
    }
    #endregion
}
