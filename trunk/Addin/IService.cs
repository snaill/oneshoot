﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneShoot.Addin
{
    public interface IService
    {
        ITweet AddTweet(string text);
        ITweet AddTweet(string text, double replyid);
        void DestroyTweet(double id);

        ITweet SendDirectMessage(string text, string user);
        void DestroyDirectMessage(double id);

        void FollowUser(string userName);

        IUserCollection GetFriends(int userId);
        IUserCollection GetFriends();
        IUser GetUser(int userId);

        IUser CurrentlyLoggedInUser { get; set; }
        System.Security.SecureString Password { get; set; }
        IUser Login();

        ITweetCollection GetFriendsTimeline();
        ITweetCollection GetFriendsTimeline(string since, string userId);
        ITweetCollection GetFriendsTimeline(string since);
        ITweetCollection GetPublicTimeline(string since);
        ITweetCollection GetPublicTimeline();
        ITweetCollection GetReplies();
        ITweetCollection GetReplies(string since);

        ITweetCollection GetUserTimeline(string userId);

        ITweetCollection RetrieveMessages();
        ITweetCollection RetrieveMessages(string since);

        System.Net.IWebProxy WebProxy { get; set; }
    }
}
