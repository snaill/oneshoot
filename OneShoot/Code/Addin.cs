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

    public class AddinManager
    {
        public List<AddinInfo> Addins = new List<AddinInfo>();

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
                    Addins.AddRange(accs);

            }
            catch (Exception)
            {

            }
        }

        public IService CreateService(string name)
        {
            for (int i = 0; i < Addins.Count; i++)
            {
                if (Addins[i].Name == name)
                {
                    System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(System.Environment.CurrentDirectory + "\\" + Addins[i].Assembly);
                    Type t = ass.GetType(Addins[i].Type);
                    return (IService)System.Activator.CreateInstance(t);
                }
            }

            return null;
        }
    }
}
