
namespace SimplePOP3
{


    public class Program
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

            System.Reflection.TypeInfo ti = null;
            System.Type t = null;

            System.Console.WriteLine(ti);
            System.Console.WriteLine(t);

            System.Console.WriteLine(System.Environment.NewLine);
            System.Console.WriteLine(" --- Press any key to continue --- ");
            System.Console.ReadKey();
        } // End Sub Main 


    } // End Class Program


} // End Namespace SimplePOP3 
