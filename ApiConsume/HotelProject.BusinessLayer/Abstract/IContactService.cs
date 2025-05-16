using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
        public int TGetContactCount();
        
    }
}
