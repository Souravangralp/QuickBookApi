namespace QuickBookApi;

public static class DependencyInjection
{
    public static IServiceCollection InjectDependency(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IQuickBookService, QuickBookService>();
        services.AddScoped<IAccountService, AccountService>();

        return services;
    }
}
