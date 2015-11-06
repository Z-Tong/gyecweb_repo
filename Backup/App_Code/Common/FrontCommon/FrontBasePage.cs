using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


public class FrontBasePage
{
    /// <summary>
    /// level=0的一级菜单
    /// </summary>
    private DataTable menu;
    public DataTable Menu
    {
        get { return menu; }
        set { menu = value; }
    }

    /// <summary>
    /// level=1的二级菜单
    /// </summary>
    private DataTable subMenu;
    public DataTable SubMenu
    {
        get { return subMenu; }
        set { subMenu = value; }
    }

    /// <summary>
    /// 具有二级菜单的一级菜单
    /// </summary>
    private DataTable parentMenu;
    public DataTable ParentMenu
    {
        get { return parentMenu; }
        set { parentMenu = value; }
    }

    public FrontBasePage()
    {
        Front_DataHandlerBLL.GetMenuItemBLL(out menu, out subMenu, out parentMenu);
    }
}
