using Microsoft.EntityFrameworkCore;
using WareHouse.Core.Utils;
namespace WareHouse.Core.Entities
{
    public class MyDbContext : DbContext
    {
        // Khởi tạo bảng
        public DbSet<UserEntity> users { set; get; }
        public DbSet<RoleEntity> roles { set; get; }
        public DbSet<ProductTypeEntity> productTypes { set; get; } 

        public DbSet<ProductEntity> products { set; get; }

        public DbSet<ProductBatchEntity> productBatches { set; get; }
        public DbSet<InputInfoEntity> inputInfos { set; get; }
        public DbSet<OutputInfoEntity> outputInfos { set; get; }
        //public DbSet<ProductBatchInputInfoEntity> productBatchInputInfos { set; get; }

        //public DbSet<ProductOutputInfoEntity> productOutputInfos { set; get; }
        // Chuỗi kết nối tới CSDL (MS SQL Server)

        private const string connectionString = Constant.CONNECTION_STRING;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<InputInfoEntity>().HasKey(table => new
            {
                table.InputInfoId,
                table.ProductBatchId
            });
            builder.Entity<OutputInfoEntity>().HasKey(table => new
            {
                table.OutputInfoId,
                table.ProductId
            });
            builder.Entity<OutputInfoEntity>()
                .HasOne(m => m.PickerUser)
                .WithMany(t => t.PickerOutputInfo)
                .HasForeignKey(m => m.PickerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OutputInfoEntity>()
                .HasOne(m => m.DeliverUser)
                .WithMany(t => t.DeliverOutputInfo)
                .HasForeignKey(m => m.DeliverUserId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
