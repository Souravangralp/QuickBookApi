namespace QuickBookApi.Repository.Interfaces;

public interface IAccountService
{
    Task<IntuitResponse> Create(Models.Requests.AccountRequest account, string accessToken);
}
