using System;

namespace SimplePOP3
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] ba = System.Text.Encoding.UTF8.GetBytes("Hello world");
            byte[] foo = LumiSoft.Net._MD444.MyHash(ba);
            
            System.Console.WriteLine(foo);
            byte[] bar = new LumiSoft.Net._MD444().ComputeHash(ba);
            System.Console.WriteLine(bar);

            var md5 = new LumiSoft.Net.MD4Managed();
            byte[] foobar = md5.ComputeHash(ba);
            System.Console.WriteLine(foobar);


            Console.WriteLine("Hello World!");
        }
    }
}