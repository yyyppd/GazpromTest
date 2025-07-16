namespace GazpromTest.Application.DTOs;

public sealed record  OfferDto(
    int Id,
    string Brand,
    string Model,
    string SupplierName,
    DateTime RegistrationDate
)
{
    public static OfferDto MapFromEntity(Domain.Models.Offer offer)
    {
        return new OfferDto(
            Id: offer.Id,
            Brand: offer.Brand,
            Model: offer.Model,
            SupplierName: offer.Supplier.Name,
            RegistrationDate: offer.RegistrationDate
        );
    }
}