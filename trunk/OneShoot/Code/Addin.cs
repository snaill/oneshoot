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
        public string Icon { get; set; }
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
                               Type = acc.Attribute("type").Value,
                               Icon = acc.Attribute("icon").Value
                           };

                if (null != accs)
                    AddRange(accs);

            }
            catch (Exception)
            {

            }
        }

        public AddinInfo GetAddinInfo(string name)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Name == name)
                    return this[i];
            }
            return null;
        }

        public IService CreateService(string name)
        {
            try
            {
                AddinInfo ai = GetAddinInfo(name);
                System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(System.Environment.CurrentDirectory + "\\" + ai.Assembly);
                Type t = ass.GetType(ai.Type);
                return (IService)System.Activator.CreateInstance(t);
            }
            catch (Exception)
            {
            }

            return null;
        }
    }
}
