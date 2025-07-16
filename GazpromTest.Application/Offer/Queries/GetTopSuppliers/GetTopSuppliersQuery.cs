using MediatR;

namespace GazpromTest.Application.Supplier.Queries;

public sealed record GetTopSuppliersQuery(int Count) : IRequest<GetTopSuppliersResponse>;
