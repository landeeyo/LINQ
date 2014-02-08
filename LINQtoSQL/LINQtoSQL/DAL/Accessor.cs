using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace LINQtoSQL.DAL
{
    /// <summary>
    /// Wrapper for linq to sql calls
    /// </summary>
    public class Accessor
    {
        private static Linq2SQLClassesDataContext dc = new Linq2SQLClassesDataContext();

        /// <summary>
        /// Gets person table
        /// </summary>
        /// <returns></returns>
        public static Table<Person> GetPersonTable()
        {
            return dc.GetTable<Person>();
        }

        /// <summary>
        /// Gets person by surname
        /// </summary>
        /// <param name="surname"></param>
        /// <returns></returns>
        public static Person GetPersonBySurname(string surname)
        {
            return (from p in GetPersonTable()
                    where (p.surname == surname)
                    select p).SingleOrDefault();
        }

       
    }
}
