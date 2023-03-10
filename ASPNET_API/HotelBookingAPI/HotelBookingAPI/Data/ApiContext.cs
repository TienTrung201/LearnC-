using HotelBookingAPI.Model;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<HotelBooking> Bookings { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }
    }
}
