using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace OneShoot.Addin.Fanfou
{
    [DataContract(Namespace="http://oneshoot.org")]
    class Tweet //: OneShoot.Addin.ITweet
    {
        [DataMember(Name = "created_at")]
        public string created_at { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "text")]
        public string text { get; set; }

        [DataMember(Name = "source")]
        public string source { get; set; }

        [DataMember(Name = "truncated")]
        public string truncated { get; set; }

        [DataMember(Name = "in_reply_to_status_id")]
        public string in_reply_to_status_id { get; set; }

        [DataMember(Name = "in_reply_to_user_id")]
        public string in_reply_to_user_id { get; set; }

        [DataMember(Name = "favorited")]
        public string favorited { get; set; }

        [DataMember(Name = "in_reply_to_screen_name")]
        public string in_reply_to_screen_name { get; set; }

        [DataMember(Name = "photo_url")]
        public string photo_url { get; set; }

        [DataMember(Name = "user")]
        public User user { get; set; }
    }

    [DataContract(Namespace = "http://oneshoot.org")]
    class User //: OneShoot.Addin.IUser
    {
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "screen_name")]
        public string screen_name { get; set; }

        [DataMember(Name = "location")]
        public string location { get; set; }

        [DataMember(Name = "description")]
        public string description { get; set; }

        [DataMember(Name = "profile_image_url")]
        public string profile_image_url { get; set; }

        [DataMember(Name = "url")]
        public string url { get; set; }
 
        [DataMember(Name = "protected")]
        public string isProtected { get; set; }

        [DataMember(Name = "followers_count")]
        public string followers_count { get; set; }

        [DataMember(Name = "status")]
        public Tweet status { get; set; }
    }
}
