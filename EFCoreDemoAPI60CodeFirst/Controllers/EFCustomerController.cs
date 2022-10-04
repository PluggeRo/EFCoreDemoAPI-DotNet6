using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemoAPI60CodeFirst.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class EFCustomerController : ControllerBase
    {
        private readonly DataContext _context;
        public EFCustomerController(DataContext context)
        {
            _context = context;
        }

        //Normally you would not add the whole logic to the controllers
        //Otherwise you would create a constructor function to initialise a service and put the service logic code in another path

        //Sescribes the call of the request
        [Route("GetCustomers")]
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            //Returns a response 200 and all customers in the List
            return Ok(await _context.Customers.ToListAsync());
        }

        //Here you have to write down the parameter
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                //BadRequest if customer is not found
                return BadRequest("Customer was not found.");
            //Returns a response 200 the requested customer from the List
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            //Returns a response 200 and all customers in the List
            return Ok(await _context.Customers.ToListAsync());
        }

        //Here you have to write down the parameter
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer request)
        {
            var dbCustomer = await _context.Customers.FindAsync(request.Id);
            if (dbCustomer == null)
                //BadRequest if customer is not found
                return BadRequest("Customer was not found.");

            //Quick Update works manually
            //Normally you update it for example via mapper in the class
            dbCustomer.FirstName = request.FirstName;
            dbCustomer.LastName = request.LastName;
            dbCustomer.Age = request.Age;
            dbCustomer.Addresses = request.Addresses;
            dbCustomer.EmailAddresses = request.EmailAddresses;

            await _context.SaveChangesAsync();

            //Returns a response 200 and all customers in the List
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var dbCustomer = await _context.Customers.FindAsync(id);
            if (dbCustomer == null)
                //BadRequest if customer is not found
                return BadRequest("Customer was not found.");

            _context.Customers.Remove(dbCustomer);

            await _context.SaveChangesAsync();

            //Returns a response 200 the requested customer from the List
            return Ok(await _context.Customers.ToListAsync());
        }
    }
}
