using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Xml_Converters.Helpers
{
    public class Tools
    {

        public static void  CreateFolder()
        {
          
            if (!Directory.Exists("../../XmlData"))
            {
                Directory.CreateDirectory("../../XmlData");
            }
        }
    }
}
