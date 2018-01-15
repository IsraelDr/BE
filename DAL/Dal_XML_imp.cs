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

    public class DAL_XML_Imp : Idal
    {

        /// <summary>
        /// Main Functions of Class
        /// </summary>
        # region Main Class
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
        #endregion Main Class


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
        {
            removeElementFromXML(XML_Source.motherRoot, ID);
            XML_Source.SaveXML<Mother>();
            IEnumerable<Child> children = getChildList(x => x.Mother_ID == ID);
            foreach (Child child in children.ToList())
            {
                RemoveChild(child.ID);//delete all children
            }
            IEnumerable<Contract> contractsofNanny = getContractList(x => x.Nanny_ID == ID);
            foreach (Contract contr in contractsofNanny.ToList())
            {
                RemoveContract(contr.Contract_ID);//delete all contracts
            }
        }

        public void UpdateMother(Mother mother)
        {
            XElement foundElement = ElementIfExists(XML_Source.motherRoot, (int)mother.ID);
            if (foundElement == null)
                throw new Exception(mother.ID + " does not exist in XML");
            removeElementFromXML(XML_Source.motherRoot, (int)foundElement.Attribute("ID"));
            AddMother(mother);
            XML_Source.SaveXML<Mother>();
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

        public IEnumerable<BE.Mother> getMotherList(Func<Mother, bool> predicate = null)
        {
            if (predicate == null)
                return getMotherListhelp().AsEnumerable();
            return getMotherListhelp().Where(predicate);
        }
        public List<Mother> getMotherListhelp()
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
        {
            removeElementFromXML(XML_Source.nannyRoot, ID);
            XML_Source.SaveXML<Nanny>();
            IEnumerable<Contract> contractsofNanny = getContractList(x => x.Nanny_ID == ID);
            foreach (Contract contr in contractsofNanny.ToList())
            {
                RemoveContract(contr.Contract_ID);
            }
        }

        public void UpdateNanny(Nanny Nanny)
        {
            XElement foundElement = ElementIfExists(XML_Source.nannyRoot, (int)Nanny.ID);
            if (foundElement == null)
                throw new Exception(Nanny.ID + " does not exist in XML");
            removeElementFromXML(XML_Source.nannyRoot, (int)foundElement.Attribute("ID"));
            AddNanny(Nanny);
            XML_Source.SaveXML<Nanny>();
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

        public IEnumerable<BE.Nanny> getNannyList(Func<Nanny, bool> predicate = null)
        {
            if (predicate == null)
                return getNannyListhelp().AsEnumerable();
            return getNannyListhelp().Where(predicate);
        }
        public List<Nanny> getNannyListhelp()
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

        //All the function connected to Child XML
        #region Child
        XElement createChildXElement(Child n)//converter from Child to xelement
            => (new XElement("Child", new XAttribute("ID", n.ID),
                  new XElement("Mother_ID", n.Mother_ID),
                  new XElement("name", n.name),
                  new XElement("Birthdate", new XElement("Day", ((DateTime)(n.Birthdate)).Day),
                                            new XElement("Month", ((DateTime)(n.Birthdate)).Month),
                                            new XElement("Year", ((DateTime)(n.Birthdate)).Year)),
                  new XElement("SpecialNeeds", n.SpecialNeeds)
                 ));
        public void AddChild(Child m)
        {
            if (ElementIfExists(XML_Source.childRoot, m.ID) != null)
            {
                throw new Exception(m.ID + " already exists in file");
            }

            XML_Source.childRoot.Add(createChildXElement(m));
            XML_Source.SaveXML<Child>();
        }
        public void RemoveChild(int ID)
        {
            removeElementFromXML(XML_Source.childRoot, ID);
            XML_Source.SaveXML<Child>();
        }

        public void UpdateChild(Child Child)
        {
            XElement foundElement = ElementIfExists(XML_Source.childRoot, (int)Child.ID);
            if (foundElement == null)
                throw new Exception(Child.ID + " does not exist in XML");
            removeElementFromXML(XML_Source.childRoot, (int)foundElement.Attribute("ID"));
            AddChild(Child);
            XML_Source.SaveXML<Child>();
        }
        public Child GetChild(int id)
        {
            //XElement m = ElementIfExists(XML_Source.ChildRoot, id);
            //XElement m = createChildXElement(new Child(1, "Dana", "Anilewitch", "0798512565", "jerusalem", "jerusalem", new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] { new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, "comment", MyEnum.Paymentmethode.hourly));
            XElement m = ElementIfExists(XML_Source.childRoot, id);
            if (m == null)
                return null;
            return new Child()
            {

                ID = (int)m.Attribute("ID"),
                name = (string)m.Element("name"),
                Mother_ID = (int)m.Element("Mother_ID"),
                Birthdate = new DateTime(int.Parse(m.Element("Birthdate").Element("Year").Value), int.Parse(m.Element("Birthdate").Element("Month").Value), int.Parse(m.Element("Birthdate").Element("Day").Value)),
                SpecialNeeds = (bool)m.Element("SpecialNeeds"),
                
            };
        }

        public IEnumerable<BE.Child> getChildList(Func<Child, bool> predicate = null)
        {
            if (predicate == null)
                return getChildListhelp().AsEnumerable();
            return getChildListhelp().Where(predicate);
        }
        public List<Child> getChildListhelp()
        {
            try
            {
                return (from m in XML_Source.childRoot.Elements()
                        let currentChild = new Child()
                        {
                            name = (string)m.Element("name").Value
                        }
                        select GetChild(int.Parse(m.Attribute("ID").Value))).ToList();
            }
            catch
            {
                throw new Exception("getChildList() exception");
            }
        }
        #endregion Child

        //All the function connected to Contract XML
        #region Contract
        XElement createContractXElement(Contract n)//converter from Contract to xelement
            => (new XElement("Contract", new XAttribute("ID", n.Contract_ID),
                  new XElement("Nanny_ID", n.Nanny_ID),
                  new XElement("Child_ID", n.Child_ID),
                  new XElement("Mother_ID", n.Mother_ID),
                  new XElement("introduce_meeting", n.introduce_meeting),
                  new XElement("contract_signed", n.contract_signed),
                  new XElement("Hourly_payment", n.Hourly_payment),
                  new XElement("Monthly_payment", n.Monthly_payment),
                  new XElement("Paymentmethode", n.Paymentmethode),
                  new XElement("startdate", new XElement("Day", ((DateTime)(n.startdate)).Day),
                                            new XElement("Month", ((DateTime)(n.startdate)).Month),
                                            new XElement("Year", ((DateTime)(n.startdate)).Year)),
                  new XElement("enddate", new XElement("Day", ((DateTime)(n.enddate)).Day),
                                            new XElement("Month", ((DateTime)(n.enddate)).Month),
                                            new XElement("Year", ((DateTime)(n.enddate)).Year)),
                  new XElement("salary", n.salary),
                  new XElement("distance", n.distance),
                  new XElement("discount", n.discount)
                  
                 ));
        public void AddContract(Contract m)
        {
            if (ElementIfExists(XML_Source.contractRoot, m.Contract_ID)!= null)
            {
                throw new Exception(m.Contract_ID + " already exists in file");
            }

            XML_Source.contractRoot.Add(createContractXElement(m));
            XML_Source.SaveXML<Contract>();
        }
        public void RemoveContract(int ID)
        {
            removeElementFromXML(XML_Source.contractRoot, ID);
            XML_Source.SaveXML<Contract>();
        }

        public void UpdateContract(Contract Contract)
        {
            XElement foundElement = ElementIfExists(XML_Source.contractRoot, (int)Contract.Contract_ID);
            if (foundElement == null)
                throw new Exception(Contract.Contract_ID + " does not exist in XML");
            removeElementFromXML(XML_Source.contractRoot, (int)foundElement.Attribute("ID"));
            AddContract(Contract);
            XML_Source.SaveXML<Contract>();
        }
        public Contract GetContract(int id)
        {
            //XElement m = ElementIfExists(XML_Source.ContractRoot, id);
            //XElement m = createContractXElement(new Contract(1, "Dana", "Anilewitch", "0798512565", "jerusalem", "jerusalem", new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] { new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, "comment", MyEnum.Paymentmethode.hourly));
            XElement m = ElementIfExists(XML_Source.contractRoot, id);
            if (m == null)
                return null;
            return new Contract()
            {

                Contract_ID = (int)m.Attribute("ID"),
                Nanny_ID = (int)m.Element("Nanny_ID"),
                Child_ID = (int)m.Element("Child_ID"),
                Mother_ID = (int)m.Element("Mother_ID"),
                introduce_meeting = (bool)m.Element("introduce_meeting"),
                contract_signed = (bool)m.Element("contract_signed"),
                Hourly_payment = (int)m.Element("Hourly_payment"),
                Monthly_payment = (double)m.Element("Monthly_payment"),
                Paymentmethode = (MyEnum.Paymentmethode)Enum.Parse(typeof(MyEnum.Paymentmethode), m.Element("Paymentmethode").Value.ToString()),
                startdate = new DateTime(int.Parse(m.Element("startdate").Element("Year").Value), int.Parse(m.Element("startdate").Element("Month").Value), int.Parse(m.Element("startdate").Element("Day").Value)),
                enddate = new DateTime(int.Parse(m.Element("enddate").Element("Year").Value), int.Parse(m.Element("enddate").Element("Month").Value), int.Parse(m.Element("enddate").Element("Day").Value)),
                salary = (double)m.Element("salary"),
                distance = (double)m.Element("distance"),
                discount = (bool)m.Element("discount")
                
            };
        }

        public IEnumerable<BE.Contract> getContractList(Func<Contract, bool> predicate = null)
        {
            if (predicate == null)
                return getContractListhelp().AsEnumerable();
            return getContractListhelp().Where(predicate);
        }
        public List<Contract> getContractListhelp()
        {
            try
            {
                return (from m in XML_Source.contractRoot.Elements()
                        let currentContract = int.Parse(m.Attribute("ID").Value)
                        select GetContract(currentContract)).ToList();
            }
            catch
            {
                throw new Exception("getContractList() exception");
            }
        }
        #endregion Contract
        
    }
}
