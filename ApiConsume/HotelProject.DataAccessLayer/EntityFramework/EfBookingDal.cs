using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public int GetBookingCount()
        {
            using var context = new Context();
            return context.Bookings.Count();
        }

        public List<Booking> GetLast6Bookings()
        {
            using var context = new Context();
            return context.Bookings.OrderByDescending(x => x.BookingID)
                                   .Take(6).ToList();
        }
    }
}
