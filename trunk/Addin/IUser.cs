using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneShoot.Addin
{
    public class IUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SiteUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public int StatusesCount { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
    }
}
