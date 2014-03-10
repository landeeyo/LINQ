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
            Console.WriteLine("Adding person...");
            Person p = new Person();
            p.firstname = "Adam"; 
            p.surname = "First";
            p.addressId = person.addressId;
            int personId = Accessor.InsertOrUpdatePerson(p);
            Console.WriteLine("Person id: ", p.id);
            Console.WriteLine("Updating person...");
            p.firstname = "Mark";
            Accessor.InsertOrUpdatePerson(p);
            Console.ReadLine();
        }
    }
}

