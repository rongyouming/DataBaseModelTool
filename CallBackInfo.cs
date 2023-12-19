using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModelEntityTool
{
    public class CallBackInfo
    {
        public string exportPath;
        public bool isNeedUsingSystem;
        public bool isNeedNameSpace;
        public string customNameSpace;

        public CallBackInfo(string path,bool isNeed,bool needNameSpace=false,string spaceName="")
        {
            this.exportPath = path;
            this.isNeedUsingSystem = isNeed;
            this.isNeedNameSpace = needNameSpace;
            this.customNameSpace = spaceName;
        }
    }
}
