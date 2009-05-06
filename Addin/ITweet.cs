using System;
using System.Collections.Generic;
using System.Text;

namespace OneShoot.Addin
{
    public interface ITweet
    {
        double Id { get; set; }
        double ReplyId { get; set; }
        DateTime? DateCreated { get; set; }
        string Text { get; set; }
        IUser User { get; set; }
    }
}
