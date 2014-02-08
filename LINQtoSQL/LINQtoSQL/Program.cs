using System;
using LINQtoSQL.DAL;

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
            //List<Person> people = Accessor.GetPersonListByCountry("United Kingdom");
            Console.ReadLine();
        }
    }
}

