//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Xml.Linq;
//using System.Xml.Serialization;
//using BE;
//using System.Threading;
//using System.ComponentModel;

//namespace DS
//{
//    static public class XML_Source
//    {
//        static string prefix = @"../../../XML DB Files/"; // relative source of files

//        //static public string specName = "specializations";
//        //static public string NannyName = "Nannys";
//        //static public string contractName = "contracts";
//        //static public string employeeName = "employees";
//        //static public string childName = "childs";
    
//        static public string nannyName = "nannys";
//        static public string contractName = "contracts";
//        static public string motherName = " mothers";
//        static public string childName = "childs";


//        //static public XElement specializationRoot;
//        //static public XElement NannyRoot;
//        //static public XElement contractRoot;
//        //static public XElement employeeRoot;
//        //static public XElement childRoot;

//        //static public XElement specializationRoot;
//        static public XElement nannyRoot;
//        static public XElement contractRoot;
//        static public XElement motherRoot;
//        static public XElement childRoot;

//        //static public IEnumerable<Nanny> Nannys;
//        static public IEnumerable<Nanny> Nannys;

//        static XML_Source()
//        {
//            // initialize roots

//            // 'out' used for reference, otherwise we get null root after method finishes.
//            //loadOrCreate(specName, out specializationRoot);
//            //loadOrCreate(contractName, out contractRoot);
//            //loadOrCreate(childName, out childRoot);
//            //loadOrCreate(employeeName, out employeeRoot);

//            loadOrCreate(nannyName, out nannyRoot);
//            loadOrCreate(contractName, out contractRoot);
//            loadOrCreate(motherName, out motherRoot);
//            loadOrCreate(childName, out childRoot);
//        }

//        public static void downloadNannyXml(object sender, DoWorkEventArgs e)
//        {
//            try
//            {
//                //XElement Nannys = XElement.Load(@"http://www.boi.org.il/he/NannyingSupervision/NannysAndBranchLocations/Lists/BoiNannyBranchesDocs/atm.xml");
//                 XElement nannys = XElement.Load(@"http://www.boi.org.il/he/NannyingSupervision/NannysAndBranchLocations/Lists/BoiNannyBranchesDocs/atm.xml");

//                ////  Nannys = from XNanny in Nannys.Elements()
//                //Nannys = from XNanny in nannys.Elements()
//                //        let tempAddress = new Address
//                //        {
//                //            Address = (Address)XNanny.Element("כתובת_ה-ATM"),
//                //            City = (string)XNanny.Element("ישוב")
//                //        }
//                //        let n = new Nanny
//                //        {
//                //            first_name = ((string)XNanny.Element("sdfd")).Trim(),
//                //            NannyNumber = (uint)XNanny.Element("sdf"),
//                //            Address = tempAddress,
//                //            Branch = (uint)XNanny.Element("fsdf")
//                //        }
//                //        orderby n.NannyName, n.Branch
//                //        // remove extra atms from each branch
//                //        group n by new { bNumber = n.NannyNumber, nBranch = n.Branch } into nannyNumAndAddress
//                //        select nannyNumAndAddress.First();

//                // saves nannys into nannys.xml
//                XmlSerializer serializer = new XmlSerializer(typeof(List<Nanny>));
//                TextWriter writer = new StreamWriter((concatXMLName("nannys")));
//                serializer.Serialize(writer, Nannys.ToList());
//                writer.Close();

//                // loads saved nannys.xml file into nannyRoot
//                loadXMLFile(nannyName, out nannyRoot);

//                e.Result = "downloadSuccess";
//                return;

//            }
//            catch // if internet problem, enter into catch
//            {
//                try
//                {
//                    // load local nannys.xml
//                    loadXMLFile(nannyName, out nannyRoot);
//                    Nannys = from nanny in nannyRoot.Elements()
//                            let b = new Nanny()
//                            {
//                                first_name = (string)nanny.Element("nannyName"),
//                                PhoneNumber = (string)nanny.Element("nannyNumber"),
//                                address = (string)nanny.Element("Address"),
//                            }
//                            select b;

//                    e.Result = "loadSuccess";
//                    return;
//                }
//                catch // error loading local nannys.xml
//                {
//                    e.Result = "failed";
//                    return;
//                }

//            }
//        }


//        static void loadOrCreate(string filename, out XElement root)
//        {
//            if (!File.Exists(concatXMLName(filename)))
//                createXMLFile(filename, out root);
//            else
//                loadXMLFile(filename, out root);
//        }

//        static public string concatXMLName(string filename)
//            => prefix + filename + ".xml";

//        static void createXMLFile(string filename, out XElement root)
//        {
//            root = new XElement(filename);
//            root.Save(concatXMLName(filename));
//        }

//        static void loadXMLFile(string filename, out XElement root)
//        {
//            try
//            {
//                root = XElement.Load(concatXMLName(filename));
//            }
//            catch
//            {
//                throw new Exception("error loading " + concatXMLName(filename));
//            }
//        }

//        static public void SaveXML<T>()
//        {
//            if (typeof(T) == typeof(Nanny))
//                nannyRoot.Save(concatXMLName(nannyName));

//            else if (typeof(T) == typeof(Contract))
//                contractRoot.Save(concatXMLName(contractName));

//            else if (typeof(T) == typeof(Mother))
//               motherRoot.Save(concatXMLName(motherName));

//            else if (typeof(T) == typeof(Child))
//               childRoot.Save(concatXMLName(childName));

//            else
//                throw new Exception("bad type passed to T of SaveXML<T>()");
//        }
//    }
//}
