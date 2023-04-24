namespace APIcomMongoDB.Config
{
    public class ProjAPIcomMongoSettings : IProjAPIcomMongoSettings
    {
        public string ClientCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
