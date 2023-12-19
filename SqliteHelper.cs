using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class SqliteHelper
{
    public static string connStr = ConfigurationManager.ConnectionStrings["ConnectStr"].ToString();
    public static string currConnStr;
    static string DBPath = string.Empty;

    public static void SetDBPath(string dbPath)
    {
        if (string.IsNullOrEmpty(dbPath))
        {
            throw new Exception("数据库路径不能为空");
        }
        DBPath = dbPath;
        currConnStr = String.Format(connStr, dbPath);
    }

    public static bool TestConnection()
    {
        if (string.IsNullOrEmpty(DBPath))
        {
            throw new Exception("数据库路径不能为空");
        }
        try
        {
            using (SQLiteConnection conn = new SQLiteConnection(currConnStr))
            {
                conn.Open();
            }
        }
        catch (SQLiteException)
        {
            return false;
        }
        return true;
    }

    public static object ExecuteScaler(string sql, params SQLiteParameter[] sqlParams)
    {
        if (string.IsNullOrEmpty(DBPath))
        {
            throw new Exception("数据库路径不能为空");
        }
        object o;
        using (SQLiteConnection conn = new SQLiteConnection(currConnStr))
        {
            using (SQLiteCommand command = new SQLiteCommand(sql, conn))
            {
                conn.Open();
                //conn.ChangePassword("zxcvb");
                if (sqlParams != null && sqlParams.Length > 0)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddRange(sqlParams);
                }
                o = command.ExecuteScalar();
            }
        }
        return o;
    }

    public static DataTable GetDataTable(string sql, params SQLiteParameter[] sqlParams)
    {
        if (string.IsNullOrEmpty(DBPath))
        {
            throw new Exception("数据库路径不能为空");
        }
        DataTable dt = new DataTable();
        using (SQLiteConnection conn = new SQLiteConnection(currConnStr))
        {
            using (SQLiteCommand command = new SQLiteCommand(sql, conn))
            {
                if (sqlParams != null)
                {
                    //conn.Open();
                    if (sqlParams != null && sqlParams.Length > 0)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddRange(sqlParams);
                    }
                }
                //本地DataSet和数据源之间的同步
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dt);
            }
        }
        return dt;
    }

    public static int ExecuteNonQuery(string sql, params SQLiteParameter[] sqlParams)
    {
        if (string.IsNullOrEmpty(DBPath))
        {
            throw new Exception("数据库路径不能为空");
        }
        int count = 0;
        using (SQLiteConnection conn = new SQLiteConnection(currConnStr))
        {
            using (SQLiteCommand command = new SQLiteCommand(sql, conn))
            {
                if (sqlParams != null)
                {
                    //conn.Open();
                    if (sqlParams != null && sqlParams.Length > 0)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddRange(sqlParams);
                    }
                }
                conn.Open();
                count = command.ExecuteNonQuery();
            }
        }
        return count;
    }

    public static SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] sqlParams)
    {
        if (string.IsNullOrEmpty(DBPath))
        {
            throw new Exception("数据库路径不能为空");
        }
        SQLiteConnection conn = new SQLiteConnection(currConnStr);
        SQLiteCommand command = new SQLiteCommand(sql, conn);
        try
        {
            conn.Open();
            if (sqlParams != null && sqlParams.Length > 0)
            {
                command.Parameters.Clear();
                command.Parameters.AddRange(sqlParams);
            }
            SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        catch (SQLiteException ex)
        {
            conn.Close();
            throw new Exception("执行查询出现异常", ex);
        }
    }

    public static bool ExecuteTrans(List<CommandInfo> comList)
    {
        if (string.IsNullOrEmpty(DBPath))
        {
            throw new Exception("数据库路径不能为空");
        }
        using (SQLiteConnection conn = new SQLiteConnection(currConnStr))
        {
            //启动一个事务
            conn.Open();
            SQLiteTransaction trans = conn.BeginTransaction();
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = conn;
            command.Transaction = trans;
            try
            {
                foreach (CommandInfo info in comList)
                {
                    command.CommandText = info.CommandText;
                    if (info.IsProc)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                    }
                    else
                    {
                        command.CommandType = CommandType.Text;
                    }
                    if (info.Parameters != null && info.Parameters.Length > 0)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddRange(info.Parameters);
                    }
                    command.ExecuteNonQuery();
                }
                trans.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                //操作异常 回滚事务
                trans.Rollback();
                throw new Exception("执行事务出现异常", ex);
            }
        }
    }
}
