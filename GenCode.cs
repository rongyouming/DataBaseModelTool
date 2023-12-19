using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace DatabaseModelEntityTool
{
    public class GenCode
    {
        public DataTable tableNameDt = null;
        public Dictionary<string, DataTable> tableStructureDic = new Dictionary<string, DataTable>();
        public string exportPath = "";
        public bool isNeedUsingSystem = false;
        public bool isNeedCustomNameSpace = false;
        public string customNameSpace = "";

        public string MakeCode(string table_name)
        {
            StringBuilder genCodeBuilder = new StringBuilder();
            DataTable currDt = tableStructureDic[table_name];
            List<string> spaceStr = new List<string>();
            if (isNeedUsingSystem)
            {
                genCodeBuilder.Append("using System;\r\n\r\n");
            }
            if (isNeedCustomNameSpace && !string.IsNullOrEmpty(customNameSpace))
            {
                genCodeBuilder.Append($"namespace {customNameSpace}" + "\r\n{\r\n");
                spaceStr.Add("    ");
            }
            genCodeBuilder.Append($"{string.Join("",spaceStr)}public class {table_name}");
            genCodeBuilder.Append($"\r\n{string.Join("", spaceStr)}"+"{\r\n");
            int cnt = 0;
            if (currDt.Rows.Count>0)
            {
                spaceStr.Add("    ");
            }
            foreach (DataRow row in currDt.Rows)
            {
                genCodeBuilder.Append($"{string.Join("", spaceStr)}public {TransFormDbType2AttrType(row["type"].ToString())} {row["name"].ToString()} ");
                cnt++;
                if (cnt == currDt.Rows.Count)
                {
                    genCodeBuilder.Append("{ get; set; }\r\n");
                }
                else
                {
                    genCodeBuilder.Append("{ get; set; }\r\n\r\n");
                }
            }
            spaceStr.RemoveAt(spaceStr.Count - 1);
            genCodeBuilder.Append(string.Join("", spaceStr) + "}\r\n");
            if (isNeedCustomNameSpace && !string.IsNullOrEmpty(customNameSpace))
            {
                spaceStr.RemoveAt(spaceStr.Count - 1);
                genCodeBuilder.Append(string.Join("", spaceStr)+"}");
            }
            string finalCode = genCodeBuilder.ToString();

            return finalCode;
        }

        public bool MakeAndExport(string table_name)
        {
            string code = MakeCode(table_name);
            try
            {
                using (StreamWriter sw = new StreamWriter($"{this.exportPath}\\{table_name}.cs"))
                {
                    sw.Write(code);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public bool MakeAndExportAll()
        {
            try
            {
                foreach (var item in tableStructureDic)
                {
                    string table_name = item.Key;
                    MakeAndExport(table_name);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public string MakeAllCode()
        {
            string code = "";
            foreach (var item in tableStructureDic)
            {
                string table_name = item.Key;
                code += MakeCode(table_name);
                code += "\r\n";
            }
            return code;
        }

        private static string TransFormDbType2AttrType(string sqliteDbType)
        {
            int len = sqliteDbType.IndexOf("(");
            string src = sqliteDbType.ToLower().Substring(0, len > -1 ? len : sqliteDbType.Length);
            string dst;
            switch (src)
            {
                case "integer":
                    dst = "int";
                    break;
                case "varchar":
                case "nvarchar":
                case "text":
                    dst = "string";
                    break;
                case "decimal":
                    dst = "double";
                    break;
                case "datetime":
                    dst = "DateTime";
                    break;
                default:
                    dst = "";
                    break;
            }
            return dst;
        }
    }
}
