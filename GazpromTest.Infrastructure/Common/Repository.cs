using GazpromTest.Domain.Interfaces;

namespace GazpromTest.Infrastructure.Common;

public class Repository
{
    protected readonly IUnitOfWork _unitOfWork;
    
    protected Repository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}