using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

public class CommandInfo
{
    public string CommandText;//sql or procname
    public SQLiteParameter[] Parameters = null;//parameter list
    public bool IsProc = false;

    public CommandInfo()
    {

    }

    public CommandInfo(string comText, bool isProc)
    {
        this.CommandText = comText;
        this.IsProc = isProc;
    }

    public CommandInfo(string comText, bool isProc, params SQLiteParameter[] para)
    {
        this.CommandText = comText;
        this.IsProc = isProc;
        this.Parameters = para;
    }
}
