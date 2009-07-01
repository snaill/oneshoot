using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneShoot.Addin
{
    public interface IAuth
    {
        string UserName { get; set; }
        string Password { get; set; }
        string Service { get; set; }
    }
}
