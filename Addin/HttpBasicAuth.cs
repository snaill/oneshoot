using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;

namespace OneShoot.Addin
{
    public class HttpBasicAuth
    {
        public System.Net.IWebProxy WebProxy { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public System.Net.WebResponse GetResponse(string url)
        {
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.CredentialCache myCache = new System.Net.CredentialCache();
                myCache.Add(new Uri(url), "Basic", new System.Net.NetworkCredential(UserName, Password));
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
    }
}
