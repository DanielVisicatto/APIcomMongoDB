using APIcomMongoDB.Models;
using APIcomMongoDB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace APIcomMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService) => _customerService = customerService;

        [HttpGet]
        public ActionResult<List<Customer>> Get() => _customerService.Get();

        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _customerService.Get(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer>Create(Customer customer)
        {
            return _customerService.Create(customer); // aqui faz numa pancada só leitura e escrita;
            //return CreatedAtRoute("GetClient", new {id = customer.Id}, customer); poderia retornar desta maneita tb.
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<Customer> Update (string id, Customer customer)
        {
            var c = _customerService.Get(id);
            if(c == null) return NotFound();

            _customerService.Update(id, customer);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if(id == null) return NotFound();

            var customer = _customerService.Get(id);
            if(customer == null) return NotFound();

            _customerService.Delete(id);
            return Ok();
        }
    }
}
