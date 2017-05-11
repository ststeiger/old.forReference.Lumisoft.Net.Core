
using System.Net.Sockets;
using System.Threading.Tasks;



namespace System
{


    public class SerializableAttribute : System.Attribute
    {

    }


    static class NetExtension
    {


        // https://msdn.microsoft.com/en-us/library/hh873178(v=vs.110).aspx
        public static IAsyncResult AsApm(this Task task,
                                   AsyncCallback callback,
                                   object state)
        {
            if (task == null)
                throw new ArgumentNullException("task");

            var tcs = new TaskCompletionSource<bool>(state);

            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                    tcs.TrySetException(t.Exception.InnerExceptions);
                else if (t.IsCanceled)
                    tcs.TrySetCanceled();
                else tcs.TrySetResult(true);

                if (callback != null)
                    callback(tcs.Task);
            }, TaskScheduler.Default);
            return tcs.Task;
        }

        public static IAsyncResult AsApm<T>(this Task<T> task,
                                    AsyncCallback callback,
                                    object state)
        {
            if (task == null)
                throw new ArgumentNullException("task");

            var tcs = new TaskCompletionSource<T>(state);
            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                    tcs.TrySetException(t.Exception.InnerExceptions);
                else if (t.IsCanceled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(t.Result);

                if (callback != null)
                    callback(tcs.Task);
            }, TaskScheduler.Default);
            return tcs.Task;
        }

        public static void Connect(this UdpClient udpClient, System.Net.IPEndPoint endPoint)
        {
            // Just ignore it, new in SendAsync
        }

        public static void Connect(this UdpClient udpClient, System.Net.IPAddress address, int port)
        {
            // Just ignore it, new in SendAsync
        }


        public static int Send(this UdpClient udpClient, byte[] datagram, int bytes, Net.IPEndPoint endPoint)
        {
            return Task.Run(() => udpClient.SendAsync(datagram, bytes, endPoint)).Result;
        }


        public static byte[] Receive(this UdpClient udpClient, ref System.Net.IPEndPoint ipe)
        {
            return Task.Run(() => udpClient.ReceiveAsync() ).Result.Buffer;
        }


        //public async static Task<int> SendAsync(this UdpClient udpClient, byte[] datagram, int bytes)
        //{
        //    return 0;
        //}


        public static IAsyncResult BeginConnect(this TcpClient tcpClient, System.Net.IPAddress address, int port, AsyncCallback requestCallback, object state)
        {
            return tcpClient.ConnectAsync(address, port).AsApm(requestCallback, state);
        }


        public static bool EndConnect(this TcpClient tcpClient, IAsyncResult asyncResult)
        {
            return ((Task<bool>)asyncResult).Result;
        }


        public static bool WaitOne(this System.Threading.WaitHandle wh, TimeSpan timeout, bool exitContext)
        {
            return wh.WaitOne(timeout);
        }


        public static void Close(this UdpClient udpClient)
        {
        }


        public static void Close(this TcpClient tcpClient)
        {
        }


        public static void Close(this System.Threading.WaitHandle handle)
        {
        }


        public static void Close(this System.IO.Stream stream)
        {
        }


        public static IAsyncResult BeginRead(this System.IO.Stream stream
            , byte[] buffer, int offset, int count, AsyncCallback cb, object state
            )
        {
            return stream.ReadAsync(buffer, offset, count).AsApm(cb, state);
        }

        public static int EndRead(this System.IO.Stream stream
           , IAsyncResult asyncResult)
        {
            return ((Task<int>)asyncResult).Result;
        }


        public static IAsyncResult BeginWrite(this System.IO.Stream stream
            , byte[] buffer, int offset, int count, AsyncCallback cb, object state
            )
        {
            return stream.WriteAsync(buffer, offset, count).AsApm(cb, state);
        }

        public static void EndWrite(this System.IO.Stream stream
           , IAsyncResult asyncResult)
        {
            ((Task)asyncResult).Wait();
        }


        public static IAsyncResult BeginConnect(this System.Net.Sockets.Socket socket
            , System.Net.IPEndPoint remoteEP
           , AsyncCallback callback, object state)
        {
            return socket.ConnectAsync(remoteEP).AsApm(callback, state);
        }


        public static void EndConnect(this System.Net.Sockets.Socket socket
           , IAsyncResult asyncResult)
        {
            ((Task)asyncResult).Wait();
        }



        public static IAsyncResult BeginAccept(this System.Net.Sockets.Socket socket
           , AsyncCallback callback, object state)
        {
            return socket.AcceptAsync().AsApm(callback, state);
        }

        public static System.Net.Sockets.Socket EndAccept(this System.Net.Sockets.Socket socket
          , IAsyncResult asyncResult)
        {
            return ((Task<System.Net.Sockets.Socket>)asyncResult).Result;
        }


        public static ArraySegment<T> ToArraySegment<T>(this T[] array, int offset = -1, int count = -1)
        {
            if (offset == -1)
            {
                offset = 0;
            }
            if (count == -1)
            {
                count = array.Length;
            }
            return new ArraySegment<T>(array, offset, count);
        }


        public static IAsyncResult BeginReceiveFrom(this System.Net.Sockets.Socket socket
            ,byte[] buffer, int offset, int size,System.Net.Sockets.SocketFlags socketFlags,
            ref System.Net.EndPoint remoteEP
           , AsyncCallback callback, object state)
        {
            ArraySegment<byte> buffer2 = buffer.ToArraySegment(offset, size);
            return socket.ReceiveFromAsync(buffer2, socketFlags, remoteEP).AsApm(callback, state);
        }

        public static int EndReceiveFrom(this System.Net.Sockets.Socket socket
          , IAsyncResult asyncResult, ref System.Net.EndPoint endPoint)
        {
            return ((Task<int>)asyncResult).Result;
        }



        public static void Close(this System.Net.Sockets.Socket socket)
        {
        }


        public static void Close(this System.Net.Sockets.NetworkStream stream)
        {
        }






        public static IAsyncResult BeginAuthenticateAsClient(this System.Net.Security.SslStream stream
            , string targetHost
           , AsyncCallback callback, object state)
        {
            return stream.AuthenticateAsClientAsync(targetHost).AsApm(callback, state);
        }

        public static void EndAuthenticateAsClient(this System.Net.Security.SslStream stream
           , IAsyncResult asyncResult)
        {
            ((Task)asyncResult).Wait();
        }

        public static void AuthenticateAsClient(this System.Net.Security.SslStream stream
           , string targetHost)
        {
            Task.Run(() => stream.AuthenticateAsClientAsync(targetHost)).Wait();
        }


        public static IAsyncResult BeginAuthenticateAsServer(this System.Net.Security.SslStream stream
            , System.Security.Cryptography.X509Certificates.X509Certificate serverCertificate
            , AsyncCallback callback, object state
        )
        {
            return stream.AuthenticateAsServerAsync(serverCertificate).AsApm(callback, state);
        }


        public static void EndAuthenticateAsServer(this System.Net.Security.SslStream stream
          , IAsyncResult asyncResult)
        {
            ((Task)asyncResult).Wait();
        }


        public static void AuthenticateAsServer(this System.Net.Security.SslStream stream
           , System.Security.Cryptography.X509Certificates.X509Certificate serverCertificate)
        {
            Task.Run(() => stream.AuthenticateAsServerAsync(serverCertificate)).Wait();
        }


    }


}
