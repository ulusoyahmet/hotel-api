﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager: IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TDelete(Booking t)
        {
            _bookingDal.Delete(t);
        }

        public int TGetBookingCount()
        {
            return _bookingDal.GetBookingCount();
        }

        public Booking TGetByID(int id)
        {
            return _bookingDal.GetByID(id);
        }

        public List<Booking> TGetLast6Bookings()
        {
            return _bookingDal.GetLast6Bookings();
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public void TInsert(Booking t)
        {
            _bookingDal.Insert(t);
        }

        public void TUpdate(Booking t)
        {
            _bookingDal.Update(t);
        }
    }
}
