namespace QuickBookApi.Utility.Common;

public static class CommonUtility
{
    public static T DeserializeXml<T>(string xml)
    {
        var serializer = new XmlSerializer(typeof(T));
        using (var reader = new StringReader(xml))
        {
            return (T)serializer.Deserialize(reader);
        }
    }
}