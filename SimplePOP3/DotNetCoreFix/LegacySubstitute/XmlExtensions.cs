
// Copyright 2017-+infinity Stefan Steiger
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


// Simulates XmlReader.ReadString, XmlDocument.Load for .NET Core 



#define DOTNETCORE_LEGACY_COMPATIBILITY 
#if DOTNETCORE_LEGACY_COMPATIBILITY


namespace System.Xml
{


    internal static class XmlExtensions
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


#endif
