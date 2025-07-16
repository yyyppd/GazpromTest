using GazpromTest.Application.DTOs;
using GazpromTest.Application.Supplier.Queries;

namespace GazpromTest.Models;

public sealed record SearchOffersRequest(
    int? Id = null,
    string? Brand = null,
    string? Model = null,
    IEnumerable<int>? SupplierIds = null,
    int? Page = null,
    int? PageSize = null
);