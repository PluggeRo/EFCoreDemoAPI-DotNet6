global using EFCoreDemoAPI60CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemoAPI60CodeFirst.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>
        {
            new Customer{
                Id=1,
                FirstName="Tom",
                LastName="Schmidt",
                Age=29,
                Addresses={new Address {Id=1,StreetAddress="Hauptstraße",HouseNumber="42",ZipCode="10102",City="Dreamcity",Country="Dreamland"}},
                EmailAddresses={new Email { Id=1,EmailAddress="Tom.schmidt@gmail.com"} }
            },
            new Customer{
                Id=2,
                FirstName="Sarah",
                LastName="Hollister",
                Age=34,
                Addresses={new Address {Id=1,StreetAddress="Bootshaus",HouseNumber="69",ZipCode="10102",City="Dreamcity",Country="Dreamland"}},
                EmailAddresses={new Email { Id=1,EmailAddress="Sarah.Hollister@gmail.com" } }
            }
        };


        //Normally you would not add the whole logic to the controllers
        //Otherwise you would create a constructor function to initialise a service and put the service logic code in another path


        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            //Returns a response 200 and all customers in the List
            return Ok(customers);
        }

        //Here you have to write down the parameter
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            //var customer = customers[id];
            //Alternative with Find 
            var customer = customers.Find(x => x.Id == id);
            if (customer == null)
                //BadRequest if customer is not found
                return BadRequest("Customer was not found.");
            //Returns a response 200 the requested customer from the List
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
        {
            customers.Add(customer);
            //Returns a response 200 and all customers in the List
            return Ok(customers);
        }

        //Here you have to write down the parameter
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer request)
        {
            var customer = customers.Find(x => x.Id == request.Id);
            if (customer == null)
                //BadRequest if customer is not found
                return BadRequest("Customer was not found.");

            //Quick Update works manually
            //Normally you update it for example via mapper in the class
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Age = request.Age;
            customer.Addresses = request.Addresses;
            customer.EmailAddresses = request.EmailAddresses;

            //Returns a response 200 and all customers in the List
            return Ok(customers);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var customer = customers.Find(x => x.Id == id);
            if (customer == null)
                //BadRequest if customer is not found
                return BadRequest("Customer was not found.");
            customers.Remove(customer);

            //Returns a response 200 the requested customer from the List
            return Ok(customers);
        }


    }
}
