using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Shopex.Infrastructure.DB.Model;

namespace Shopex.Infrastructure.DB
{
    public partial class ShopexMySqlContext : DbContext
    {
        public ShopexMySqlContext(DbContextOptions<ShopexMySqlContext> options)
         : base(options)
        {
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Banners> Banners { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Product_Prices> Product_Prices { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<DeliveryFees> DeliveryFees { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Order_Lines> Order_Lines { get; set; }
        public virtual DbSet<OrderLogs> Order_Logs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.user_id);
            });
            modelBuilder.Entity<OrderLogs>(entity =>
            {
                entity.HasKey(e => e.order_log_id);
            });
            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.HasKey(e => e.session_id);
            });
            modelBuilder.Entity<Banners>(entity =>
            {
                entity.HasKey(e => e.banner_id);
            });
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.category_id);
                entity.HasMany(p => p.products).WithOne(b => b.Category);
            });
            modelBuilder.Entity<DeliveryFees>(entity =>
            {
                entity.HasKey(e => e.fee_id);
            });
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.category_id);
                entity.HasMany(p => p.products).WithOne(b => b.Category);
            });
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.product_id);
                entity.HasOne(p => p.Category).
                WithMany(b => b.products).
                HasForeignKey(s => s.category_id);
                entity.HasMany(p => p.product_prices).WithOne(b => b.product);

            });
            modelBuilder.Entity<Product_Prices>(entity =>
            {
                entity.HasKey(e => e.product_price_id);
                entity.HasOne(p => p.product).
               WithMany(b => b.product_prices).
               HasForeignKey(s => s.product_id);
            });
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.address_id);
                entity.HasOne(p => p.user).
               WithMany(b => b.address).
               HasForeignKey(s => s.user_id);
            });
            modelBuilder.Entity<Carts>(entity =>
            {
                entity.HasKey(e => e.cart_id);
                entity.HasOne(p => p.product).
               WithMany(b => b.carts).
               HasForeignKey(s => s.product_id);
                entity.HasOne(p => p.productPrice).
              WithMany(b => b.carts).
              HasForeignKey(s => s.product_id);
                entity.HasOne(p => p.session).
              WithMany(b => b.carts).
              HasForeignKey(s => s.session_id);
                entity.HasOne(p => p.user).
             WithMany(b => b.carts).
             HasForeignKey(s => s.user_id);
                entity.HasOne(p => p.address).
            WithMany(b => b.carts).
            HasForeignKey(s => s.address_id);
            });
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.order_id);
                entity.HasOne(p => p.address).
               WithMany(b => b.orders).
               HasForeignKey(s => s.address_id);
                entity.HasOne(p => p.user).
              WithMany(b => b.orders).
              HasForeignKey(s => s.user_id);
            });
            modelBuilder.Entity<Order_Lines>(entity =>
            {
                entity.HasKey(e => e.order_line_id);

                entity.HasOne(p => p.order).
               WithMany(b => b.orderLines).
               HasForeignKey(s => s.order_id);

                entity.HasOne(p => p.productPrice).
              WithMany(b => b.orderLines).
              HasForeignKey(s => s.product_price_id);

                entity.HasOne(p => p.product).
            WithMany(b => b.orderLines).
            HasForeignKey(s => s.product_id);
            });
        }
    }
}
