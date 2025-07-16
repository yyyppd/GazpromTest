using GazpromTest.Mapper;

namespace GazpromTest.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddProblemDetails();
        services.AddHttpContextAccessor();
        services.AddScoped<ApiMapper>();
       // services.AddScoped<ApiMapper>();
        return services;
    }
}