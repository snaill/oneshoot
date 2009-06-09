using System;
using System.Collections.Generic;
using System.Text;

namespace OneShoot.Addin
{
    public class ITweet
    {
        public string Id { get; set; }
        public string ReplyId { get; set; }
        public string DateCreated { get; set; }
        public string Text { get; set; }
        public IUser User { get; set; }
    }
}
