﻿using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Data
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options ): base(options)
        {

        }

        public DbSet<HotelBooking> hotelBookings { get; set; }
    }
}
