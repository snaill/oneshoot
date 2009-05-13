using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using OneShoot.Addin;

namespace OneShoot
{
    public class AccountInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public IService Service { get; set; }
    }

    public class AccountManager
    {
        public List<AccountInfo> Accounts = new List<AccountInfo>();

        public void Init()
        {
            try
            {
                XDocument xml = XDocument.Load( Manager.AccountFile );
                var accs = from acc in xml.Root.Elements()
                           select new AccountInfo
                           {
                               UserName = acc.Attribute("userName").Value,
                               Password = acc.Attribute("password").Value,
                               Type = acc.Attribute("type").Value
                           };

                if (null != accs)
                    Accounts.AddRange(accs);

            }
            catch (Exception)
            {

            }
        }

        public void Add(AccountInfo acc)
        {
            // auth
            
            // add
            Accounts.Add(acc);

            // save
            XDocument xml = XDocument.Load( Manager.AccountFile );
            XElement accElem = new XElement(
                "Account",
                new XAttribute("userName", acc.UserName),
                new XAttribute("password", acc.Password),
                new XAttribute("type", acc.Type));
            xml.Root.Add( accElem );
            xml.Save( Manager.AccountFile );
        }

        public void Remove(AccountInfo acc)
        {
            // remove
            Accounts.Remove(acc);

            // save
            XDocument xml = XDocument.Load( Manager.AccountFile );
            var accElem = from p in xml.Root.Elements()
                          where p.Attribute("userName").Value == acc.UserName && p.Attribute("type").Value == acc.Type
                          select p;
            accElem.Remove();

            // 保存xml
            xml.Save(Manager.AccountFile);
        }
    }
}
