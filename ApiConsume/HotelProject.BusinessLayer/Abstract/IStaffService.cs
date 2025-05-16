using HotelProject.EntityLayer.Concrete;


namespace HotelProject.BusinessLayer.Abstract
{
    public interface IStaffService : IGenericService<Staff>
    {
        int TGetStaffCount();
        List<Staff> TGetLast4Staffs();
    }
}
