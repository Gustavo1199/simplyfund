using Microsoft.EntityFrameworkCore;
using SimplyFund.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Dal.DataBase
{
    public class SimplyfundContext : DbContext
    {
        public SimplyfundContext(DbContextOptions<SimplyfundContext> options) : base(options)
        {
                

        }


        public DbSet<Customers> Customers { get; set; }
    }
}
