using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using OneShoot.Addin;

namespace OneShoot
{
    public class AccountInfo
    {
        protected IService service = null;

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public AddinInfo Addin
        {
            get
            {
                return Manager.AddinManager.GetAddinInfo(Type);
            }
        }
        public IService Service 
        { 
            get {
                if (service == null)
                {
                    service = Manager.AddinManager.CreateService(Type);
                    if (null != service)
                    {
                        service.UserName = UserName;
                        service.Password = Password;
                    }
                }

                return service;
            }
        }
    }

    public class AccountManager : ObservableCollection<AccountInfo>
    {
        public void Init()
        {
            try
            {
                XDocument xml = XDocument.Load( Manager.AccountFile );
                var accs = from acc in xml.Root.Elements()
                           select new AccountInfo
                           {
                               UserName = acc.Attribute("userName").Value,
                               Password = Decode(acc.Attribute("password").Value),
                               Type = acc.Attribute("type").Value
                           };

               AccountInfo[] ais = accs.ToArray();
               for (int i = 0; i < ais.Length; i++)
                   base.Add(ais[i]);
            }
            catch (Exception)
            {

            }
        }

        public new void Add(AccountInfo acc)
        {
            // auth
            IService service = acc.Service;
            if (null == service)
                return;

            if (!service.VerifyAccount(acc.UserName, acc.Password))
                return;

            // add
            base.Add(acc);

            // save
            XDocument xml = XDocument.Load( Manager.AccountFile );
            XElement accElem = new XElement(
                "Account",
                new XAttribute("userName", acc.UserName),
                new XAttribute("password", Encode(acc.Password)),
                new XAttribute("type", acc.Type));
            xml.Root.Add( accElem );
            xml.Save( Manager.AccountFile );

            //
            Manager.nRefreshTick = 0;
        }

        public new void Remove(AccountInfo acc)
        {
            // remove
            base.Remove(acc);

            // save
            XDocument xml = XDocument.Load( Manager.AccountFile );
            var accElem = from p in xml.Root.Elements()
                          where p.Attribute("userName").Value == acc.UserName && p.Attribute("type").Value == acc.Type
                          select p;
            accElem.Remove();

            // 保存xml
            xml.Save(Manager.AccountFile);

            //
            Manager.nRefreshTick = 0;
        }

        protected string Encode(string code)
        {
            byte[] bytes = Encoding.Default.GetBytes(code);
            return Convert.ToBase64String(bytes);
        }

        protected string Decode(string code)
        {
            byte[] outputb = Convert.FromBase64String(code);
            return Encoding.Default.GetString(outputb);
        }
    }
}
