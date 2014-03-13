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
            Console.ReadLine();
        }
    }
}
