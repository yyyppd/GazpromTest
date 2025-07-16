using GazpromTest.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GazpromTest.Infrastructure.Common;

public class AppDbContext : DbContext, IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<GazpromTest.Domain.Models.Offer> Offers { get; set; }
    public DbSet<GazpromTest.Domain.Models.Supplier> Suppliers { get; set; }
    
    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await SaveChangesAsync(cancellationToken);
    }
}