using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace LINQtoSQL
{
    public static class ConsolePresentationHelper
    {
        /// <summary>
        /// Writes object info to console output using reclection
        /// </summary>
        /// <param name="o"></param>
        public static void WriteObject(object o)
        {
            if (o == null)
            {
                Console.WriteLine("Object is null");
            }
            Console.WriteLine("Object type:\t{0}", o.GetType());
            foreach (PropertyInfo p in o.GetType().GetProperties())
            {
                if (p.PropertyType == typeof(string) || p.PropertyType == typeof(int))
                {
                    Console.WriteLine("Property {0}:\t{1}", p.Name, p.GetValue(o, null));
                }
                else if (p.PropertyType.Name.Contains("Address") || p.PropertyType.Name.Contains("City") || p.PropertyType.Name.Contains("Country"))
                {
                    Console.WriteLine("Property {0} is subclass", p.Name);
                    var propertyValuee = p.GetValue(o, null);
                    WriteObject(propertyValuee);
                }
            }
        }

        /// <summary>
        /// Writes info of each element of object list using reflection
        /// </summary>
        /// <param name="collection"></param>
        public static void WriteCollection(IList collection)
        {
            foreach (object o in collection)
            {
                WriteObject(o);
            }
        }
    }
}
