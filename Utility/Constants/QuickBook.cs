namespace QuickBookApi.Utility.Constants;

public static class QuickBook
{
    public record Route(string route)
    {
        //public static readonly Route Base = new("https://appcenter.intuit.com/connect/oauth2");

        public static readonly Route Auth = new("https://appcenter.intuit.com/connect/oauth2");

        public static readonly Route Token = new("https://oauth.platform.intuit.com/oauth2/v1/tokens/bearer");
        
        public static readonly Route AuthToken = new("https://oauth.platform.intuit.com/op/v1");

        public static readonly Route User = new("https://sandbox-accounts.platform.intuit.com/v1/openid_connect/userinfo");

        public static readonly Route SandBoxBase = new("https://sandbox-quickbooks.api.intuit.com/");

        public static readonly Route Company = new(SandBoxBase.route + "v3/company/9341453354905296/companyinfo/9341453354905296");

        public static readonly Route Account = new(SandBoxBase.route + "v3/company/9341453354905296/account?minorversion=73");

        public static readonly Route RefreshToken = new(SandBoxBase.route + "/oauth2/v1/tokens/beare");

    }

    public record Scope(string scope)
    {
        public static readonly Scope Accounting = new("com.intuit.quickbooks.accounting");

        public static readonly Scope Payment = new("com.intuit.quickbooks.payment");

        public static readonly Scope OpenId = new("Openid");

        public static readonly Scope Profile = new("Profile");

        public static readonly Scope Address = new("Address");

        public static readonly Scope Email = new("Email");

        public static readonly Scope Phone = new("Phone");
    }
}
