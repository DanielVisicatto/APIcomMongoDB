namespace APIcomMongoDB.Config
{
    public class ProjAPIcomMongoSettings : IProjAPIcomMongoSettings
    {
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
