using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using OneShoot.Addin;

namespace OneShoot
{
    public class AddinInfo
    {
        public string Name { get; set; }
        public string Assembly { get; set; }
        public string Type { get; set; }
    }

    public class AddinManager : List<AddinInfo>
    {
        public void Init()
        {
            try
            {
                XDocument config = XDocument.Load( Manager.AddinFile);
                var accs = from acc in config.Root.Elements()
                           select new AddinInfo
                           {
                               Name = acc.Attribute("name").Value,
                               Assembly = acc.Attribute("assembly").Value,
                               Type = acc.Attribute("type").Value
                           };

                if (null != accs)
                    AddRange(accs);

            }
            catch (Exception)
            {

            }
        }

        public IService CreateService(string name)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Name == name)
                {
<<<<<<< .mine
                    try
                    {
                        System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(System.Environment.CurrentDirectory + "\\" + Addins[i].Assembly);
                        Type t = ass.GetType(Addins[i].Type);
                        return (IService)System.Activator.CreateInstance(t);
                    }
                    catch (Exception)
                    {
                        break;
                    }
=======
                    try
                    {
                        System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(System.Environment.CurrentDirectory + "\\" + this[i].Assembly);
                        Type t = ass.GetType(this[i].Type);
                        return (IService)System.Activator.CreateInstance(t);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
>>>>>>> .r22
                }
            }

            return null;
        }
    }
}
