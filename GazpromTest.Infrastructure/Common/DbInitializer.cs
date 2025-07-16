using Microsoft.EntityFrameworkCore;

namespace GazpromTest.Infrastructure.Common;

public class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.Migrate();

        if (context.Suppliers.Any())
            return;

        var suppliers = new List<GazpromTest.Domain.Models.Supplier>
        {
            new GazpromTest.Domain.Models.Supplier { Name = "Поставщик 1", CreatedAt = DateTime.Now.AddDays(-10) },
            new GazpromTest.Domain.Models.Supplier { Name = "Поставщик 2", CreatedAt = DateTime.Now.AddDays(-9) },
            new GazpromTest.Domain.Models.Supplier { Name = "Поставщик 3", CreatedAt = DateTime.Now.AddDays(-8) },
            new GazpromTest.Domain.Models.Supplier { Name = "Поставщик 4", CreatedAt = DateTime.Now.AddDays(-7) },
            new GazpromTest.Domain.Models.Supplier { Name = "Поставщик 5", CreatedAt = DateTime.Now.AddDays(-6) }
        };
        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        var offers = new List<GazpromTest.Domain.Models.Offer>
        {
            new GazpromTest.Domain.Models.Offer { Brand = "Toyota", Model = "Camry", SupplierId = suppliers[0].Id, RegistrationDate = DateTime.Now.AddDays(-5) },
            new GazpromTest.Domain.Models.Offer { Brand = "Toyota", Model = "Corolla", SupplierId = suppliers[0].Id, RegistrationDate = DateTime.Now.AddDays(-4) },
            new GazpromTest.Domain.Models.Offer { Brand = "Honda", Model = "Civic", SupplierId = suppliers[1].Id, RegistrationDate = DateTime.Now.AddDays(-3) },
            new GazpromTest.Domain.Models.Offer { Brand = "Honda", Model = "Accord", SupplierId = suppliers[1].Id, RegistrationDate = DateTime.Now.AddDays(-2) },
            new GazpromTest.Domain.Models.Offer { Brand = "Ford", Model = "Focus", SupplierId = suppliers[2].Id, RegistrationDate = DateTime.Now.AddDays(-1) },
            new GazpromTest.Domain.Models.Offer { Brand = "Ford", Model = "Mondeo", SupplierId = suppliers[2].Id, RegistrationDate = DateTime.Now },
            new GazpromTest.Domain.Models.Offer { Brand = "BMW", Model = "X5", SupplierId = suppliers[3].Id, RegistrationDate = DateTime.Now.AddDays(-5) },
            new GazpromTest.Domain.Models.Offer { Brand = "BMW", Model = "X3", SupplierId = suppliers[3].Id, RegistrationDate = DateTime.Now.AddDays(-4) },
            new GazpromTest.Domain.Models.Offer { Brand = "Audi", Model = "A4", SupplierId = suppliers[4].Id, RegistrationDate = DateTime.Now.AddDays(-3) },
            new GazpromTest.Domain.Models.Offer { Brand = "Audi", Model = "A6", SupplierId = suppliers[4].Id, RegistrationDate = DateTime.Now.AddDays(-2) },
            new GazpromTest.Domain.Models.Offer { Brand = "Kia", Model = "Rio", SupplierId = suppliers[0].Id, RegistrationDate = DateTime.Now.AddDays(-1) },
            new GazpromTest.Domain.Models.Offer { Brand = "Hyundai", Model = "Solaris", SupplierId = suppliers[1].Id, RegistrationDate = DateTime.Now },
            new GazpromTest.Domain.Models.Offer { Brand = "Mazda", Model = "6", SupplierId = suppliers[2].Id, RegistrationDate = DateTime.Now.AddDays(-5) },
            new GazpromTest.Domain.Models.Offer { Brand = "Volkswagen", Model = "Polo", SupplierId = suppliers[3].Id, RegistrationDate = DateTime.Now.AddDays(-4) },
            new GazpromTest.Domain.Models.Offer { Brand = "Skoda", Model = "Octavia", SupplierId = suppliers[4].Id, RegistrationDate = DateTime.Now.AddDays(-3) }
        };
        context.Offers.AddRange(offers);
        context.SaveChanges();
    }
}