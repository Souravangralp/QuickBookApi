namespace QuickBookApi.Repository.Interfaces;

public interface IQuickBookService
{
    Task<string> GetAuthUrl();

    Task<bool> Redirect(string state, string code);

    Task<AccessTokenResponse> GetAccessToken();

    Task<AccessTokenResponse> GetRefreshToken(string refreshToken);

    Task<CompanyInfoResponse> GetCompany(string accessToken);
}
