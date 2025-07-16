using GazpromTest.Domain.Models;
using GazpromTest.Domain.Specifications;

namespace GazpromTest.Domain.Interfaces;

public interface IOfferRepository : IRepository<Offer, int>
{
    Task<IEnumerable<Offer>> GetAllWithFilterAsync(SearchOfferParams filter, CancellationToken cancellationToken);
    Task<IEnumerable<Supplier>> GetTopSuppliersAsync(int count, CancellationToken cancellationToken);
    Task<int> CountAsync(SearchOfferParams parameters, CancellationToken ct);
    
}