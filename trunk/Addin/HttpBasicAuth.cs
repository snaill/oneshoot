using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;

namespace OneShoot.Addin
{
    public class HttpBasicAuth : IAuth
    {
        public HttpBasicAuth(string service)
        {
            Service = service;
        }

        public System.Net.IWebProxy WebProxy { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Service { get; set; }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public System.Net.WebResponse Get(Url url)
        {
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create( url.ToString() );
                System.Net.CredentialCache myCache = new System.Net.CredentialCache();
                myCache.Add(new Uri(url.ToString()), "Basic", new System.Net.NetworkCredential(UserName, Password));
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

        public System.Net.WebResponse Post( Url url)
        {
            try {
                // Create the web request  
                System.Net.WebRequest req = System.Net.WebRequest.Create( url.HostAndPath );
                System.Net.CredentialCache myCache = new System.Net.CredentialCache();
                myCache.Add(new Uri(url.HostAndPath), "Basic", new System.Net.NetworkCredential(UserName, Password));
                req.Credentials = myCache;
                req.Method = "POST";
                req.Proxy = WebProxy;

                string param = url.Query;
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = param.Length;

                // Write the request paramater
                System.IO.StreamWriter stOut = new System.IO.StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                stOut.Write(param);
                stOut.Close();

                return req.GetResponse();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
