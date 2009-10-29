using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using OneShoot.Addin;

namespace OneShoot
{
    public static class Manager
    {
        public const string AccountFile = "Account.xml";
        public const string AddinFile = "OneShoot.addin";
        
        public static System.Threading.Thread RefreshThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Manager.Refresh));
        public static int nRefreshTick = 0;

		public static OneShoot.Addin.TweetService _service = null;
        public static OneShoot.Addin.TweetCollection _tweets = null;
        
        public static OneShoot.Addin.AddinManager AddinManager
        {
            get
            {
    	        return Service.AddinMgr;
            }
        }
            
        public static OneShoot.Addin.AccountManager AccountManager
        {
            get
            {
    	        return Service.AccountMgr;
            }
        }    
            
        public static OneShoot.Addin.TweetService Service
        {
            get
            {
                if (null == _service)
                {
                    _service = new OneShoot.Addin.TweetService(AddinFile, AccountFile);
                }
                return _service;
            }
        }
        
        public static OneShoot.Addin.TweetCollection Tweets
        {
            get
            {
                if (null == _tweets)
                {
                    _tweets = new OneShoot.Addin.TweetCollection();
                    _tweets.MaxCount = Parameters.MaxCountOnScreen;
                }
                return _tweets;
            }
        }

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
                	OneShoot.Addin.TweetCollection tc = Service.GetTimeline( OneShoot.Addin.Timeline.Friends, Parameters.MaxCountOnScreen );
                    (obj as System.Windows.Threading.Dispatcher).Invoke(new Action<OneShoot.Addin.TweetCollection>(AddNewTweets), tc);

                    Manager.nRefreshTick = Parameters.RefreshTick;
                }

                System.Threading.Thread.Sleep(1000);
                Manager.nRefreshTick--;
            }
        }
    }
}
