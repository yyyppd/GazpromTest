using GazpromTest.Application.DTOs;

namespace GazpromTest.Application.Supplier.Queries;

public sealed record SearchOffersResponse(

    IReadOnlyList<OfferDto> Offers,
    int TotalCount
);