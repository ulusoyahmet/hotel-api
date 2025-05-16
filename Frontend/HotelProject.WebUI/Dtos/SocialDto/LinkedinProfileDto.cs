namespace HotelProject.WebUI.Dtos.SocialDto
{
    public class LinkedinProfileDto
    {
        public Data? data { get; set; }

        public class Data
        {
            public int staffCount { get; set; }
            public int followerCount { get; set; }

        }
    }
}
