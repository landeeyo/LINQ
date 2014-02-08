using System;
using LINQtoSQL.DAL;
using System.Collections.Generic;

namespace LINQtoSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ2SQL demo");
            Console.WriteLine("People with surname Joyce:");
            var person = Accessor.GetPersonBySurname("Joyce");
            ConsolePresentationHelper.WriteObject(person);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("All people from UK: ");
            List<Person> people = Accessor.GetPersonListByCountry("United Kingdom");
            ConsolePresentationHelper.WriteCollection(people);
            Console.ReadLine();
        }
    }
}

