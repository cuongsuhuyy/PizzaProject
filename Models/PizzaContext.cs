using Microsoft.EntityFrameworkCore;

namespace BEPizza.Models
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {
            
        }

        private string RandomString()
        {
            Guid guid = Guid.NewGuid();
            string randomString = guid.ToString("N").Substring(0, 8);
            return randomString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SizePizza>().HasMany(e => e.Pizzas).WithOne(e => e.SizePizza).HasForeignKey("SizePizzaID").IsRequired(false);
            modelBuilder.Entity<TypeUser>().HasMany(e => e.Users).WithOne(e => e.TypeUser).HasForeignKey("TypeUserID").IsRequired(false);
            modelBuilder.Entity<Order>().HasMany(e => e.OrderDetails).WithOne(e => e.Order).HasForeignKey("OrderID").IsRequired();
            modelBuilder.Entity<User>().HasMany(e => e.OrderDetails).WithOne(e => e.User).HasForeignKey("UserID").IsRequired();
            modelBuilder.Entity<Pizza>().HasMany(e => e.OrderDetails).WithOne(e => e.Pizza).HasForeignKey("PizzaID").IsRequired();

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { ID = 1, PizzaID = RandomString(), PizzaName = "Pizza Pho Mai", Price = 100000, UnitPrice = "VND" },
                new Pizza { ID = 2, PizzaID = RandomString(), PizzaName = "Pizza Xuc Xich", Price = 100000, UnitPrice = "VND" },
                new Pizza { ID = 3, PizzaID = RandomString(), PizzaName = "Pizza Bo", Price = 100000, UnitPrice = "VND" },
                new Pizza { ID = 4, PizzaID = RandomString(), PizzaName = "Pizza Mi Y", Price = 100000 , UnitPrice = "VND" },
                new Pizza { ID = 5, PizzaID = RandomString(), PizzaName = "Pizza Rau Cu", Price = 100000 , UnitPrice = "VND" },
                new Pizza { ID = 6, PizzaID = RandomString(), PizzaName = "Pizza Heo", Price = 100000 , UnitPrice = "VND" },
                new Pizza { ID = 7, PizzaID = RandomString(), PizzaName = "Pizza Pho Mai Tuoi", Price = 100000 , UnitPrice = "VND" },
                new Pizza { ID = 8, PizzaID = RandomString(), PizzaName = "Pizza Heo Quay", Price = 100000 , UnitPrice = "VND" },
                new Pizza { ID = 9, PizzaID = RandomString(), PizzaName = "Pizza Thit Ba Chi", Price = 100000 , UnitPrice = "VND" },
                new Pizza { ID = 10, PizzaID = RandomString(), PizzaName = "Pizza Ca Chua", Price = 100000 , UnitPrice = "VND" },
                new Pizza { ID = 11, PizzaID = RandomString(), PizzaName = "Pizza Sau Rieng", Price = 100000 , UnitPrice = "VND" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { ID = 1, UserID = RandomString(), UserName = "Test01", Password = "Test01", Email = "Test01@gmail.com", PhoneNumber = "0123456789" },
                new User { ID = 2, UserID = RandomString(), UserName = "Test02", Password = "Test02", Email = "Test02@gmail.com", PhoneNumber = "0231564987" },
                new User { ID = 3, UserID = RandomString(), UserName = "Test03", Password = "Test03", Email = "Test03@gmail.com", PhoneNumber = "0948567123" }
                );

            modelBuilder.Entity<TypeUser>().HasData(
                new TypeUser { ID = 1, TypeID = RandomString(), TypeName = "Guest" },
                new TypeUser { ID = 2, TypeID = RandomString(), TypeName = "Bronze" },
                new TypeUser { ID = 3, TypeID = RandomString(), TypeName = "Silver" },
                new TypeUser { ID = 4, TypeID = RandomString(), TypeName = "Gold" }
                );

            modelBuilder.Entity<SizePizza>().HasData(
                new SizePizza { ID = 1, SizeID = RandomString(), SizeName = "S" },
                new SizePizza { ID = 2, SizeID = RandomString(), SizeName = "M" },
                new SizePizza { ID = 3, SizeID = RandomString(), SizeName = "L" },
                new SizePizza { ID = 4, SizeID = RandomString(), SizeName = "XS" },
                new SizePizza { ID = 5, SizeID = RandomString(), SizeName = "XM" },
                new SizePizza { ID = 6, SizeID = RandomString(), SizeName = "XL" }
                );
        }

        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<SizePizza> SizePizza { get; set; }
        public DbSet<TypeUser> TypeUser { get; set; }
        public DbSet<User> User { get; set; }

    }
}
