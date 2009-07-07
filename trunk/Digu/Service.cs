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
        public const string ApiUrl = "http://api.digu.com/";

        public System.Net.IWebProxy WebProxy { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public bool VerifyAccount(string userName, string password)
        {
            try
            {

                GetResponse(ApiUrl + "account/verify_credentials.json", userName, password);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public TweetCollection GetTimeline( Timeline tl, string userId, int max )
        {
            string url = "";
            switch ( tl )
            {
                case Timeline.Friends:
                    {
                        url = string.Format(ApiUrl + "statuses/friends_timeline.json?id={0}&count={1}&since_id={2}&page={3}",
                            userId, 20, 0, 1);
                    }
                    break;
                case Timeline.User:
                    {
                        url = string.Format(ApiUrl + "statuses/user_timeline.json?id={0}&count={1}&since_id={2}&page={3}",
                            userId, 20, 0, 1);
                    }
                    break;
                case Timeline.Public:
                    {
                        url = string.Format(ApiUrl + "statuses/public_timeline.json?count={0}", 20);
                    }
                    break;
                case Timeline.Replies:
                    {
                        url = string.Format(ApiUrl + "statuses/replies.json?count={1}&since_id={2}&page={3}",
                            20, 0, 1);
                    }
                    break;
            }
            Tweet[] tweets = GetResponseObject<Tweet[]>(url);
            TweetCollection tc = new TweetCollection();
            for (int i = 0; i < tweets.Length; i++)
                tc.Add(tweets[i].toITweet());
            return tc;
        }

        public ITweet Update(string text, string replyid, string source) { return null; }
        public void Destroy(string id) { }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected System.Net.WebResponse GetResponse(string url, string userName, string password)
        {
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.CredentialCache myCache = new System.Net.CredentialCache();
                myCache.Add(new Uri(url), "Basic", new System.Net.NetworkCredential(userName, password));
                req.Credentials = myCache;
                req.Method = "GET";
                req.Proxy = WebProxy;

                return req.GetResponse();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected T GetResponseObject<T>(string url)
        {
            System.Net.WebResponse resp = GetResponse(url, UserName, Password);
            System.IO.Stream stream = resp.GetResponseStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }
}
