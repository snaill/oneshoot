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

        public new string ToString() 
        {
            string  url = string.Format("{0}://{1}/{2}", Scheme, Host, Path );
            int     index = 0;
            if (null != Parameters)
            {
                foreach (string key in Parameters.AllKeys)
                {
                    if (Parameters[key] == null || Parameters[key] == "")
                        continue;

                    url += (0 == index) ? "?" : "&";
                    url += key + "=" + Parameters[key];
                }
            }

            return url;
        }
   }
}
