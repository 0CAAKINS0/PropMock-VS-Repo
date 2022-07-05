using Microsoft.AspNetCore.Mvc;
using PropDatabaseCore;
using PropMockModels;

namespace PropMock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly PropDbContext _context;

        public ClientController(PropDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Client>> Register(string email, string companyname, string phone, string address, int lsPricing, int esPricing, int rtPricing, int tcPricing, int csPricing, int lnpPricing)
        {
            var client = new Client
            {
                email = email,
                companyName = companyname,
                phone = phone,
                address = address,
                lsPricing = lsPricing,
                esPricing = esPricing,
                rtPricing = rtPricing,
                tcPricing = tcPricing,
                csPricing = csPricing,
                lnpPricing = lnpPricing
            };
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return client;
        }

        [HttpGet("clientlist")]
        public IEnumerable<Client> Get()
        {
            return _context.Clients;
        }

        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return _context.Clients.FirstOrDefault(s => s.clientId == id);
        }
    }
}
