using System;
using System.Collections.Generic;
using System.Text;

namespace OneShoot.Addin
{
    public class ITweet
    {
        //
        public string Id { get; set; }
        public string ReplyId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Source { get; set; }
        public string Text { get; set; }

        //
        public bool IsReply { get { return false; } set { } }

        //
        public IUser User { get; set; }
    }
}
