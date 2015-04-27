using System.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tweetinvi;


namespace MyBattlePong2.Twitter
{
    public class Twitear
    {

        public static void Tweeti()
        {

            TwitterCredentials.SetCredentials("3193275575-5loWqKJY7xSM56R1x0VBGCskbmepFALW0w0Clys", "nMzmKhnBeFAmGzwZK8PWo23JM9JKlLorzQpJXEkU2NUHq", "mOY3kXffR1v4jXrEwbatnVGlF", "vx1VkVBxoCjn5Rb5mCzvt6j5HmRIlsSSnKHHeSRbV1B3Gyaiax");
            var user = User.GetLoggedUser();
            Tweet.PublishTweet("Alonso es toda"); 

        }

    }
}