// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;


// burada koddan migrate ediyoruz ne durumda lazım oluyor kullanıcıya yolladın :D
ECommerceDbContext context = new();
await context.Database.MigrateAsync();


 public class ECommerceDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
        optionsBuilder.UseSqlServer("Server=.;Database=ECommerceDb;Trusted_Connection=True;TrustServerCertificate=True;");                                                                             
	}

}


//Entity 
public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }

}

public class Customer
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}