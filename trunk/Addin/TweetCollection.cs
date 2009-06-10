using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace OneShoot.Addin
{
    public class TweetCollection : List<ITweet>, INotifyCollectionChanged
    {
        #region INotifyCollectionChanged Members
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion
        
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

            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));

        }
    }
}
