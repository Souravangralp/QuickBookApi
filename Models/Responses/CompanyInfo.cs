public class CompanyInfoResponse
{
    [JsonProperty("CompanyInfo")]
    public CompanyInfo CompanyInfo { get; set; }

    [JsonProperty("time")]
    public DateTime Time { get; set; }
}

public class CompanyInfo
{
    [JsonProperty("CompanyName")]
    public string CompanyName { get; set; }

    [JsonProperty("LegalName")]
    public string LegalName { get; set; }

    [JsonProperty("CompanyAddr")]
    public Address CompanyAddr { get; set; }

    [JsonProperty("CustomerCommunicationAddr")]
    public Address CustomerCommunicationAddr { get; set; }

    [JsonProperty("LegalAddr")]
    public Address LegalAddr { get; set; }

    [JsonProperty("CustomerCommunicationEmailAddr")]
    public Email CustomerCommunicationEmailAddr { get; set; }

    [JsonProperty("PrimaryPhone")]
    public object PrimaryPhone { get; set; } // Use appropriate type

    [JsonProperty("CompanyStartDate")]
    public DateTime CompanyStartDate { get; set; }

    [JsonProperty("FiscalYearStartMonth")]
    public string FiscalYearStartMonth { get; set; }

    [JsonProperty("Country")]
    public string Country { get; set; }

    [JsonProperty("Email")]
    public Email Email { get; set; }

    [JsonProperty("WebAddr")]
    public object WebAddr { get; set; } // Use appropriate type

    [JsonProperty("SupportedLanguages")]
    public string SupportedLanguages { get; set; }

    [JsonProperty("NameValue")]
    public List<NameValue> NameValue { get; set; }

    [JsonProperty("domain")]
    public string Domain { get; set; }

    [JsonProperty("sparse")]
    public bool Sparse { get; set; }

    [JsonProperty("Id")]
    public string Id { get; set; }

    [JsonProperty("SyncToken")]
    public string SyncToken { get; set; }

    [JsonProperty("MetaData")]
    public MetaData MetaData { get; set; }
}

public class Address
{
    [JsonProperty("Id")]
    public string Id { get; set; }

    [JsonProperty("Line1")]
    public string Line1 { get; set; }

    [JsonProperty("City")]
    public string City { get; set; }

    [JsonProperty("CountrySubDivisionCode")]
    public string CountrySubDivisionCode { get; set; }

    [JsonProperty("PostalCode")]
    public string PostalCode { get; set; }

    [JsonProperty("Lat")]
    public string Lat { get; set; }

    [JsonProperty("Long")]
    public string Long { get; set; }
}

public class Email
{
    [JsonProperty("Address")]
    public string Address { get; set; }
}

public class NameValue
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Value")]
    public string Value { get; set; }
}

public class MetaData
{
    [JsonProperty("CreateTime")]
    public DateTime CreateTime { get; set; }

    [JsonProperty("LastUpdatedTime")]
    public DateTime LastUpdatedTime { get; set; }
}
