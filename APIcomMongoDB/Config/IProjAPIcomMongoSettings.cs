namespace APIcomMongoDB.Config
{
    public interface IProjAPIcomMongoSettings
    {
        string ClientCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
