using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IStaffDal : IGenericDal<Staff>
    {
        int GetStaffCount();
        List<Staff> GetLast4Staffs();
    }
}
