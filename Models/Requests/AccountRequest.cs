namespace QuickBookApi.Models.Requests;

public class AccountRequest
{
    public string Name { get; set; }
    public string AccountType { get; set; }
    public string AccountSubType { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
}