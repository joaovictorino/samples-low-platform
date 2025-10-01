namespace MongoSampleApi.Configuration;

public class MongoOptions
{
    public const string SectionName = "MongoDb";

    public string ConnectionString { get; set; } = string.Empty;

    public string DatabaseName { get; set; } = string.Empty;

    public string CollectionName { get; set; } = "todos";
}
