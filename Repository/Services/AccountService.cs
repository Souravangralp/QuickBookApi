namespace QuickBookApi.Repository.Services;

public class AccountService : IAccountService
{
    #region Fields

    private readonly ITokenService _tokenService;
    private readonly HttpClient _httpClient;

    #endregion

    #region Ctor

    public AccountService(ITokenService tokenService,
        HttpClient httpClient)
    {
        _tokenService = tokenService;
        _httpClient = httpClient;
    }

    #endregion

    #region Methods

    public async Task<IntuitResponse> Create(Models.Requests.AccountRequest account, string accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, QuickBook.Route.Company.route);

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", $"{accessToken}");

        var content = System.Text.Json.JsonSerializer.Serialize(account);
        request.Content = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var res = await response.Content.ReadAsStringAsync();

        IntuitResponse intuitResponse = CommonUtility.DeserializeXml<IntuitResponse>(res);

        XmlSerializer serializer = new XmlSerializer(typeof(IntuitResponse));

        using StringReader reader = new StringReader(res);

        return (IntuitResponse)serializer.Deserialize(reader);

    }

    #endregion
}
