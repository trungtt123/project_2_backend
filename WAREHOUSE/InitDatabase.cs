using Microsoft.EntityFrameworkCore;
using WareHouse.Repository;
using WareHouse.Core.Models;
using WareHouse.Core.Entities;
using WareHouse.Core.Utils;

namespace WareHouse
{
    
    public class InitDatabase
    {
        public static async Task CreateDatabase()
        {
            using var dbcontext = new MyDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            var result = await dbcontext.Database.EnsureCreatedAsync();
            string resultstring = result ? "tao db thanh  cong" : "db da ton tai";
            Console.WriteLine($"CSDL {dbname} : {resultstring}");
        }
        public static async Task DeleteDatabase()
        {

            using (var context = new MyDbContext())
            {
                String databasename = context.Database.GetDbConnection().Database;
                
                bool deleted = await context.Database.EnsureDeletedAsync();
                string deletionInfo = deleted ? "đa xoa" : "khong xoa duoc";
                Console.WriteLine($"{databasename} {deletionInfo}");

            }

        }
        public static async void ResetDb()
        {
            await DeleteDatabase();
            await CreateDatabase();
            Init();

        }
        public static void Init()
        {
            using var dbcontext = new MyDbContext();
            var listPermissionEntity = new List<RoleEntity>()
            {
                new RoleEntity{RoleName = "Administrator"},
                new RoleEntity{RoleName = "Manager"},
                new RoleEntity{RoleName = "Stocker"}
            };
            listPermissionEntity.ForEach( o =>  dbcontext.Add(o));
            var user1 = new UserEntity
            {
                UserName = "crackertvn",
                PassWord = "$2a$11$ew1SDZWnBOiPna6ZHaTWHuhEELiDGAan8/6cvBI6gCgWZ17vJB0oG", //123456
                SurName = "Trung",
                GivenName = "Tran",
                RoleId = 1,
            };

             dbcontext.Add(user1);

            var productType = new ProductTypeEntity { ProductTypeName = "Hàng thực phẩm" };
            dbcontext.Add(productType);
            dbcontext.SaveChanges();

            var product = new ProductEntity
            {
                ProductName = "Thịt bò",
                ProductOrgin = "Việt Nam",
                ProductSuplier = "Công ty thực phẩm",
                ProductTypeId = 1,
                ProductUnit = "1 hộp"
            };
            dbcontext.Add(product);
            dbcontext.SaveChanges();

            var productBatch = new ProductBatchEntity
            {
                ProductId = 1,
                ProductBatchName = "Lô thịt bò",
                ProductQuantity = 100,
                DateExpiry = "05/09/2022"
            };
            dbcontext.Add(productBatch);
            dbcontext.SaveChanges();

            var inputInfo = new InputInfoEntity { InputInfoId = 1, InputInfoName = "Nhập hàng 05/09/2022", ProductBatchId = 1, Shipper = "Trần Quang Trung", InputTime = "05/09/2022", ReceiverUserId = 1 };
            dbcontext.Add(inputInfo);
            dbcontext.SaveChanges();

            var outputInfo = new OutputInfoEntity 
            { 
                OutputInfoId = 1, 
                OutputInfoName = "Xuất hàng 05/09/2022", 
                ProductId = 1, 
                PickerUserId = 1, 
                DeliverUserId = 1, 
                OutputTime = "05/09/2022",
                ProductQuantity = 1,
            };

            dbcontext.Add(outputInfo);
            dbcontext.SaveChanges();
        }
    }
}
