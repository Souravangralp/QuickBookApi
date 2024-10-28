namespace QuickBookApi.Models.Responses
{
    [XmlRoot(ElementName = "MetaData")]
    public class MetaData
    {
        [XmlElement(ElementName = "CreateTime")]
        public DateTime CreateTime { get; set; }

        [XmlElement(ElementName = "LastUpdatedTime")]
        public DateTime LastUpdatedTime { get; set; }
    }

    [XmlRoot(ElementName = "CurrencyRef")]
    public class CurrencyRef
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Account")]
    public class Account
    {
        [XmlElement(ElementName = "Id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "SyncToken")]
        public int SyncToken { get; set; }

        [XmlElement(ElementName = "MetaData")]
        public MetaData MetaData { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "SubAccount")]
        public bool SubAccount { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "FullyQualifiedName")]
        public string FullyQualifiedName { get; set; }

        [XmlElement(ElementName = "Active")]
        public bool Active { get; set; }

        [XmlElement(ElementName = "Classification")]
        public string Classification { get; set; }

        [XmlElement(ElementName = "AccountType")]
        public string AccountType { get; set; }

        [XmlElement(ElementName = "AccountSubType")]
        public string AccountSubType { get; set; }

        [XmlElement(ElementName = "CurrentBalance")]
        public decimal CurrentBalance { get; set; } // Change to decimal

        [XmlElement(ElementName = "CurrentBalanceWithSubAccounts")]
        public decimal CurrentBalanceWithSubAccounts { get; set; } // Change to decimal

        [XmlElement(ElementName = "CurrencyRef")]
        public CurrencyRef CurrencyRef { get; set; }

        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }

        [XmlAttribute(AttributeName = "sparse")]
        public bool Sparse { get; set; }
    }

    [XmlRoot(ElementName = "IntuitResponse", Namespace = "http://schema.intuit.com/finance/v3")]
    public class IntuitResponse
    {
        [XmlElement(ElementName = "Account")]
        public Account Account { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlAttribute(AttributeName = "time")]
        public DateTime Time { get; set; }
    }
}