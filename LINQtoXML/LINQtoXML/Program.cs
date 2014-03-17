using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQtoXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLFacade xf = new XMLFacade();
            Console.WriteLine(xf.GetExampleXML().ToString());
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine(xf.GetUserByCityName("New York").ToString());
            Console.ReadLine();
            var xml = xf.GetExampleXML();
            xf.DeleteUserByName(xml, "Steve", "Jobs");
            Console.WriteLine();
            Console.WriteLine(xml.ToString());
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
