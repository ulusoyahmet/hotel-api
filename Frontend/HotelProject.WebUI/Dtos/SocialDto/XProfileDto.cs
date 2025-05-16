namespace HotelProject.WebUI.Dtos.SocialDto
{
    public class XProfileDto
    {
        public ResultWrapper result { get; set; }

        public class ResultWrapper
        {
            public DataWrapper data { get; set; }
        }

        public class DataWrapper
        {
            public UserWrapper user { get; set; }
        }

        public class UserWrapper
        {
            public UserResult result { get; set; }
        }

        public class UserResult
        {
            public Legacy legacy { get; set; }
        }

        public class Legacy
        {
            public int followers_count { get; set; }
            public int friends_count { get; set; }
        }
    }

}
