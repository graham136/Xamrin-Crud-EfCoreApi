using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XamarinWebApi.Models;

namespace XamarinWebApi.Data
{
    public class XamarinWebApiContext : DbContext
    {
        public XamarinWebApiContext (DbContextOptions<XamarinWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<XamarinWebApi.Models.User> User { get; set; }
    }
}
