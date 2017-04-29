using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpers
{



    public class Helpers
    {

        public struct userDataStruct
        {
            public string userName;
            public string userId;
            public string ServiceUrl;
            public string botName;
            public string botId;
        }
        public static List<userDataStruct> listaAdresow = new List<userDataStruct>();
    }
}