using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using OneShoot.Addin;

namespace OneShoot.Addin
{
    public class AccountInfo
    {
        protected IService service = null;

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public bool IsValid { get; set; }
        public IService Service { get; set; }
    }

    public class AccountManager : ObservableCollection<AccountInfo>
    {
    	string _fn = "";
    	
        public void Load( string fn, AddinManager addins )
        {
            try
            {
                XDocument xml = XDocument.Load( fn );
                var accs = from acc in xml.Root.Elements()
                           select new AccountInfo
                           {
                               UserName = acc.Attribute("userName").Value,
                               Password = Decode(acc.Attribute("password").Value),
                               Type = acc.Attribute("type").Value
                           };

               AccountInfo[] ais = accs.ToArray();
               for (int i = 0; i < ais.Length; i++)
               {
               		ais[i].Service = addins.CreateService(ais[i].Type);
               		if ( ais[i].Service == null )
               			continue; 
               		
               		ais[i].IsValid = ais[i].Service.VerifyAccount( ais[i].UserName, ais[i].Password );
               		base.Add(ais[i]);
               }
               _fn = fn;
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
            XDocument xml = XDocument.Load( _fn );
            XElement accElem = new XElement(
                "Account",
                new XAttribute("userName", acc.UserName),
                new XAttribute("password", Encode(acc.Password)),
                new XAttribute("type", acc.Type));
            xml.Root.Add( accElem );
            xml.Save( _fn );
        }

        public new void Remove(AccountInfo acc)
        {
            // remove
            base.Remove(acc);

            // save
            XDocument xml = XDocument.Load( _fn );
            var accElem = from p in xml.Root.Elements()
                          where p.Attribute("userName").Value == acc.UserName && p.Attribute("type").Value == acc.Type
                          select p;
            accElem.Remove();

            // 保存xml
            xml.Save( _fn );
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
