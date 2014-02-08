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

        #region Tables

        /// <summary>
        /// Gets person table
        /// </summary>
        /// <returns></returns>
        public static Table<Person> GetPersonTable()
        {
            return dc.GetTable<Person>();
        }

        /// <summary>
        /// Gets country table
        /// </summary>
        /// <returns></returns>
        public static Table<Country> GetCountryTable()
        {
            return dc.GetTable<Country>();
        }

        /// <summary>
        /// Gets address table
        /// </summary>
        /// <returns></returns>
        public static Table<Address> GetAddressTable()
        {
            return dc.GetTable<Address>();
        }

        /// <summary>
        /// Gets city table
        /// </summary>
        /// <returns></returns>
        public static Table<City> GetCityTable()
        {
            return dc.GetTable<City>();
        }

        #endregion

        #region Linq2SQL queries

        /// <summary>
        /// Gets person by surname
        /// </summary>
        /// <param name="surname">Surname</param>
        /// <returns>Person object</returns>
        public static Person GetPersonBySurname(string surname)
        {
            return (from p in GetPersonTable()
                    where (p.surname == surname)
                    select p).SingleOrDefault();
        }

        /// <summary>
        /// Gets person list by country
        /// </summary>
        /// <param name="country">Country name</param>
        /// <returns>List of person objects</returns>
        public static List<Person> GetPersonListByCountry(string country)
        {
            return (from person in dc.Persons
                    join address in dc.Addresses
                    on person.addressId equals address.id
                    join cntry in dc.Countries
                    on address.countryId equals cntry.id
                    where cntry.name == country
                    select person).ToList<Person>();
        }

        #endregion
    }
}
