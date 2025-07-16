using GazpromTest.Application.Offer.Commands;
using GazpromTest.Application.Supplier.Queries;
using GazpromTest.Mapper;
using GazpromTest.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GazpromTest.Controllers;

public class OfferController : ApiController
{
    private readonly ISender _sender;
    private readonly ApiMapper _mapper;

    public OfferController(ISender sender, ApiMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOffer(
        [FromBody] CreateOfferCommand command,
        CancellationToken cancellationToken)
    {
        var offerId = await _sender.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPost("search")]
    public async Task<IActionResult> SearchOffers(
        [FromBody] SearchOffersRequest request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.SearchOffersRequestApiToSearchOffersQueryApplication(request);
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("top-suppliers/{count}")]
    public async Task<IActionResult> GetTopSuppliers(int count, CancellationToken cancellationToken)
    {
        var suppliers = await _sender.Send(new GetTopSuppliersQuery(count), cancellationToken);
        return Ok(suppliers);
    }
}