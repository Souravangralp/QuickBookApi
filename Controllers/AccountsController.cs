namespace QuickBookApi.Controllers;

[ApiController]
public class AccountsController : ControllerBase
{
    #region Fields

    private readonly IAccountService _accountService;

    #endregion

    #region Ctor

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    #endregion

    #region Methods

    [HttpPost("accounts")]
    public async Task<IActionResult> Create(Models.Requests.AccountRequest account, string accessToken)
    {
        var accountResponse = await _accountService.Create(account, accessToken);

        return Ok(accountResponse);
    }

    #endregion
}
