using APIcomMongoDB.Config;
using APIcomMongoDB.Models;
using MongoDB.Driver;

namespace APIcomMongoDB.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(IProjAPIcomMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>(settings.ClientCollectionName);
        }

        public List<Customer> Get() => _customer.Find(c => true).ToList(); // pegando tudo sem filtro algum.
        public Customer Get(string id) => _customer.Find<Customer>(c => c.Id == id).FirstOrDefault();
        
        public Customer Create(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }

        public void Update (string id, Customer customer) => _customer.ReplaceOne(c => c.Id == id, customer);
        public void Delete(string id) => _customer.DeleteOne(c => c.Id == id);
        public void Delete(Customer customer) => _customer.DeleteOne(c => c.Id == customer.Id);
        
    }
}
