using GazpromTest.Application.DTOs;

namespace GazpromTest.Application.Supplier.Queries;

public sealed record GetTopSuppliersResponse(IReadOnlyList<SupplierStatsDto> Suppliers);