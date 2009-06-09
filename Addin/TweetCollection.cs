using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneShoot.Addin
{
    public class TweetCollection : List<ITweet>
    {
        public TweetCollection() { }
        public TweetCollection(ITweet[] tweets)
        {
            for (int i = 0; i < tweets.Length; i++)
                Add(tweets[i]); 
         
        }

        public int MaxCount { get; set; }

        public void Add(ITweet tweet)
        {
            base.Add(tweet);
        }
    }
}
