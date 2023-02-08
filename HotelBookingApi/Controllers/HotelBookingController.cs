using HotelBookingApi.Data;
using HotelBookingApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly ApiDbContext _db;

        public HotelBookingController(ApiDbContext db)
        {
            _db = db;
        }

        
        [HttpPost]
        public JsonResult CreateEdit(int id,HotelBooking booking)
        {
            if(booking.Id == 0) {
                _db.hotelBookings.Add(booking);
            }
            else
            {
                var data = _db.hotelBookings.Find(booking.Id);
                if(data == null)
                {
                    return new JsonResult(NotFound());
                }
                data = booking;
            }
            _db.SaveChanges();
            return new JsonResult(Ok(booking));
        }
        [HttpGet]
        public JsonResult Get(int id)
        {
            var datas = _db.hotelBookings.Find(id);
            if(datas == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(datas));
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var datas = _db.hotelBookings.Find(id);
            if (datas == null)
            {
                return new JsonResult(NotFound());
            }
            _db.hotelBookings.Remove(datas);
            _db.SaveChanges();
            return new JsonResult(Ok(datas));   
        }
    }
}
