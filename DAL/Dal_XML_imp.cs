using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using DS;
namespace DAL
{

    public class DAL_XML_Imp //: Idal
    {

        //        static uint nextContractID;
        //        static uint nextSpecID;

        static DAL_XML_Imp()
        {

            //setNextID(XML_Source.contractRoot, out nextContractID, 100000);
            // setNextID(XML_Source.specializationRoot, out nextSpecID, 100000);
        }

        //        static void setNextID(XElement XRoot, out uint nextParam, uint defaultNext)
        //        {
        //            if (XRoot.HasElements == false) // no children nodes
        //            {
        //                nextParam = defaultNext;
        //            }
        //            else
        //                nextParam = (from node in XRoot.Elements()
        //                             where node.Attributes("ID").Any()
        //                             select (uint)node.Attribute("ID")).Max() + 1;
        //        }

        // check if element already exists in XML file
        XElement ElementIfExists(XElement root, XElement element)
            => (from spec in root.Elements()
                where spec.Attribute("ID").Value == element.Attribute("ID").Value
                select spec).FirstOrDefault();

        // overloaded method finds element based on ID
        XElement ElementIfExists(XElement root, int ID)
        {
            try
            {
                return (from spec in root.Elements()
                 where int.Parse(spec.Attribute("ID").Value) == ID
                 select spec).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        void removeElementFromXML(XElement XRoot, XElement element)
        {
            XElement foundElement = ElementIfExists(XRoot, element);
            if (foundElement != null) // element found
            {
                foundElement.Remove();
                //XML_Source.SaveXML<Specialization>();
            }
            else
                throw new Exception("element " + element.Attribute("ID") + " not found in XML");
        }

        void removeElementFromXML(XElement XRoot, int ID)
        {
            XElement foundElement = ElementIfExists(XRoot, ID);
            if (foundElement != null) // element found
            {
                foundElement.Remove();
                XML_Source.SaveXML<Mother>();
                //XML_Source.SaveXML<Specialization>();
            }
            else
                throw new Exception("element " + ID + " not found in XML");
        }
        public TimeSpan[] GetArray(XElement a)
        {
            return (from c in a.Elements("Time")
                    select new TimeSpan(int.Parse(c.Element("Hours").Value), int.Parse(c.Element("Minutes").Value), int.Parse(c.Element("Seconds").Value))).ToArray();
            //return new TimeSpan[10];
        }





        //All the function connected to Mother XML
        #region Mother
        XElement createMotherXElement(Mother m)//converter from Mother to xelement
            => (new XElement("mother", new XAttribute("ID", m.ID),
                  new XElement("firstName", m.Firstname),
                  new XElement("lastName", m.Lastname),
                  new XElement("phoneNumber", m.Phonenumber),
                  new XElement("Address", m.Adress),
                  new XElement("surrounding_adress", m.surrounding_adress),
                  new XElement("Phonenumber", m.Phonenumber),
                  new XElement("Paymentmethode", m.Paymentmethode),
                  new XElement("nanny_required", (from item in m.nanny_required select new XElement("Days", item))),
                  new XElement("daily_Nanny_required", (from a in m.daily_Nanny_required select new XElement("days",
                         (from b in a select new XElement("Time", new XElement("Hours", ((TimeSpan)(b)).Hours),
                                                                  new XElement("Minutes", ((TimeSpan)(b)).Minutes),
                                                                  new XElement("Seconds", ((TimeSpan)(b)).Seconds)))))),
                   new XElement("Comment", m.Comment)
                 ));
        public void AddMother(Mother m)
        {
            if (ElementIfExists(XML_Source.motherRoot, m.ID) != null)
            {
                throw new Exception(m.ID + " already exists in file");
            }

            XML_Source.motherRoot.Add(createMotherXElement(m));
            XML_Source.SaveXML<Mother>();
        }
        public void RemoveMother(int ID)
            => removeElementFromXML(XML_Source.motherRoot, ID);

        public void UpdateMother(Mother mother)
        {
            XElement foundElement = ElementIfExists(XML_Source.motherRoot, (int)mother.ID);
            if (foundElement == null)
                throw new Exception(mother.ID + " does not exist in XML");
            removeElementFromXML(XML_Source.motherRoot, (int)foundElement.Attribute("ID"));
            AddMother(mother);
        }
        public Mother GetMother(int id)
        {
            //XElement m = ElementIfExists(XML_Source.motherRoot, id);
            //XElement m = createMotherXElement(new Mother(1, "Dana", "Anilewitch", "0798512565", "jerusalem", "jerusalem", new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] { new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, "comment", MyEnum.Paymentmethode.hourly));
            XElement m = ElementIfExists(XML_Source.motherRoot, id);
            if (m == null)
                return null;
            return new Mother()
            {

                ID = (int)m.Attribute("ID"),
                Firstname = (string)m.Element("firstName"),
                Lastname = (string)m.Element("lastName"),
                Phonenumber = (string)m.Element("Phonenumber"),
                Adress = (string)m.Element("Address"),
                surrounding_adress = (string)m.Element("surrounding_adress"),
                Paymentmethode = (MyEnum.Paymentmethode)Enum.Parse(typeof(MyEnum.Paymentmethode), m.Element("Paymentmethode").Value.ToString()),
                nanny_required = (from a in m.Element("nanny_required").Elements("Days") select Boolean.Parse(a.Value)).ToArray(),
                daily_Nanny_required = (from b in m.Element("daily_Nanny_required").Elements("days")
                                             select (GetArray(b))).ToArray(),
            Comment = (string)m.Element("Comment")
            };
        }
        
        
        public List<Mother> getMotherList()
        {
            try
            {
                return (from m in XML_Source.motherRoot.Elements()
                        let currentMother = new Mother()
                        {
                            Firstname = (string)m.Element("firstName").Value,
                            Lastname = (string)m.Element("lastName").Value
                        }
                        select GetMother( int.Parse(m.Attribute("ID").Value))).ToList();
            }
            catch
            {
                throw new Exception("getmotherList() exception");
            }
        }
        #endregion Mother

        //All the function connected to Nanny XML
        #region Nanny
        XElement createNannyXElement(Nanny n)//converter from Nanny to xelement
            => (new XElement("Nanny", new XAttribute("ID", n.ID),
                  new XElement("firstName", n.first_name),
                  new XElement("lastName", n.last_name),
                  new XElement("Birthdate", new XElement("Day", ((DateTime)(n.Birthdate)).Day),
                                            new XElement("Month", ((DateTime)(n.Birthdate)).Month),
                                            new XElement("Year", ((DateTime)(n.Birthdate)).Year)),
                  new XElement("PhoneNumber", n.PhoneNumber),
                  new XElement("Address", n.address),
                  new XElement("elevatorExists", n.elevatorExists),
                  new XElement("Floor", n.Floor),
                  new XElement("experience", n.experience),
                  new XElement("Max_number_kids", n.Max_number_kids),
                  new XElement("Min_age", n.Min_age),
                  new XElement("Max_age", n.Max_age),
                  new XElement("Possible_Hourly_rate", n.Possible_Hourly_rate),
                  new XElement("Hourly_rate", n.Hourly_rate),
                  new XElement("Monthly_rate", n.Monthly_rate),
                  new XElement("Working_days", (from item in n.Working_days select new XElement("Days", item))),
                  new XElement("Daily_Working_hours", (from a in (n.Daily_Working_hours)
                                                       select new XElement("days",(from b in a
                                                select new XElement("Time", new XElement("Hours", ((TimeSpan)(b)).Hours),
                                                      new XElement("Minutes", ((TimeSpan)(b)).Minutes),
                                                      new XElement("Seconds", ((TimeSpan)(b)).Seconds)))))),
                   new XElement("Vacation_days", n.Vacation_days),
                  new XElement("Recommendations", n.Recommendations),
                  new XElement("Additional_Info", n.Additional_Info),
                  new XElement("kidsCount", n.kidsCount),
                  new XElement("fideback", n.fideback)
                 ));
        public void AddNanny(Nanny m)
        {
            if (ElementIfExists(XML_Source.nannyRoot, m.ID) != null)
            {
                throw new Exception(m.ID + " already exists in file");
            }

            XML_Source.nannyRoot.Add(createNannyXElement(m));
            XML_Source.SaveXML<Nanny>();
        }
        public void RemoveNanny(int ID)
            => removeElementFromXML(XML_Source.nannyRoot, ID);

        public void UpdateNanny(Nanny Nanny)
        {
            XElement foundElement = ElementIfExists(XML_Source.nannyRoot, (int)Nanny.ID);
            if (foundElement == null)
                throw new Exception(Nanny.ID + " does not exist in XML");
            removeElementFromXML(XML_Source.nannyRoot, (int)foundElement.Attribute("ID"));
            AddNanny(Nanny);
        }
        public Nanny GetNanny(int id)
        {
            //XElement m = ElementIfExists(XML_Source.nannyRoot, id);
            //XElement m = createNannyXElement(new Nanny(1, "Dana", "Anilewitch", "0798512565", "jerusalem", "jerusalem", new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] { new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, "comment", MyEnum.Paymentmethode.hourly));
            XElement m = ElementIfExists(XML_Source.nannyRoot, id);
            if (m == null)
                return null;
            return new Nanny()
            {

                ID = (int)m.Attribute("ID"),
                first_name = (string)m.Element("firstName"),
                last_name = (string)m.Element("lastName"),
                Birthdate = new DateTime(int.Parse(m.Element("Birthdate").Element("Year").Value), int.Parse(m.Element("Birthdate").Element("Month").Value), int.Parse(m.Element("Birthdate").Element("Day").Value)),
                PhoneNumber = (string)m.Element("PhoneNumber"),
                address = (string)m.Element("Address"),
                elevatorExists = (bool)m.Element("elevatorExists"),
                Floor = (int)m.Element("Floor"),
                experience = (int)m.Element("experience"),
                Max_number_kids = (int)m.Element("Max_number_kids"),
                Min_age = (int)m.Element("Min_age"),
                Max_age = (int)m.Element("Max_age"),
                Possible_Hourly_rate = (bool)m.Element("Possible_Hourly_rate"),
                Hourly_rate = (int)m.Element("Hourly_rate"),
                Monthly_rate = (int)m.Element("Monthly_rate"),
                Working_days = (from a in m.Element("Working_days").Elements("Days") select Boolean.Parse(a.Value)).ToArray(),
                Daily_Working_hours = (from b in m.Element("Daily_Working_hours").Elements("days")
                                       select (GetArray(b))).ToArray(),
                Vacation_days = (MyEnum.Vacation)Enum.Parse(typeof(MyEnum.Vacation), m.Element("Vacation_days").Value.ToString()),
                Recommendations = (string)m.Element("Recommendations"),
                Additional_Info = (string)m.Element("Additional_Info"),
                kidsCount = (int)m.Element("kidsCount"),
                fideback = (int)m.Element("fideback")
            };
        }


        public List<Nanny> getNannyList()
        {
            try
            {
                return (from m in XML_Source.nannyRoot.Elements()
                        let currentNanny = new Nanny()
                        {
                            first_name = (string)m.Element("firstName").Value,
                            last_name = (string)m.Element("lastName").Value
                        }
                        select GetNanny(int.Parse(m.Attribute("ID").Value))).ToList();
            }
            catch
            {
                throw new Exception("getNannyList() exception");
            }
        }
        #endregion Nanny

        //        XElement createContractXElement(Contract c)
        //            => new XElement("contract", new XAttribute("ID", c.Contract_ID),
        //                 new XElement("ChildID", c.Child_ID),
        //                 new XElement("MotherID", c.Mother_ID),
        //                 new XElement("Contract_number", c.Contract_number),
        //                 new XElement("contract_signed", c.contract_signed),
        //                 new XElement("discount", c.discount),
        //                 new XElement("distance", c.distance),
        //                 new XElement("enddate", c.enddate),
        //                  new XElement("Hourly_payment", c.Hourly_payment), 
        //                  new XElement("introduce_meeting", c.introduce_meeting),
        //                  new XElement("Monthly_payment", c.Monthly_payment),
        //                  new XElement("Nanny_ID", c.Nanny_ID),
        //                  new XElement("Paymentmethode", c.Paymentmethode),
        //                  new XElement("salary", c.salary),
        //                  new XElement("startdate", c.startdate)
        //                 );

        //        public bool addContract(Contract contract, bool autoAssignID = true)
        //        {
        //            if (ElementIfExists(XML_Source.contractRoot, (uint)contract.Contract_ID) != null)
        //            {
        //                throw new Exception(contract.Contract_ID + " already exists in file");
        //            }

        //            if (autoAssignID)
        //                contract.Contract_ID =(int)nextContractID++;

        //            XML_Source.contractRoot.Add(createContractXElement(contract));
        //            XML_Source.SaveXML<Contract>();

        //            return true;
        //        }

        //        public bool deleteContract(Contract contract)
        //            => removeElementFromXML(XML_Source.contractRoot,(uint)contract.Contract_ID);


        //        public bool updateContract(Contract contract)
        //        {
        //            XElement foundElement = ElementIfExists(XML_Source.contractRoot,(uint)contract.Contract_ID);
        //            if (foundElement == null)
        //                throw new Exception(contract.Contract_ID + " does not exist in XML");

        //            return
        //                removeElementFromXML(XML_Source.contractRoot, (uint)foundElement)
        //                && addContract(contract, false); // don't assign new contract ID
        //        }

        //        public uint getNextContractID()
        //        {
        //            return nextContractID;
        //        }

        //        XElement createChildXElement(Child c)
        //        {
        //            XElement child = new XElement("child", new XAttribute("ID",c.ID),
        //                                    new XElement("Birthdate",c.Birthdate),
        //                                    new XElement("Mother_ID",c.Mother_ID),
        //                                    new XElement("name", c.name),
        //                                    new XElement("SpecialNeeds", c.SpecialNeeds)
        //                                   );
        //            // if private person, add first name and last name
        //            return child;
        //        }

        //        public bool addChild(Child c)
        //        {
        //            if (ElementIfExists(XML_Source.childRoot, (uint)c.ID) != null)
        //            {
        //                throw new Exception(c.ID + " already exists in file");
        //            }

        //            XML_Source.childRoot.Add(createChildXElement(c));
        //            XML_Source.SaveXML<Child>();
        //            return true;
        //        }

        //        public bool deleteChild(Child child)
        //            => removeElementFromXML(XML_Source.childRoot, (uint)child.ID);

        //        public bool updateChild(Child child)
        //        {
        //            XElement foundElement = ElementIfExists(XML_Source.childRoot, (uint)child.ID);
        //            if (foundElement == null)
        //                throw new Exception(child.ID + " does not exist in XML");

        //            return
        //                removeElementFromXML(XML_Source.childRoot, (uint)foundElement)
        //                && addChild(child);
        //        }



        //        

        //        public List<Child> getChildList()
        //        {
        //            try
        //            {
        //                return (from c in XML_Source.childRoot.Elements()
        //                        select new Child()
        //                        {
        //                            ID = uint.Parse(c.Attribute("ID").Value),
        //                            firstName = (string)e.Element("firstName"), // check if exists perhaps
        //                            lastName = (string)e.Element("lastName"),
        //                            phoneNumber = (string)e.Element("phoneNumber"),
        //                            specializationID = uint.Parse(c.Element("specializationID").Value),
        //                            establishmentDate = DateTime.Parse(c.Element("establishmentDate").Value),
        //                            address = (CivicAddress)e.Element("CivicAddress") // calls explicit converter of Xlement to CivicAddress
        //                        }
        //                        ).ToList();
        //            }
        //            catch
        //            {
        //                throw new Exception("getChildList() exception");
        //            }
        //        }

        //        public List<Contract> getContractList()
        //        {
        //            try
        //            {
        //                return (from cont in XML_Source.contractRoot.Elements()
        //                        where cont.Name == "contract"
        //                        select new Contract()
        //                        {
        //                            Contract_ID = (int)cont.Attribute("ID"),
        //                            Child_ID = (int)cont.Element("ChildID"),
        //                            Mother_ID = (uint)cont.Element("mother_ID"),
        //                            Contract_number= cont.Element("Contract_number").
        //                            isInterviewed = (bool)cont.Element("isInterviewed"),
        //                            contractFinalized = (bool)cont.Element("contractFinalized"),
        //                            grossWagePerHour = (double)cont.Element("grossWagePerHour"),
        //                            netWagePerHour = (double)cont.Element("netWagePerHour"),
        //                            contractEstablishedDate = (DateTime)cont.Element("contractEstablishedDate"),
        //                            contractTerminatedDate = (DateTime)cont.Element("contractTerminatedDate"),
        //                            maxWorkHours = (uint)cont.Element("maxWorkHours")

        //                        }).ToList();
        //            }
        //            catch { throw new Exception("getContractList() exception"); }
        //        }

        //        public List<Nanny> getNannyList()
        //        {
        //            var returnList = XML_Source.Nannys?.ToList();

        //            if (returnList == null)
        //                return new List<Nanny>();
        //            else
        //                return returnList;
        //        }

        //        public DoWorkDelegate getXMLNannyBackground_DoWork()
        //            => XML_Source.downloadNannyXml;
    }
}
