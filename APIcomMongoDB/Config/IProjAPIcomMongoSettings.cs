namespace APIcomMongoDB.Config
{
    public interface IProjAPIcomMongoSettings
    {
        string CustomerCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
