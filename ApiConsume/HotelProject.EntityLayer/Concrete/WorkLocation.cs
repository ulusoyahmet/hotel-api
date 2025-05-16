using System.Diagnostics.CodeAnalysis;

namespace HotelProject.EntityLayer.Concrete
{
    public class WorkLocation
    {
        public int WorkLocationID { get; set; }
        public string? WorkLocationName { get; set; }
        public string? WorkLocationCityName { get; set; }

        [AllowNull]
        public List<AppUser>? AppUsers { get; set; }
    }
}
