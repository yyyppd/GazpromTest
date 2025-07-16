using GazpromTest.Application.Supplier.Queries;
using GazpromTest.Models;
using Riok.Mapperly.Abstractions;

namespace GazpromTest.Mapper;
[Mapper]
public partial class ApiMapper
{
    public partial SearchOffersQuery SearchOffersRequestApiToSearchOffersQueryApplication(SearchOffersRequest request);
}