using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Cities
{
    class CityDbContext
    {
        public DbSet<object> Id { get; set; }
        public DbSet<City> city { get; set; }
        public DbSet<string> country { get; set; }
        public DbSet<Population> population { get; set; }
    }
}
