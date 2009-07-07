using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneShoot.Addin.Twitter
{
    /// <summary>
    /// Twitter API 文档
    /// http://apiwiki.twitter.com/
    /// </summary>
    public class TwitterApiUri : Url
    {
        public TwitterApiUri()
        {
            this.Scheme = "http";
            this.Host = "twitter.com";
        }

        #region 账户相关
        /// <summary>
        /// 检验用户名密码是否正确
        /// </summary>
        public void verify_credentials()
        {
            this.Path = "account/verify_credentials.json";
        }
        #endregion

        #region 消息相关
        /// <summary>
        /// 显示随便看看的消息
        /// </summary>
        /// <param name="count">消息数，范围 1-20，默认为 20</param>
        public void public_timeline( int count )
        {
            this.Path = "statuses/public_timeline.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["count"] = count.ToString();
        }

        /// <summary>
        /// 显示用户和好友的消息
        /// </summary>
        /// <param name="count">消息数，范围 1-20，默认为 20</param>
        /// <param name="since_id">仅返回比此 ID 大的消息</param>
        /// <param name="max_id">仅返回 ID 小于等于此 ID 的消息</param>
        /// <param name="page">页码，从 1 开始</param>
        public void friends_timeline(int count, string since_id, string max_id, int page )
        {
            this.Path = "statuses/friends_timeline.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["count"] = count.ToString();
            this.Parameters["since_id"] = since_id;
            this.Parameters["max_id"] = max_id;
            this.Parameters["page"] = page.ToString();
        }

        /// <summary>
        /// 显示用户的消息
        /// </summary>
        /// <param name="count">消息数，范围 1-20，默认为 20</param>
        /// <param name="since_id">仅返回比此 ID 大的消息</param>
        /// <param name="max_id">仅返回 ID 小于等于此 ID 的消息</param>
        /// <param name="page">页码，从 1 开始</param>
        public void user_timeline(int count, string since_id, string max_id, int page)
        {
            this.Path = "statuses/user_timeline.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["count"] = count.ToString();
            this.Parameters["since_id"] = since_id;
            this.Parameters["max_id"] = max_id;
            this.Parameters["page"] = page.ToString();
        }

        /// <summary>
        /// 显示发给当前用户的消息
        /// </summary>
        /// <param name="count">消息数，范围 1-20，默认为 20</param>
        /// <param name="since_id">仅返回比此 ID 大的消息</param>
        /// <param name="max_id">仅返回 ID 小于等于此 ID 的消息</param>
        /// <param name="page">页码，从 1 开始</param>
        public void replies(int count, string since_id, string max_id, int page)
        {
            this.Path = "statuses/replies.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["count"] = count.ToString();
            this.Parameters["since_id"] = since_id;
            this.Parameters["max_id"] = max_id;
            this.Parameters["page"] = page.ToString();
        }

        /// <summary>
        /// 发布消息 POST
        /// </summary>
        /// <param name="status">消息内容，使用 POST 方式提交</param>
        /// <param name="in_reply_to_status_id">如果是回复某一条消息，则在这里指明被回复的消息的ID</param>
        /// <param name="source">消息来源，使用 POST 方式提交，如果与饭否的数据库匹配，网页上将以此格式显示： status(消息内容) 通过 source 对应的 API 应用名称</param>
        public void update(string status, string in_reply_to_status_id, string source )
        {
            this.Path = "statuses/update.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["status"] = status;
            this.Parameters["in_reply_to_status_id"] = in_reply_to_status_id;
            this.Parameters["source"] = source;
        }

        /// <summary>
        /// 删除消息 POST
        /// </summary>
        /// <param name="id">消息的id</param>
        public void destroy(string id)
        {
            this.Path = "statuses/destroy.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["id"] = id;
        }
        #endregion

        #region 收藏相关
        /// <summary>
        /// 显示用户的收藏列表
        /// </summary>
        /// <param name="id">用户 id，没有此参数或用户设隐私时需验证用户</param>
        /// <param name="count">私信数，范围 1-20，默认为 20</param>
        /// <param name="page">页码，从 1 开始</param>
        public void favorites(string id, int count, int page)
        {
            this.Path = "favorites.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["id"] = id;
            this.Parameters["count"] = count.ToString();
            this.Parameters["page"] = page.ToString();
        }

        /// <summary>
        /// 收藏某条消息 POST
        /// </summary>
        /// <param name="id">消息的id</param>
        public void favorites_create(string id)
        {
            this.Path = "favorites/create/" + id + ".json";
        }

        /// <summary>
        /// 删除收藏 POST
        /// </summary>
        /// <param name="id">消息的id</param>
        public void favorites_destroy(string id)
        {
            this.Path = "favorites/destroy/" + id + ".json";
        }
        #endregion

        #region 私信相关
        /// <summary>
        /// 显示用户收到的私信
        /// </summary>
        /// <param name="count">私信数，范围 1-20，默认为 20</param>
        /// <param name="since_id">仅返回比此 ID 大的私信</param>
        /// <param name="max_id">仅返回 ID 小于等于此 ID 的私信</param>
        /// <param name="page">页码，从 1 开始</param>
        public void direct_messages(int count, string since_id, string max_id, int page)
        {
            this.Path = "direct_messages.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["count"] = count.ToString();
            this.Parameters["since_id"] = since_id;
            this.Parameters["max_id"] = max_id;
            this.Parameters["page"] = page.ToString();
        }

        /// <summary>
        /// 显示用户发的私信
        /// </summary>
        /// <param name="count">私信数，范围 1-20，默认为 20</param>
        /// <param name="since_id">仅返回比此 ID 大的私信</param>
        /// <param name="max_id">仅返回 ID 小于等于此 ID 的私信</param>
        /// <param name="page">页码，从 1 开始</param>
        public void direct_messages_send(int count, string since_id, string max_id, int page)
        {
            this.Path = "direct_messages/send.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["count"] = count.ToString();
            this.Parameters["since_id"] = since_id;
            this.Parameters["max_id"] = max_id;
            this.Parameters["page"] = page.ToString();
        }

        /// <summary>
        /// 发送私信 POST
        /// </summary>
        /// <param name="user">收信人id ，使用 POST 方式提交</param>
        /// <param name="text">私信内容，使用 POST 方式提交</param>
        /// <param name="in_reply_to_id">表示回复某条私信</param>
        public void direct_messages_new(string user, string text, string in_reply_to_id)
        {
            this.Path = "direct_messages/new.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["user"] = user;
            this.Parameters["text"] = text;
            this.Parameters["in_reply_to_id"] = in_reply_to_id;
        }

        /// <summary>
        /// 删除私信 POST
        /// </summary>
        /// <param name="id">私信的id</param>
        public void direct_messages_destroy(string id)
        {
            this.Path = "direct_messages/destroy.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["id"] = id;
        }
        #endregion

        #region 用户相关
        /// <summary>
        /// 显示好友列表
        /// </summary>
        /// <param name="id">用户 id，没有此参数或用户设隐私时需验证用户</param>
        /// <param name="page">页码，从 1 开始</param>
        public void friends(string id, int page)
        {
            this.Path = "users/friends.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["id"] = id;
            this.Parameters["page"] = page.ToString();
        }

        /// <summary>
        /// 显示关注者列表
        /// </summary>
        /// <param name="id">用户 id，没有此参数或用户设隐私时需验证用户</param>
        /// <param name="page">页码，从 1 开始</param>
        public void followers(string id, int page)
        {
            this.Path = "users/followers.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["id"] = id;
            this.Parameters["page"] = page.ToString();
        }

        /// <summary>
        /// 显示用户详细信息
        /// </summary>
        /// <param name="id">用户 id，没有此参数或用户设隐私时需验证用户。没有此参数时为当前用户</param>
        public void show(string id)
        {
            this.Path = "users/show.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["id"] = id;
        }

        /// <summary>
        /// 添加好友
        /// </summary>
        /// <param name="id">用户 id</param>
        public void friendships_create(string id)
        {
            this.Path = "friendships/create.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["id"] = id;
        }

        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="id">用户 id</param>
        public void friendships_destroy(string id)
        {
            this.Path = "friendships/destroy.json";
            this.Parameters = new System.Collections.Specialized.NameValueCollection();
            this.Parameters["id"] = id;
        }
        #endregion

    }
}
