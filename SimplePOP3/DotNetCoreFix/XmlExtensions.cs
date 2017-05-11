using System;
using System.Collections.Generic;
using System.Text;

namespace System.Xml
{

    public static class XmlExtensions
    {

        public static string ReadString(this XmlReader rdr)
        {
            return rdr.Value;
        }

        // In.Net Core 1.0 and.Net Standard 1.3 SelectSingleNode is an extenstion method
        // To make it available again: PackageReference Include = "System.Xml.XPath.XmlDocument"
        //public static System.Xml.XmlNode SelectSingleNode(this XmlDocument doc, string xpath, XmlNamespaceManager ns)
        //{
        //    return null;
        //}

        public static void Load(this XmlDocument doc, string url)
        {
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                httpClient.DefaultRequestHeaders.UserAgent.Add(
                    new System.Net.Http.Headers.ProductInfoHeaderValue("MyClient", "1.0")
                );

                System.IO.Stream res = System.Threading.Tasks.Task.Run(
                    () => httpClient.GetStreamAsync(url)
                ).Result;

                doc.Load(res);
            } // End Using

        } // End Sub Load 


    } // End Class XmlExtensions 


} // End Namespace 
