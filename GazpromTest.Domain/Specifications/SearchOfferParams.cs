namespace GazpromTest.Domain.Specifications;

public sealed class SearchOfferParams
{
    public int? Id { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public IEnumerable<int>? SupplierIds { get; set; }
    
    public int? Page { get; set; }

    public int? PageSize { get; set; }
}