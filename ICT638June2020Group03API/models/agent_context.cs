using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ICT638June2020Group03API.models
{
    public class agent_context:DbContext
    {
        //Agent Api Tia
        public agent_context(DbContextOptions<agent_context> options)
           : base(options)
        {
        }

        public DbSet<Agent> TodoItems { get; set; }
    }
}
