using System;
using AutoMapper;
using HotelProject.WebUI.Dtos.SocialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSocialPartial: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/bookingcom"),
                Headers =
                    {
                        { "x-rapidapi-key", "4d8dcc0894mshad9b4f75ab601a8p1e3effjsn6b33c27c23e1" },
                        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
                    },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var instagramProfile = JsonConvert.DeserializeObject<InstagramProfileDto>(body);
                if (instagramProfile != null)
                {
                    ViewBag.InstagramFollowers = instagramProfile.followers;
                    ViewBag.InstagramFollowings = instagramProfile.following;
                }
            }

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter241.p.rapidapi.com/user?username=bookingcom"),
                Headers =
                    {
                        { "x-rapidapi-key", "4d8dcc0894mshad9b4f75ab601a8p1e3effjsn6b33c27c23e1" },
                        { "x-rapidapi-host", "twitter241.p.rapidapi.com" },
                    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body = await response2.Content.ReadAsStringAsync();

                var xProfile = JsonConvert.DeserializeObject<XProfileDto>(body);

                var legacy = xProfile?.result?.data?.user?.result?.legacy;

                if (legacy != null)
                {
                    ViewBag.XFollowers = legacy.followers_count;
                    ViewBag.XFollowings = legacy.friends_count;
                }
            }

            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://li-data-scraper.p.rapidapi.com/get-company-by-domain?domain=booking.com"),
                Headers =
                {
                    { "x-rapidapi-key", "4d8dcc0894mshad9b4f75ab601a8p1e3effjsn6b33c27c23e1" },
                    { "x-rapidapi-host", "li-data-scraper.p.rapidapi.com" },
                },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body = await response3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<LinkedinProfileDto>(body);

                var linkeinProfile = values.data;

                if (linkeinProfile != null)
                {
                    ViewBag.linkedinFollowers = linkeinProfile.followerCount;
                    ViewBag.linkedinStaffs = linkeinProfile.staffCount;
                }
            }

            var client4 = new HttpClient();
            var request4 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://facebook-pages-scraper2.p.rapidapi.com/get_facebook_pages_details?link=https%3A%2F%2Fwww.facebook.com%2Fbookingcom"),
                Headers =
                {
                    { "x-rapidapi-key", "4d8dcc0894mshad9b4f75ab601a8p1e3effjsn6b33c27c23e1" },
                    { "x-rapidapi-host", "facebook-pages-scraper2.p.rapidapi.com" },
                },
            };
            using (var response4 = await client4.SendAsync(request4))
            {
                response4.EnsureSuccessStatusCode();
                var body = await response4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FacebookProfileDto>>(body);
                var facebookProfile = values.FirstOrDefault();

                if (facebookProfile != null)
                {
                    ViewBag.facebookFollowers = facebookProfile.followers_count;
                    ViewBag.facebookLikes = facebookProfile.likes_count;
                }

            }

            return View();
        }
    }
}
