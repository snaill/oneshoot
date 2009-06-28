using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace OneShoot.Addin
{
    public class Url
    {
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public NameValueCollection Parameters { get; set; }

        public string HostAndPath
        {
            get
            {
                return string.Format("{0}://{1}/{2}", Scheme, Host, Path);
            }
        }

        public string Query
        {
            get
            {
                if (null == Parameters)
                    return "";

                int index = 0;
                string url = "";
                foreach (string key in Parameters.AllKeys)
                {
                    if (Parameters[key] == null || Parameters[key] == "")
                        continue;

                    if ( 0 != index) 
                        url += "&" + url;

                    url += key + "=" + Parameters[key];
                    index++;
                }

                return url;
            }
        }

        public new string ToString() 
        {
            return Query == "" ? HostAndPath : HostAndPath + "?" + Query;
        }
   }
}
