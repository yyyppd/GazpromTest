using GazpromTest.Domain.Interfaces;
using GazpromTest.Domain.Models;
using GazpromTest.Domain.Specifications;
using GazpromTest.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace GazpromTest.Infrastructure.Repositories;

public class OfferRepository : Repository, IOfferRepository
{
    private readonly AppDbContext _context;

    public OfferRepository(IUnitOfWork unitOfWork, AppDbContext context) : base(unitOfWork)
    {
        _context = context;
    }

    public Task<IReadOnlyList<Domain.Models.Offer>> GetAllAsync(int limit, int page, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Models.Offer> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddAsync(Domain.Models.Offer entity, CancellationToken cancellationToken)
    {
        var offer = await _context.AddAsync(entity, cancellationToken);  
        return offer.Entity.Id;
    }

    public Task<int> UpdateAsync(Domain.Models.Offer entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Domain.Models.Offer>> GetAllWithFilterAsync(SearchOfferParams filter, CancellationToken cancellationToken)
    {
        var query = BuildFilteredQuery(filter)
            .Include(o => o.Supplier)
            .AsNoTracking();
        
        if (filter.Page.HasValue && filter.PageSize.HasValue)
        {
            int page = filter.Page.Value > 0 ? filter.Page.Value : 1;
            int pageSize = filter.PageSize.Value > 0 ? 
                Math.Min(filter.PageSize.Value, 100) : 10;
        
            query = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
        
        return await query.ToListAsync(cancellationToken);
    }
    
    private IQueryable<Domain.Models.Offer> BuildFilteredQuery(SearchOfferParams filter)
    {
        var query = _context.Offers.AsQueryable();

        if (filter.Id.HasValue)
        {
            query = query.Where(o => o.Id == filter.Id.Value);
        }

        if (!string.IsNullOrWhiteSpace(filter.Brand))
        {
            query = query.Where(o => o.Brand.Contains(filter.Brand));
        }

        if (!string.IsNullOrWhiteSpace(filter.Model))
        {
            query = query.Where(o => o.Model.Contains(filter.Model));
        }

        if (filter.SupplierIds != null && filter.SupplierIds.Any())
        {
            query = query.Where(o => filter.SupplierIds.Contains(o.SupplierId));
        }

        return query;
    }


    public async Task<IEnumerable<Supplier>> GetTopSuppliersAsync(int count, CancellationToken cancellationToken)
    {
        return await _context.Suppliers.Include(s => s.Offers)
            .OrderByDescending(s => s.Offers.Count)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(SearchOfferParams parameters, CancellationToken ct)
    {
        return await BuildFilteredQuery(parameters).CountAsync(ct);
    }
}