using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OneShoot
{
    public static class Manager
    {
        public static AccountManager AccountMgr = new AccountManager();
        public static AddinManager AddinMgr = new AddinManager();
        public static MainWindow Main = null;

        public const string AccountFile = "Account.xml";
        public const string AddinFile = "OneShoot.addin";
 
        public static void Init()
        {
            AddinMgr.Init();
            AccountMgr.Init();
        }
    }
}
