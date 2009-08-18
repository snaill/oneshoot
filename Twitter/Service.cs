using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;

namespace OneShoot.Addin.Twitter
{
    /// <summary>
    /// Twitter API 文档
    /// http://apiwiki.twitter.com/
    /// </summary>
    public class Service : OneShoot.Addin.IService
    {
        protected HttpBasicAuth Auth = new HttpBasicAuth("twitter.com");
        protected const int MaxCountOnePage = 200;
 
	//	public System.Net.IWebProxy WebProxy { get { return Auth.WebProxy; } set { Auth.WebProxy = value; } }
        public string UserName { get { return Auth.UserName; } set { Auth.UserName = value; } }
        public string Password { get { return Auth.Password; } set { Auth.Password = value; } }
        public bool VerifyAccount(string userName, string password)
        {
            try
            {
                HttpBasicAuth auth = new HttpBasicAuth("twitter.com");
                auth.UserName = userName;
                auth.Password = password;

                TwitterApiUri uri = new TwitterApiUri();
                uri.verify_credentials();
                auth.Get(uri);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public TweetCollection GetTimeline( Timeline tl, string userId, int max )
        {
            TwitterApiUri uri = new TwitterApiUri();
            switch (tl)
            {
                case Timeline.Friends:
                    uri.friends_timeline(20, null, null, 1);
                    break;
                case Timeline.User:
                    uri.user_timeline(20, null, null, 1);
                    break;
                case Timeline.Public:
                    uri.public_timeline(20);
                    break;
                case Timeline.Replies:
                    uri.replies(20, null, null, 1);
                    break;
            }

            Tweet[] tweets = ApiGet<Tweet[]>( uri );
            TweetCollection tc = new TweetCollection();
            for (int i = 0; i < tweets.Length; i++)
                tc.Add(tweets[i].toITweet( Auth ));
            return tc;
        }

        public ITweet Update(string text, string replyid, string source) 
        {
            TwitterApiUri uri = new TwitterApiUri();
            uri.update(text, replyid, source);
            return ApiPost<Tweet>(uri).toITweet(Auth);
        }

        public void Destroy(string id) {
            TwitterApiUri uri = new TwitterApiUri();
            uri.destroy(id);
            ApiPost<Tweet>(uri);
        }

        protected T ApiGet<T>(Url url)
        {
            System.Net.WebResponse resp = Auth.Get(url);
            System.IO.Stream stream = resp.GetResponseStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }

        protected T ApiPost<T>(Url url)
        {
            System.Net.WebResponse resp = Auth.Post(url);
            System.IO.Stream stream = resp.GetResponseStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }
}
