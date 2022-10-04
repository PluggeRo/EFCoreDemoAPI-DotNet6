using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemoAPI60DBFirst.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly EFDemoDBContext _context;

        public CustomerController(EFDemoDBContext context)
        {
            _context = context;
        }

        //Describes the call of the request
        [Route("GetCustomers")]
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            //This is the approach if you are not using any DTOModels

            //The "Include" is important to get the related classes (Addresses and EmailAddresses) from the Customer model
            return Ok(await _context.Customers
                .Include(p => p.Addresses)
                .Include(p => p.EmailAddresses)
                .ToListAsync());
        }

        //Describes the call of the request
        [Route("GetCustomersWithDTO")]
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomersWithDTO()
        {
            //This is the approach if you are using DTOModels

            var list = new List<DTOModels.DTOCustomer>();

            //The "Include" is important to get the related classes (Addresses and EmailAddresses) from the Customer model
            foreach (var item in await _context.Customers
                .Include(p => p.Addresses)
                .Include(p => p.EmailAddresses)
                .ToListAsync())
            {
                list.Add(new DTOModels.DTOCustomer(item));
            }
            return Ok(list);
        }
    }
}
