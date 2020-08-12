using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ICT638June2020Group03API.models
{
    public class HouseContext : DbContext
    {
        //Agent Api Tia
        public HouseContext(DbContextOptions<HouseContext> options)
           : base(options)
        {
        }

        public DbSet<House> TodoItems { get; set; }

    }
}