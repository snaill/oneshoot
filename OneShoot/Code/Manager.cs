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
        public string Type { get; set; }
    }

    public class AccountInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public IService Service { get; set; }
    }

    public static class Manager
    {
        public static List<AccountInfo> Accounts = new List<AccountInfo>();
        public static List<AddinInfo> Addins = new List<AddinInfo>();
        public static MainWindow Main = null;

        public static void Init()
        {
            try
            {
                XDocument config = XDocument.Load("OneShoot.Addin");
                var accs = from acc in config.Root.Elements("Addin")
                           select new AddinInfo
                           {
                               Name = acc.Attribute("Name").Value,
                               Type = acc.Attribute("Type").Value
                           };

                if (null != accs)
                    Addins.AddRange(accs);

            }
            catch (Exception)
            {

            }

            try
            {
                XDocument config = XDocument.Load("Configure.xml");
                var accs = from acc in config.Root.Element("Accounts").Elements()
                           select new AccountInfo
                           {
                               UserName = acc.Attribute("UserName").Value,
                               Password = acc.Attribute("Password").Value,
                               Type = acc.Attribute("Type").Value
                           };

                if ( null != accs )
                    Accounts.AddRange(accs);
                           
            }
            catch (Exception)
            {

            }
        }
    }
}
