using GazpromTest.Application.DTOs;
using GazpromTest.Domain.Interfaces;
using MediatR;

namespace GazpromTest.Application.Supplier.Queries;

public sealed class GetTopSuppliersHandler 
    : IRequestHandler<GetTopSuppliersQuery, GetTopSuppliersResponse>
{
    private readonly IOfferRepository _offerRepository;

    public GetTopSuppliersHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public async Task<GetTopSuppliersResponse> Handle(
        GetTopSuppliersQuery request, 
        CancellationToken cancellationToken)
    {
        var suppliers = await _offerRepository.GetTopSuppliersAsync(request.Count, cancellationToken);
        
        return new GetTopSuppliersResponse(
            suppliers.Select(SupplierStatsDto.MapFromEntity).ToList()
        );
    }
}