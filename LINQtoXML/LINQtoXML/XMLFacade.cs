using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LINQtoXML
{
    public class XMLFacade
    {
        #region Create

        /// <summary>
        /// Creates basic XML
        /// </summary>
        /// <returns></returns>
        public XElement GetExampleXML()
        {
            XElement users =
                new XElement("Users",
                    new XElement("User",
                        new XElement("Firstname", "Mark"),
                        new XElement("Surname", "Zuckerberg"),
                        new XElement("Phone", "206-555-0144",
                            new XAttribute("Type", "Home")),
                        new XElement("phone", "425-555-0145",
                            new XAttribute("Type", "Work")),
                        new XElement("Address",
                            new XElement("Street", "123 Main St"),
                            new XElement("City", "Mercer Island"),
                            new XElement("State", "WA"),
                            new XElement("Postal", "68042")
                        )
                    ),
                    new XElement("User",
                        new XElement("Firstname", "Bill"),
                        new XElement("Surname", "Gates"),
                        new XElement("Phone", "555-666-1234",
                            new XAttribute("Type", "Home")),
                        new XElement("phone", "654-584-98745",
                            new XAttribute("Type", "Work")),
                        new XElement("Address",
                            new XElement("Street", "Wall St"),
                            new XElement("City", "New York"),
                            new XElement("State", "NY"),
                            new XElement("Postal", "66662")
                        )
                    ),
                    new XElement("User",
                        new XElement("Firstname", "Steve"),
                        new XElement("Surname", "Jobs"),
                        new XElement("Phone", "846-113-6548",
                            new XAttribute("Type", "Home")),
                        new XElement("phone", "456-584-98874",
                            new XAttribute("Type", "Work")),
                        new XElement("Address",
                            new XElement("Street", "Oregon Expy"),
                            new XElement("City", "Palo Alto"),
                            new XElement("State", "CA"),
                            new XElement("Postal", "12384")
                        )
                    )
                );

            return users;
        }

        /// <summary>
        /// Returns XElement XML with structure given in XMLSchema
        /// </summary>
        /// <returns></returns>
        public XElement CreateXMLStructureFromXMLSchema()
        {
            //TODO
            throw new NotImplementedException();
        }

        #endregion

        #region Read

        public XElement GetUserByCityName(string cityName)
        {
            var queryResult = (from item in GetExampleXML().Descendants("User")
                               where (string)item.Element("Address").Element("City") == cityName
                               select item);
            XElement result = new XElement(new XElement("Users"));
            foreach (var i in queryResult)
            {
                result.Add(i);
            }
            return result;
        }

        #endregion

        #region Update

        public XElement UpdateUserByName(XElement oldUserData, XElement newUserData)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Delete

        public void DeleteUserByName(XElement handle, string firstname, string surname)
        {         
            var queryResult = (from item in handle.Descendants("User")
                               where ((string)item.Element("Firstname") == firstname && (string)item.Element("Surname") == surname)
                               select item);
            queryResult.Remove();
        }

        #endregion
    }
}

