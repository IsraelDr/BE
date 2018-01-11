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
