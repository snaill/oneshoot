using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;

namespace OneShoot.Addin.Fanfou
{
    /// <summary>
    /// 饭否 API 文档
    /// http://code.google.com/p/fanfou-api/wiki/ApiDocumentation
    /// </summary>
    public class Service : OneShoot.Addin.IService
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public ITweetCollection GetTimeline( Timeline tl, string userId, string since, int max )
        {
            switch ( tl )
            {
                case Timeline.Friends:
                    {
                        string url = string.Format("http://api.fanfou.com/statuses/friends_timeline.json?id={0}&count={1}&since_id={2}&page={3}",
                            userId, 20, since, 1);
                        System.IO.Stream stream = GetResponse(url);
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Tweet[]));
                        Tweet[] tweet = (Tweet[])serializer.ReadObject(stream);

                    }
                    break;
                case Timeline.Public:
                    {
                        string url = string.Format("http://api.fanfou.com/statuses/public_timeline.json?id={0}&count={1}&since_id={2}&page={3}",
                            userId, 20, since, 1);
                        System.IO.Stream stream = GetResponse(url);
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Tweet[]));
                        Tweet[] tweet = (Tweet[])serializer.ReadObject(stream);

                    }
                    break;
            }
            return null;
        }

        public System.Net.IWebProxy WebProxy { get; set; }

        protected System.IO.Stream GetResponse(string url)
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
                return resp.GetResponseStream();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
