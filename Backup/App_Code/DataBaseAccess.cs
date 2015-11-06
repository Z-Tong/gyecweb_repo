using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Data.OleDb;
/// <summary>
/// 数据库访问的类
/// </summary>
public class DataBaseAccess
{
    #region  成员变量
    /// <summary>
    /// 数据连接字符串
    /// </summary>
    private string StrConnectionString;
    /// <summary>
    /// 数据库连接对象
    /// </summary>

    protected OleDbConnection Connection;

    private OleDbDataAdapter adapter = new OleDbDataAdapter();
    #endregion

    #region 构造方法
    /// <summary>
    /// 无参数的构造 
    /// </summary>
    public DataBaseAccess()
    {
        StrConnectionString = System.Configuration.ConfigurationManager.AppSettings["conString"].ToString();//连接字符串

        Connection = new OleDbConnection(StrConnectionString);
    }
    #endregion

    #region 连接管理
    /// <summary>
    /// 打开连接
    /// </summary>
    public void OpenConnection()
    {
        try
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
        }
        catch (Exception ex)
        {
            Connection.Close();
            throw ex;
        }
    }
    /// <summary>
    /// 关闭连接
    /// </summary>
    public void CloseConnection()
    {
        try
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }
        catch (Exception ex)
        {

        }
    }
    #endregion

    ///// <summary>
    ///// 运行SQL语句，返回影响行数
    ///// </summary>
    ///// <param name="sqlString">SQl语句</param>
    ///// <returns>影响行数</returns>
    public int RunSQLStringForUpdate(string sqlString)
    {
        Connection = new OleDbConnection(StrConnectionString);
        int RowAffected = 0;
        try
        {
            Connection.Open();
            OleDbCommand command = new OleDbCommand(sqlString, Connection);
            RowAffected = command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
        }
        finally
        {
            Connection.Close();
        }
        return RowAffected;
    }

    /// <summary>
    /// 执行SQL语句，返回DataTable对象
    /// </summary>
    /// <param name="sqlString">SQL语句</param>
    /// <returns>DataTable 对象</returns>
    public DataTable RunSQLStringWithSQLDataTable(string sqlString)
    {
        //连接对象初始化
        Connection = new OleDbConnection(StrConnectionString);
        DataSet dst = new DataSet();
        DataTable dt = new DataTable();
        try
        {
            //打开连接
            Connection.Open();
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
            //执行SQL查询语句
            DataAdapter.SelectCommand = new OleDbCommand(sqlString, Connection);
            //填充数据集
            DataAdapter.Fill(dst);
            dt = dst.Tables[0];
        }
        catch (Exception e)
        {
        }
        finally
        {
            //关闭连接
            Connection.Close();
        }
        return dt;
    }



}
