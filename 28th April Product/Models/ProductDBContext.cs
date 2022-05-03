using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFProduct.Models;

namespace EFProduct.Models
{
    public class ProductDBContext:DbContext
    {
        public ProductDBContext()
        { }
        public ProductDBContext(DbContextOptions<ProductDBContext>options):base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-VUVG2NF;Initial Catalog=Trail;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");
        }
        public DbSet<EFProduct.Models.Prod> prods { get; set; }
    }
}
