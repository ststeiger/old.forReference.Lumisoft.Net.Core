
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


// Simulates GetHostEntry, GetHostAddresses, BeginGetHostAddresses, EndGetHostAddresses 
// for .NET Core 


#define DOTNETCORE_LEGACY_COMPATIBILITY 


namespace System.Net
{


    public class Dns2
    {

#if DOTNETCORE_LEGACY_COMPATIBILITY


        public static IAsyncResult BeginGetHostAddresses(string hostNameOrAddress
            , AsyncCallback requestCallback, object state)
        {
            return System.Net.Dns.GetHostAddressesAsync(hostNameOrAddress).AsApm(requestCallback, state);
        }


        public static System.Net.IPAddress[] EndGetHostAddresses(IAsyncResult asyncResult)
        {
            return ((System.Threading.Tasks.Task<System.Net.IPAddress[]>)asyncResult).Result;
        }


        public static IPHostEntry GetHostEntry(string host)
        {
            // System.Net.Dns.GetHostEntry(host);
            return System.Threading.Tasks.Task.Run(() => System.Net.Dns.GetHostEntryAsync(host)).Result;
        }


        public static IPAddress[] GetHostAddresses(string host)
        {
            // System.Net.Dns.GetHostAddresses(host);
            return System.Threading.Tasks.Task.Run(() => System.Net.Dns.GetHostAddressesAsync(host)).Result;
        }
#else
        
         public static System.IAsyncResult BeginGetHostAddresses(string hostNameOrAddress
         , System.AsyncCallback requestCallback, object state)
        {
            return System.Net.Dns.BeginGetHostAddresses(hostNameOrAddress, requestCallback, state);
        }

        public static System.Net.IPAddress[] EndGetHostAddresses(System.IAsyncResult asyncResult)
        {
            return System.Net.Dns.EndGetHostAddresses(asyncResult);
        }

        public static System.Net.IPHostEntry GetHostEntry(string host)
        {
            return System.Net.Dns.GetHostEntry(host);
        }

        public static System.Net.IPAddress[] GetHostAddresses(string host)
        {
            return System.Net.Dns.GetHostAddresses(host);
        }

#endif


    }


}
