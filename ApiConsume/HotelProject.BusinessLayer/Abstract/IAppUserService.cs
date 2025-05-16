using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        public List<AppUser> TUserListWithWorkLocation();
        public List<AppUser> TUsersListWithWorkLocation();
    }
}
