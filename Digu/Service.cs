using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;

namespace OneShoot.Addin.Digu
{
    /// <summary>
    /// 嘀咕 API 文档
    /// http://code.google.com/p/digu-api/wiki/DiguApi
    /// </summary>
    public class Service : OneShoot.Addin.IService
    {
        public System.Net.IWebProxy WebProxy { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public TweetCollection GetTimeline( Timeline tl, string userId, string since, int max )
        {
            string url = "";
            switch ( tl )
            {
                case Timeline.Friends:
                    {
                        url = string.Format("http://api.digu.com/statuses/friends_timeline.json?id={0}&count={1}&since_id={2}&page={3}",
                            userId, 20, since, 1);
                    }
                    break;
                case Timeline.User:
                    {
                        url = string.Format("http://api.digu.com/statuses/user_timeline.json?id={0}&count={1}&since_id={2}&page={3}",
                            userId, 20, since, 1);
                    }
                    break;
                case Timeline.Public:
                    {
                        url = string.Format("http://api.digu.com/statuses/public_timeline.json?count={0}", 20);
                    }
                    break;
                case Timeline.Replies:
                    {
                        url = string.Format("http://api.digu.com/statuses/replies.json?count={1}&since_id={2}&page={3}",
                            20, since, 1);
                    }
                    break;
            }
            Tweet[] tweets = GetResponse<Tweet[]>(url);
            TweetCollection tc = new TweetCollection();
            for (int i = 0; i < tweets.Length; i++)
                tc.Add(tweets[i].toITweet());
            return tc;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected T GetResponse<T>(string url)
        {
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.CredentialCache myCache = new System.Net.CredentialCache();
                myCache.Add(new Uri(url), "Basic", new System.Net.NetworkCredential(UserName, Password));
                req.Credentials = myCache;
                req.Method = "GET";
                req.Proxy = WebProxy;

                System.Net.WebResponse resp = req.GetResponse();
                System.IO.Stream stream = resp.GetResponseStream();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
