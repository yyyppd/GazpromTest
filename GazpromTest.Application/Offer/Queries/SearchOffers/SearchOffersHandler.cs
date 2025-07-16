using GazpromTest.Application.DTOs;
using GazpromTest.Domain.Interfaces;
using GazpromTest.Domain.Specifications;
using MediatR;

namespace GazpromTest.Application.Supplier.Queries;

public sealed class SearchOffersHandler : IRequestHandler<SearchOffersQuery, SearchOffersResponse>
{
    private readonly IOfferRepository _offerRepository;

    public SearchOffersHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public async Task<SearchOffersResponse> Handle(SearchOffersQuery request, CancellationToken cancellationToken)
    {
        var filter = new SearchOfferParams
        {
            Id = request.Id,
            Brand = request.Brand,
            Model = request.Model,
            SupplierIds = request.SupplierIds,
            PageSize = request.PageSize,
            Page = request.Page,
        };
        
        var offers = await _offerRepository.GetAllWithFilterAsync(filter, cancellationToken);
        
        var totalCount = await _offerRepository.CountAsync(filter, cancellationToken);

        return new SearchOffersResponse(
            offers.Select(OfferDto.MapFromEntity).ToList(),
            totalCount
        );
    }
}