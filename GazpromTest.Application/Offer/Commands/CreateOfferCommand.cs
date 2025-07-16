using MediatR;

namespace GazpromTest.Application.Offer.Commands;

public sealed record CreateOfferCommand(
    string Brand,
    string Model,
    int SupplierId
) : IRequest<int>;