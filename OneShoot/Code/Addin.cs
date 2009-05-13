using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OneShoot
{
    public class AddinInfo
    {
        public string Name { get; set; }
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
                               Type = acc.Attribute("type").Value
                           };

                if (null != accs)
                    Addins.AddRange(accs);

            }
            catch (Exception)
            {

            }
        }
    }
}
