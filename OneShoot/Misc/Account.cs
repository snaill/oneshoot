using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneShoot.Addin;

namespace OneShoot
{
    public class Account
    {
        public string User { get; set; }
        public System.Security.SecureString Password { get; set; }
        public IService Service { get; set; }
    }
}
