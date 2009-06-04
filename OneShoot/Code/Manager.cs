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

        public const string AccountFile = "Account.xml";
        public const string AddinFile = "OneShoot.addin";

        static System.Windows.Threading.DispatcherTimer time = null;


        public static void Init()
        {
            AddinMgr.Init();
            AccountMgr.Init();

            //
            time = new System.Windows.Threading.DispatcherTimer();
            time.Interval = new TimeSpan(0, 5, 0);
            time.Tick += new EventHandler( timer_Tick );
            time.Start();
        }

        static void timer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        public static void Refresh()
        {
            time.Stop();

            for (int i = 0; i < AccountMgr.Accounts.Count; i++)
            {

            }
            time.Start();
        }

    
    }
}
