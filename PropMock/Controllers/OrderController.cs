using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using PropDatabaseCore;
using PropMockModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static PropMockModels.Enums;

namespace PropMock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
       

        private readonly PropDbContext _context;

        public OrderController(PropDbContext context)
        {
            _context = context;
        }

        // GET Order
        [HttpGet("FindOrder/{filenumber}")]
        public async Task<IActionResult> DisplayProductDetails(int filenumber)
        {    
           var product = await _context.Products
                .Include(p => p.Lien)
                .Include(p => p.Estoppel)
                .Include(p => p.Tax)
                .Include(p => p.CS)
                .Include(p => p.RT)
                .Include(p => p.Order)
                .Where(o => o.filenumber == filenumber)
                .FirstOrDefaultAsync();

            if (product == null) { return NotFound(); }
            else if ((int)product.ProductType == 1 || (int)product.ProductType == 2) { return View("DisplayLSProductDetails", product); }
            else if ((int)product.ProductType == 3) { return View("DisplayESProductDetails", product); }
            else if ((int)product.ProductType == 3) { return View("DisplayESProductDetails", product); }
            else if ((int)product.ProductType == 4 || (int)product.ProductType == 5 || (int)product.ProductType == 6) { return View("DisplayTaxProductDetails", product); }
            else if ((int)product.ProductType == 7) { return View("DisplayRTProductDetails", product); }
            else if ((int)product.ProductType == 8) { return View("DisplayCSProductDetails", product); }
            else { return NotFound(); }
        }


        //Create Lien Search Order
        [HttpPost("NewLienSearchOrder")]
        public async Task<IActionResult> OrderLienSearch(string Street, string? AddressTwo, string City, string Zip, string County, string Parcel, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string? BuyerName, string? ClientFileNumber, string? additionalContactEmail, string? legalDescription, int userId, bool Code = true, bool Permit = true, bool Tax = true, bool Utility = true, bool SpecialAssessments = true, bool Refinance = false, bool Vacant = false, bool Commercial = false)
        {
            int productType = Permit ? 1 : 2;
            //if (!Permit){ productType = 2; } else { productType = 1; }
            var product = new Product((OrderType)productType, (Status)1);
            var order = new Order(userId) { Clientfilenumber = ClientFileNumber };
            var ls = new LienSearch(Street, Zip, County, City, (States)State, Parcel, Refinance, Vacant, Commercial, (DateTime)ClosingDate, (DateTime)NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, legalDescription, additionalContactEmail, ClientFileNumber, (Researcher)0, Code, Permit, Tax, Utility, SpecialAssessments) { Product = product };

            product.Lien = ls;
            order.Products.Add(product);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return View("DisplayLSFullDetails", product);
        }

        // Create Estoppel Order
        [HttpPost("NewEstoppelOrder")]
        public async Task<IActionResult> OrderEstoppelSearch(string Street, string? AddressTwo, string City, string Zip, string County, string Parcel,  States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string? BuyerName, string? ClientFileNumber, string? additionalContactEmail, string? legalDescription, int userId, bool Vacant = false, bool Commercial = false, bool Refinance = false)
        {
            var product = new Product((OrderType)3, (Status)1);
            var order = new Order(userId){ Clientfilenumber = ClientFileNumber };
            var es = new Estoppel(Street, Zip, County, City, (States)State, Parcel, Refinance, Vacant, Commercial, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, legalDescription, additionalContactEmail, ClientFileNumber, (Researcher)0) { Product = product };

            product.Estoppel = es;
            order.Products.Add(product);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return View("DisplayESFullDetails", product);
        }

        // Create Tax Cert Order
        [HttpPost("NewTaxOrder")]
        public async Task<ActionResult<string>> OrderTaxSearch(TaxOrderType TCType , string Street, string? AddressTwo, string City, string Zip, string County, string Parcel, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string? BuyerName, string? ClientFileNumber, string? additionalContactEmail, string? legalDescription, int userId, bool Refinance = false, bool Vacant = false, bool Commercial = false)
        {
            var product = new Product((OrderType)TCType, (Status)1);
            var order = new Order(userId) { Clientfilenumber = ClientFileNumber };
            var tc = new Tax(Street, Zip, County, City, (States)State, Parcel, Refinance, Vacant, Commercial, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, legalDescription, additionalContactEmail, ClientFileNumber, (Researcher)0) { Product = product };

            product.Tax = tc;
            order.Products.Add(product);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return View("DisplayTaxFullDetails", product);
        }

        // Create Release Tracking Order
        [HttpPost("NewReleaseTrackingOrder")]
        public async Task<IActionResult> OrderReleaseTracking(string Street, string? AddressTwo, string City, string Zip, string County, string Parcel, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string? OwnerEmail, string? BuyerName, string? BuyerEmail, string? ClientFileNumber, string? additionalContactEmail, string? legalDescription, int userId, bool Refinance = false, bool Vacant = false, bool Commercial = false)
        {
            var product = new Product((OrderType)7, (Status)1);
            var order = new Order(userId) { Clientfilenumber = ClientFileNumber };
            var rt = new ReleaseTracking(Street, Zip, County, City, (States)State, Parcel, Refinance, Vacant, Commercial, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, legalDescription, additionalContactEmail, ClientFileNumber, (Researcher)0, OwnerEmail, BuyerEmail) { Product = product };

            product.RT = rt;
            order.Products.Add(product);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return View("DisplayRTFullDetails", product);
        }

        // Creating Curative Services Order
        [HttpPost("NewCurativeServicesOrder")]
        public async Task<IActionResult> OrderCurativeServices(string Street, string? AddressTwo, string City, string Zip, string County, string Parcel, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string? OwnerEmail, string? BuyerName, string? BuyerEmail, string? ClientFileNumber, string? additionalContactEmail, string? legalDescription, int userId, bool Refinance = false, bool Vacant = false, bool Commercial = false)
        {
            var product = new Product((OrderType)8, (Status)1);
            var order = new Order(userId) { Clientfilenumber = ClientFileNumber };
            var cs = new CurativeServices(Street, Zip, County, City, (States)State, Parcel, Refinance, Vacant, Commercial, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, legalDescription, additionalContactEmail, ClientFileNumber, (Researcher)0, OwnerEmail, BuyerEmail) { Product = product };

            product.CS = cs;
            order.Products.Add(product);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return View("DisplayCSFullDetails", product);
        }

        // Update Order
        [HttpPost("Edit/{filenumber}")]
        public async Task<IActionResult> UpdateOrder(int filenumber, string? Street, string? AddressTwo, string? City, string? Zip, string? County, string? Parcel, States? State, DateTime? ClosingDate, DateTime? NeedByDate, bool? Rush, string? AdditionalComments, string? OwnerName, string? BuyerName, string? ClientFileNumber, string? additionalContactEmail, string? legalDescription, bool? Code, bool? Permit, bool? Tax, bool? Utility, bool? SpecialAssessments, bool? Refinance, bool? Commercial, string? OwnerEmail, string? BuyerEmail, bool? Vacant, Researcher? researcher)
        {
            var product = _context.Products.Include(p => p.Lien).Include(p => p.Estoppel).Include(p => p.Tax).Include(p => p.CS).Include(p => p.RT).Where(o => o.filenumber == filenumber).FirstOrDefault();
            if ((int)product.ProductType == 1 || (int)product.ProductType == 2)
            {
                product.Lien = (LienSearch)product.Lien.EditOrder(Street, Zip, County, Parcel, City, State, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, ClientFileNumber, additionalContactEmail, legalDescription, Refinance, Commercial, Vacant, researcher, Code, Permit, Tax, Utility, SpecialAssessments);
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return View("DisplayLSFullDetails", product);
            }
            else if((int)product.ProductType == 3)
            {
                product.Estoppel = (Estoppel)product.Estoppel.EditOrder(Street, Zip, County, Parcel, City, State, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, ClientFileNumber, additionalContactEmail, legalDescription, Refinance, Commercial, Vacant, researcher);
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return View("DisplayESFullDetails", product);
            }
            else if ((int)product.ProductType == 4 || (int)product.ProductType == 5 || (int)product.ProductType == 6)
            {
                product.Tax = (Tax)product.Tax.EditOrder(Street, Zip, County, Parcel, City, State, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, ClientFileNumber, additionalContactEmail, legalDescription, Refinance, Commercial, Vacant, researcher);
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return View("DisplayTaxFullDetails", product);
            }
            else if((int)product.ProductType == 7)
            {
                product.RT = (ReleaseTracking)product.RT.EditOrder(Street, Zip, County, Parcel, City, State, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, ClientFileNumber, additionalContactEmail, legalDescription, Refinance, Commercial, Vacant, researcher, BuyerEmail, OwnerEmail);
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return View("DisplayRTFullDetails", product);
            }
            else if((int)product.ProductType == 8)
            {
                product.CS = (CurativeServices)product.CS.EditOrder(Street, Zip, County, Parcel, City, State, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, ClientFileNumber, additionalContactEmail, legalDescription, Refinance, Commercial, Vacant, researcher, BuyerEmail, OwnerEmail);
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return View("DisplayRTFullDetails", product);
            }
            else
            {
                return NotFound();
            }
        }

        // Cancel Order
        [HttpPost("CancelOrder/{filenumber}")]
        public async Task<IActionResult> Cancelorder(int filenumber)
        {
            var product = _context.Products.Where(o => o.filenumber == filenumber).FirstOrDefault();
            if (product != null)
            {
                product.OrderStatus = 0;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return View("DisplayProductDetails");
            }
            else { return NotFound(); }
        }

        // Un-Cancel Order
        [HttpPost("UnCancelOrder/{filenumber}")]
        public async Task<IActionResult> UnCancelorder(int filenumber)
        {
            var product = _context.Products.Where(o => o.filenumber == filenumber).FirstOrDefault();
            if(product != null)
            {
                product.OrderStatus = (Status)1;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return View("DisplayProductDetails");
            }
            else { return NotFound(); }
        }

        // Delete Order
        [HttpDelete("delete/{filenumber}")]
        public async Task<IActionResult> Delete(int filenumber)
        {
            var product = _context.Products.Include(p => p.Order).Where(o => o.filenumber == filenumber).FirstOrDefault();
            if(product != null) 
            {
                _context.Products.Remove(product);           
                await _context.SaveChangesAsync();
                return View(product);
            }
            else { return NotFound(); }
        }

    }
}
