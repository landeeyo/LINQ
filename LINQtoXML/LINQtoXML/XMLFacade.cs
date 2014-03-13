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
                        new XElement("Firstname","Mark"),
                        new XElement("Surname","Zuckerberg"),
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
                        new XElement("Firstname","Bill"),
                        new XElement("Surname","Gates"),
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
            throw new NotImplementedException();
        }

        #endregion

        #region Update

        public XElement UpdateUserByName(XElement oldUserData, XElement newUserData)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Delete

        public void DeleteUserByName(string firstname, string surname)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
