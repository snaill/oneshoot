/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-10-29
 * Time: 12:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace OneShoot.Addin
{
	/// <summary>
	/// Description of TweetService.
	/// </summary>
	public class TweetService
	{
		public AccountManager AccountMgr = new AccountManager();
		public AddinManager AddinMgr = new AddinManager();

		public TweetService( string strAddin, string strAccount )
		{
	    	AddinMgr.Load(strAddin);
	    	AccountMgr.Load(strAccount, AddinMgr);
		}

		public TweetCollection GetTimeline( Timeline tl, int max )
		{
			TweetCollection	tc = new TweetCollection();
			for (int i = 0; i < AccountMgr.Count; i++)
            {
                if (!AccountMgr[i].IsValid)
                    continue;

                IService service = AccountMgr[i].Service;
                TweetCollection tcTemp = service.GetTimeline(tl, "", max);
                tc.AddRange( tcTemp );
            }
			
			return tc;
		}

    	public ITweet AddTweet(string text, string replyid, string source)
    	{
    		return null;
    	}
	}
}
