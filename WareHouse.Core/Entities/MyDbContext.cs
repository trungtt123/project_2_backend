using Microsoft.EntityFrameworkCore;
using WareHouse.Core.Utils;
using Microsoft.Extensions.Configuration;
namespace WareHouse.Core.Entities
{
    public class MyDbContext : DbContext
    {
        // Khởi tạo bảng
        private readonly IConfiguration _configuration;

        public DbSet<UserEntity> users { set; get; }
        public DbSet<RoleEntity> roles { set; get; }
        public DbSet<ProductTypeEntity> productTypes { set; get; } 

        public DbSet<ProductEntity> products { set; get; }

        public DbSet<ProductBatchEntity> productBatches { set; get; }
        public DbSet<InputInfoEntity> inputInfo { set; get; }
        public DbSet<OutputInfoEntity> outputInfo { set; get; }
        public DbSet<OutputProductEntity> outputProduct { set; get; }
        public DbSet<ProductBatchProductEntity> productBatchProduct { set; get; }
        // Chuỗi kết nối tới CSDL (MS SQL Server)

        private const string connectionString = Constant.CONNECTION_STRING;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //Console.WriteLine(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Entity<OutputProductEntity>().HasKey(table => new
            //{
            //    table.OutputInfoId,
            //    table.ProductId,
            //    table
            //});
            //builder.Entity<ProductBatchProductEntity>().HasKey(table => new
            //{
            //    table.ProductBatchId,
            //    table.ProductId
            //});

            builder.Entity<OutputInfoEntity>()
                .HasOne(m => m.Picker)
                .WithMany(t => t.PickerOutputInfo)
                .HasForeignKey(m => m.PickerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OutputInfoEntity>()
                .HasOne(m => m.Signator)
                .WithMany(t => t.DeliverOutputInfo)
                .HasForeignKey(m => m.SignatorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<UserEntity>()
                .HasIndex(u => u.UserName)
                .IsUnique();
        }

    }
}
