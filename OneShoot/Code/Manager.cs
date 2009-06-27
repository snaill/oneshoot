using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OneShoot
{
    public static class Manager
    {
        private static AccountManager _accountMgr = null;
        public static AddinManager _addinMgr = null;

        public static AccountManager AccountMgr {
            get 
            {
                if ( null == _accountMgr )
                {
                    _accountMgr = new AccountManager();
                    _accountMgr.Init();
                }
                return _accountMgr;
            }
        }

        public static AddinManager AddinMgr
        {
            get
            {
                if (null == _addinMgr)
                {
                    _addinMgr = new AddinManager();
                    _addinMgr.Init();
                }

                return _addinMgr;
            }
        }

        public const string AccountFile = "Account.xml";
        public const string AddinFile = "OneShoot.addin";

        static System.Windows.Threading.DispatcherTimer time = null;
        public static OneShoot.Addin.TweetCollection Tweets = new OneShoot.Addin.TweetCollection();

        public static void Init()
        {
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

            for (int i = 0; i < AccountMgr.Count; i++)
            {
                OneShoot.Addin.IService service = AccountMgr[i].Service;
                if ( null == service )
                    continue;

                OneShoot.Addin.TweetCollection tc = service.GetTimeline(OneShoot.Addin.Timeline.Friends, AccountMgr[i].UserName, "", 100);
                Tweets.AddRange( tc );
            }
            time.Start();
        }

    
    }
}
