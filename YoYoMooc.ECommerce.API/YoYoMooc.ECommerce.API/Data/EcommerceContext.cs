using Microsoft.EntityFrameworkCore;

using YoYoMooc.ECommerce.API.Models;

namespace YoYoMooc.ECommerce.API.Data
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options)
              : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
    }
}
