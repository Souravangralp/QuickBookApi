namespace QuickBookApi.Repository.Services;

public class TokenService : ITokenService
{
    #region Fields

    private readonly string _filePath = @"wwwroot\resources\token.json";

    #endregion

    #region Methods

    public async Task<AccessTokenResponse> Get()
    {
        if (!File.Exists(_filePath)) return null;

        var json = await File.ReadAllTextAsync(_filePath);

        return JsonConvert.DeserializeObject<AccessTokenResponse>(json) ?? new AccessTokenResponse();
    }

    public async Task<bool> Save(AccessTokenResponse accessTokenResponse)
    {
        var json = JsonConvert.SerializeObject(accessTokenResponse, Formatting.Indented);

        await File.WriteAllTextAsync(_filePath, json);

        return true;
    }

    #endregion
}
