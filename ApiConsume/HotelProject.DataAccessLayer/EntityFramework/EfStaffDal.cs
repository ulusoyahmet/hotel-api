using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        private readonly Context _context;
        public EfStaffDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<Staff> GetLast4Staffs()
        {
            //using var context = new Context();
            return _context.Staffs.OrderByDescending(x => x.StaffID).ToList().GetRange(0, 4);
        }

        public int GetStaffCount()
        {
            return _context.Staffs.Count();
        }
    }
}
