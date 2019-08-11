using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xml_Converters.DbTools;
using Xml_Converters.Helpers;

namespace Xml_Converters.Xml
{
   public class MainXml
    {
        public void CreateXml(string strConn)
        { 
           
          
            SqlConnection connection = new SqlConnection(strConn);
          
            foreach (var item in Tables.ListTables(connection))
            { 
                XmlDocument document = new XmlDocument();
               
               
              var mroot= document.CreateElement(item);
               document.AppendChild(mroot);
               
               
               SqlCommand command=  Tables.SqlCommand(item, connection);
                SqlDataReader reader = Tables.Reader(command);
              
                var filds= Tables.GetFilds(reader);
                while (reader.Read())
                {
                    var root=  document.CreateElement(item+"s");
                    mroot.AppendChild(root);
                    foreach (var ite in filds)
                    {
                        XmlElement sroot = document.CreateElement(ite);
                        sroot.InnerText = reader[ite].ToString(); mroot.AppendChild(sroot);
                    }
                   
                }
                Tools.CreateFolder();
                document.Save($"../../XmlData/{item}.xml");
               
               
            }
           
           
           
        }
    }
}
