namespace QuickBookApi.Repository.Services;

public class QuickBookService : IQuickBookService
{
    #region Fields

    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly ITokenService _tokenService;

    #endregion

    #region Ctor

    public QuickBookService(IConfiguration configuration,
        HttpClient httpClient,
        ITokenService tokenService)
    {
        _configuration = configuration;
        _httpClient = httpClient;
        _tokenService = tokenService;
    }

    #endregion

    #region Methods

    public async Task<string> GetAuthUrl()
    {
        var QuickBookConfig = _configuration.GetSection("QuickBooks");

        string clientId = QuickBookConfig.GetSection("CLIENT_ID").Value ?? "";
        string responseType = "code";
        string scope = string.Format(QuickBook.Scope.Accounting.scope);
        //QuickBook.Scope.Payment.scope + "," + 
        //QuickBook.Scope.Phone.scope + "," + 
        //QuickBook.Scope.Email.scope + "," + 
        //QuickBook.Scope.OpenId.scope + "," + 
        //QuickBook.Scope.Profile.scope + "," + 
        //QuickBook.Scope.Address.scope);

        string redirectUri = QuickBookConfig.GetSection("REDIRECT_URL").Value ?? "";
        string state = QuickBookConfig.GetSection("STATE").Value ?? "";
        string claims = "";

        string authUrl = $"https://appcenter.intuit.com/connect/oauth2?client_id={clientId}&response_type={responseType}&scope={scope}&redirect_uri={Uri.EscapeDataString(redirectUri)}&state={state}";

        return await Task.FromResult(authUrl);
    }

    public async Task<bool> Redirect(string state, string code)
    {
        if (string.IsNullOrEmpty(code)) throw new Exception("Please provide state and code");

        var QuickBookConfig = _configuration.GetSection("QuickBooks");

        var requestData = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "authorization_code"),
            new KeyValuePair<string, string>("code", code),
            new KeyValuePair<string, string>("redirect_uri", QuickBookConfig.GetSection("REDIRECT_URL").Value ?? ""),
            new KeyValuePair<string, string>("client_id", QuickBookConfig.GetSection("CLIENT_ID").Value ?? ""),
            new KeyValuePair<string, string>("client_secret", QuickBookConfig.GetSection("CLIENT_SECRET").Value ?? "")
        });

        var response = await _httpClient.PostAsync(QuickBook.Route.Token.route, requestData);

        if (!response.IsSuccessStatusCode) throw new Exception();

        var jsonResponse = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<AccessTokenResponse>(jsonResponse);

        result.realmId = code;

        return await _tokenService.Save(result);
    }

    public async Task<AccessTokenResponse> GetAccessToken()
    {
        return await _tokenService.Get();
    }

    public async Task<AccessTokenResponse> GetRefreshToken(string refreshToken)
    {
        var quickBookConfig = _configuration.GetSection("QuickBooks");
        var clientId = quickBookConfig.GetSection("CLIENT_ID").Value ?? "";
        var clientSecret = quickBookConfig.GetSection("CLIENT_SECRET").Value ?? "";
        var basicAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

        var request = new HttpRequestMessage(HttpMethod.Post, QuickBook.Route.Token.route);
        request.Headers.Add("Authorization", $"Basic {basicAuth}");
        
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "refresh_token" },
            { "refresh_token", refreshToken }
        });

        request.Content = content;

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error refreshing token: {response.ReasonPhrase}");
        }

        var jsonResponse = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<AccessTokenResponse>(jsonResponse)
               ?? throw new InvalidOperationException("Failed to deserialize the token response.");
    }

    public async Task<CompanyInfoResponse> GetCompany(string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{accessToken}");

        var response = await _httpClient.GetAsync(QuickBook.Route.Company.route);

        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<CompanyInfoResponse>(content) ?? new();
    }

    #region Dont remove

    //public async Task<string> GetUserInfo(string accessToken)
    //{
    //    var url = $"https://accounts.platform.intuit.com/v1/openid_connect/userinfo";

    //    using (var request = new HttpRequestMessage(HttpMethod.Get, url))
    //    {
    //        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", $"{accessToken}");

    //        var response = await _httpClient.GetAsync(url);
    //        response.EnsureSuccessStatusCode();


    //        var content = await response.Content.ReadAsStringAsync();

    //        return content;
    //    }
    //}

    #endregion

    #endregion
}
