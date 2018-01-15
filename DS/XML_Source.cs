using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;
using System.Threading;
using System.ComponentModel;

namespace DS
{
    static public class XML_Source
    {
        //static string prefix = @"../../../XML DB Files/"; // relative source of files


        static public string nannyPath = @"nannys.xml";
        static public XElement nannyRoot;

        static public string contractPath = @"contracts.xml";
        static public XElement contractRoot;

        static public string motherPath = @"mothers.xml";
        static public XElement motherRoot;
       
        static public string childPath = @"childs.xml";
        static public XElement childRoot;

        static XML_Source()
        {
            // initialize roots

            // 'out' used for reference, otherwise we get null root after method finishes.
            loadOrCreate(contractPath, out contractRoot);
            loadOrCreate(motherPath, out motherRoot);
            loadOrCreate(nannyPath, out nannyRoot);
            loadOrCreate(childPath, out childRoot);
        }
        static void loadOrCreate(string filename, out XElement root)
        {
            if (!File.Exists(filename))
                createXMLFile(filename, out root);
            else
                loadXMLFile(filename, out root);
        }
        //static public string concatXMLName(string filename)
        //    => filename + ".xml";

        static void createXMLFile(string filename, out XElement root)
        {
            root = new XElement(filename);
            root.Save(filename);
        }

        static void loadXMLFile(string filename, out XElement root)
        {
            try
            {
                root = XElement.Load(filename);
            }
            catch
            {
                throw new Exception("error loading " + filename);
            }
        }
        public static void SaveMotherListLinq(List<Mother> MotherList)
        {
            motherRoot = new XElement("mothers",
                                    from p in MotherList
                                    select new XElement("mother",
                                        new XElement("id", p.ID),
                                       new XElement("name",
                                            new XElement("firstName", p.Firstname),
                                            new XElement("lastName", p.Lastname)
                                            )
                                        )
                                    );
            motherRoot.Save(motherPath);
        }
        public static void LoadData()
        {
            try
            {
                motherRoot = XElement.Load(motherPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        static public void SaveXML<T>()
        {
            if (typeof(T) == typeof(Mother))
                motherRoot.Save(motherPath);
            else if (typeof(T) == typeof(Contract))
                contractRoot.Save(contractPath);
            else if (typeof(T) == typeof(Child))
                childRoot.Save(childPath);
            else if (typeof(T) == typeof(Nanny))
                nannyRoot.Save(nannyPath);

            else
                throw new Exception("bad type passed to T of SaveXML<T>()");
        }
    }
}
