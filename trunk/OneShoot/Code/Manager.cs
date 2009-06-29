using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OneShoot
{
    public static class Manager
    {
        public const string AccountFile = "Account.xml";
        public const string AddinFile = "OneShoot.addin";
        
        public static AccountManager AccountManager = null;
        public static AddinManager AddinManager = null;

        public static System.Threading.Thread RefreshThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Manager.Refresh));
        public static int nRefreshTick = 0;

        public static volatile OneShoot.Addin.TweetCollection Tweets = new OneShoot.Addin.TweetCollection();

        private static void AddNewTweets(OneShoot.Addin.TweetCollection tc)
        {
            Tweets.AddRange(tc);
        }

        private static void Refresh(object obj)
        {
            while (true)
            {
                if (0 >= Manager.nRefreshTick)
                {
                    for (int i = 0; i < AccountManager.Count; i++)
                    {
                        OneShoot.Addin.IService service = AccountManager[i].Service;
                        if (null == service)
                            continue;

                        OneShoot.Addin.TweetCollection tc = service.GetTimeline(OneShoot.Addin.Timeline.Friends, AccountManager[i].UserName, "", 100);
                        (obj as System.Windows.Threading.Dispatcher).Invoke(new Action<OneShoot.Addin.TweetCollection>(AddNewTweets), tc);
                    }

                    Manager.nRefreshTick = Parameters.RefreshTick;
                }

                System.Threading.Thread.Sleep(1000);
                Manager.nRefreshTick--;
            }
        }
    }
}
