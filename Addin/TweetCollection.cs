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
            base.Add(tweet);

            //if (CollectionChanged != null)
            //    CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));

        }

        public void AddRange(TweetCollection tweets)
        {
            for ( int i = 0; i < tweets.Count; i ++ )
                Add( tweets[i] );
        }
    }
}
