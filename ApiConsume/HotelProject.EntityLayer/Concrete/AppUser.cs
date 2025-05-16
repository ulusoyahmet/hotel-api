using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HotelProject.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }  
        public string? Country { get; set; }
        public string? Gender { get; set; }

        [AllowNull]
        public string? ImageUrl { get; set; }

        [AllowNull]
        public string? WorkDepartment { get; set; }

        [AllowNull]
        public int WorkLocationID { get; set; }

        [AllowNull]
        public WorkLocation? WorkLocation { get; set; }
    }
}
