namespace GazpromTest.Application.DTOs;

public sealed record SupplierStatsDto(
    int SupplierId,
    string SupplierName,
    int OffersCount
)
{
    public static SupplierStatsDto MapFromEntity(Domain.Models.Supplier supplier)
    {
        return new SupplierStatsDto(
            SupplierId: supplier.Id,
            SupplierName: supplier.Name,
            OffersCount: supplier.Offers?.Count ?? 0
        );
    }
}