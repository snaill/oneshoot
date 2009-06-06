using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                        System.IO.Stream stream = GetResponse( "http://api.fanfou.com/statuses/friends_timeline.json" );
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
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Credentials = new System.Net.NetworkCredential(UserName, Password);
            req.Method = "POST";
            req.Proxy = WebProxy;
            return req.GetRequestStream();
        }
    }
}
