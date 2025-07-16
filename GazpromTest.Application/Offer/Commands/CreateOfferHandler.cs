using GazpromTest.Domain.Interfaces;
using GazpromTest.Domain.Models;
using MediatR;

namespace GazpromTest.Application.Offer.Commands;

public class CreateOfferHandler : IRequestHandler<CreateOfferCommand, int>
{
    private readonly IOfferRepository _offerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOfferHandler(
        IOfferRepository offerRepository,
        IUnitOfWork unitOfWork)
    {
        _offerRepository = offerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = new Domain.Models.Offer()
        {
            Brand = request.Brand,
            Model = request.Model,
            SupplierId = request.SupplierId,
            RegistrationDate = DateTime.UtcNow
        };

        var id = await _offerRepository.AddAsync(offer, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        return id;
    }
}