using Microsoft.EntityFrameworkCore;
using WAREHOUSE.Repositories;
using WAREHOUSE.Models;
using WAREHOUSE.Entities;
namespace WAREHOUSE.Services
{
    
    public class InitDatabase
    {
        public static async void CreateDatabase()
        {
            using var dbcontext = new MyDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            var result = await dbcontext.Database.EnsureCreatedAsync();
            string resultstring = result ? "tao db thanh  cong" : "db da ton tai";
            Console.WriteLine($"CSDL {dbname} : {resultstring}");
        }
        public static async void DeleteDatabase()
        {

            using (var context = new MyDbContext())
            {
                String databasename = context.Database.GetDbConnection().Database;
                
                bool deleted = await context.Database.EnsureDeletedAsync();
                string deletionInfo = deleted ? "đa xoa" : "khong xoa duoc";
                Console.WriteLine($"{databasename} {deletionInfo}");

            }

        }
        public static void Init()
        {
            var user1 = new UserEntity
            { 
                UserName = "crackertvn",
                PassWord = "$2a$11$ew1SDZWnBOiPna6ZHaTWHuhEELiDGAan8/6cvBI6gCgWZ17vJB0oG", //123456
                SurName = "Trung", 
                Role = "Administrator", 
                GivenName = "Tran"
            };
            using var dbcontext = new MyDbContext();
            

            dbcontext.users.Add(user1);
            dbcontext.SaveChanges();
            
        }


    }
}
