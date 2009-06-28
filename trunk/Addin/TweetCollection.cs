using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace OneShoot.Addin
{
    public class TweetCollection : ObservableCollection<ITweet>
    {
        public TweetCollection() { }
        public TweetCollection(ITweet[] tweets)
        {
            for (int i = 0; i < tweets.Length; i++)
                Add(tweets[i]); 
         
        }

        public int MaxCount { get; set; }

        public new void Add(ITweet tweet)
        {
            for (int i = 0; i < Count; i++)
            {
                //if ( tweet.DateCreated == Items[i].DateCreated )
                //{
                    
                //}
                if (tweet.DateCreated > Items[i].DateCreated)
                {
                    base.Insert(i, tweet);
                    return;
                }
            }

            base.Add(tweet);
        }

        public void AddRange(TweetCollection tweets)
        {
            for ( int i = 0; i < tweets.Count; i ++ )
                Add( tweets[i] );
        }
    }
}
