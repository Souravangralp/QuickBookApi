namespace QuickBookApi.Controllers;

[ApiController]
public class QuickBooksController : ControllerBase
{
    #region Fields

    private readonly IQuickBookService _quickBookService;

    #endregion

    #region Ctor

    public QuickBooksController(IQuickBookService quickBookService)
    {
        _quickBookService = quickBookService;
    }

    #endregion

    #region Methods

    [HttpPost("/quickBooks/login")]
    public async Task<IActionResult> GetAuthorizationCode()
    {
        return Ok(await _quickBookService.GetAuthUrl());
    }

    [HttpGet("/quickBooks/redirect-url")]
    public async Task<IActionResult> RedirectUrl(string code, string state)
    {
        return Ok(await _quickBookService.Redirect(state, code));
    }

    [HttpGet("/quickBooks/accessToken")]
    public async Task<IActionResult> GetAccessToken()
    {
        return Ok(await _quickBookService.GetAccessToken());
    }


    /// <summary>
    /// Retrieves refresh Token from QuickBooks api if it accessToken got expires.
    /// </summary>
    /// <param name="refreshToken">The refresh token for generating new access token.</param>
    /// <returns>A JSON object containing the new accessToken.</returns>
    /// <response code="200">Returns the accessToken.</response>
    /// <response code="401">If the access token is invalid.</response>
    [HttpGet("/quickBooks/refreshToken")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetRefreshToken(string refreshToken)
    {
        return Ok(await _quickBookService.GetRefreshToken(refreshToken));
    }

    /// <summary>
    /// Retrieves company information from QuickBooks.
    /// </summary>
    /// <param name="accessToken">The access token for authenticating with the QuickBooks API.</param>
    /// <returns>A JSON object containing the company information.</returns>
    /// <response code="200">Returns the company data.</response>
    /// <response code="401">If the access token is invalid.</response>
    [HttpGet("/quickBooks/company")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetCompany(string accessToken)
    {
        return Ok(await _quickBookService.GetCompany(accessToken));
    }

    #region Dont remove

    //[HttpGet("/quickBooks/getUserInfo")]
    //public async Task<IActionResult> GetUserInfo(string accessToken)
    //{
    //    return Ok(await _quickBookService.GetUserInfo(accessToken));
    //}

    #endregion

    #endregion
}