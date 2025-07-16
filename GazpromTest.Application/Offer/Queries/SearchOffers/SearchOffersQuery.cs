using MediatR;

namespace GazpromTest.Application.Supplier.Queries;

public sealed record SearchOffersQuery(
    int? Id,
    string? Brand,
    string? Model,
    IEnumerable<int>? SupplierIds, 
    int? Page,
    int? PageSize
) : IRequest<SearchOffersResponse>;