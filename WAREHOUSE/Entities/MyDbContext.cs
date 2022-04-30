using Microsoft.EntityFrameworkCore;
using WAREHOUSE.Utils;
namespace WAREHOUSE.Entities
{
    public class MyDbContext : DbContext
    {
        // Khởi tạo bảng
        public DbSet<UserEntity> users { set; get; }
        
        // Chuỗi kết nối tới CSDL (MS SQL Server)

        private const string connectionString = Constant.CONNECTION_STRING;

        // Phương thức OnConfiguring gọi mỗi khi một đối tượng DbContext được tạo
        // Nạp chồng nó để thiết lập các cấu hình, như thiết lập chuỗi kết nối
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
