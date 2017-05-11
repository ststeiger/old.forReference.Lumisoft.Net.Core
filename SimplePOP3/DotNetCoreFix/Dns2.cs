
using System;
using System.Collections.Generic;
using System.Text;


namespace System.Net
{


    public class Dns2
    {


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


    }


}
