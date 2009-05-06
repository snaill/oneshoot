using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneShoot.Addin
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string SiteUrl { get; set; }
        string ImageUrl { get; set; }
        string Description { get; set; }
        string Location { get; set; }

        int StatusesCount { get; set; }
        int FollowersCount { get; set; }
        int FollowingCount { get; set; }
    }
}
