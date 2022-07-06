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
        public string Get(int filenumber)
        {
      
           var product = _context.Products.Include(p => p.Lien).Include(p => p.Estoppel).Include(p => p.Tax).Include(p => p.CS).Include(p => p.RT).Where(o => o.filenumber == filenumber).FirstOrDefault();
           return product.DisplayProductDetails();
            //var order = _context.Orders.Where(o => o.orderId == orderDetails.orderId).FirstOrDefault();
           
            //if (orderDetails.productType == 1 || orderDetails.productType == 2)
            //{
            //    var ls = order.LienSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
            //    return "File #: " + ls.filenumber + "    Product Type: Lien Search    Property Address: " + ls.Street + " " + ls.City + " " + ls.State + ", " + ls.Zip;
            //}
            //else if(orderDetails.productType == 3)
            //{
            //    var es = _context.EstoppelSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
            //    return "File #: " + es.filenumber + "    Product Type: Estoppel    Property Address: " + es.Street + " " + es.City + " " + es.State + ", " + es.Zip;
            //}
            //else if (orderDetails.productType == 4)
            //{
            //    var tc = _context.TaxSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
            //    return "File #: " + tc.filenumber + "    Product Type: Tax Cert    Property Address: " + tc.Street + " " + tc.City + " " + tc.State + ", " + tc.Zip;
            //}
            //else if (orderDetails.productType == 5)
            //{
            //    var tc = _context.TaxSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
            //    return "File #: " + tc.filenumber + "    Product Type: Tax Cert Basic    Property Address: " + tc.Street + " " + tc.City + " " + tc.State + ", " + tc.Zip;
            //}
            //else if (orderDetails.productType == 6)
            //{
            //    var tc = _context.TaxSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
            //    return "File #: " + tc.filenumber + "    Product Type: Tax Cert HOA   Property Address: " + tc.Street + " " + tc.City + " " + tc.State + ", " + tc.Zip;
            //}
            //else if (orderDetails.productType == 7)
            //{
            //    var rt = _context.RTSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
            //    return "File #: " + rt.filenumber + "    Product Type: Release Tracking    Property Address: " + rt.Street + " " + rt.City + " " + rt.State + ", " + rt.Zip;
            //}
            //else if (orderDetails.productType == 8)
            //{
            //    var cs = _context.CSSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
            //    return "File #: " + cs.filenumber + "    Product Type: Curative Services    Property Address: " + cs.Street + " " + cs.City + " " + cs.State + ", " + cs.Zip;
            //}
            //return "Order not found";
        }


        //Create Lien Search Order
        [HttpPost("NewLienSearchOrder")]
        public async Task<string> OrderLienSearch(string Street, string Zip, string County, string Parcel, string City, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string? BuyerName, string? AddressTwo, string? clientNumber, string? additionalContactEmail, string? legalDescription, int userId, bool Code = true, bool Permit = true, bool Tax = true, bool Utility = true, bool SpecialAssessments = true, bool Refinance = false, bool Vacant = false, bool Commercial = false)
        {
            int productType;
            if (!Permit){ productType = 2; } else { productType = 1; }
            var product = new Product((OrderType)productType, (Status)1);

            var order = new Order(userId) { Clientfilenumber = clientNumber };

            var ls = new LienSearch(Street, Zip, County, City, (States)State, Parcel, Refinance, Vacant, Commercial, (DateTime)ClosingDate, (DateTime)NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, legalDescription, additionalContactEmail, clientNumber, (Researcher)0, Code, Permit, Tax, Utility, SpecialAssessments) { Product = product };

            product.Lien = ls;
            order.Products.Add(product);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return "Your lien search order for " + Street + " has been placed! File # " + product.filenumber;
        }

        // Create Estoppel Order
        [HttpPost("NewEstoppelOrder")]
        public async Task<ActionResult<string>> OrderEstoppelSearch(string Street, string Zip, string County, string Parcel, string City, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string BuyerName, string? AddressTwo, string? clientNumber, string? additionalContactEmail, string? legalDescription, int userId, bool Vacant = false, bool Commercial = false, bool Refinance = false)
        {
            var product = new Product((OrderType)3, (Status)1);

            var order = new Order(userId){ Clientfilenumber = clientNumber };

            var es = new Estoppel(Street, Zip, County, City, (States)State, Parcel, Refinance, Vacant, Commercial, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, legalDescription, additionalContactEmail, clientNumber, (Researcher)0) { Product = product };

            product.Estoppel = es;
            order.Products.Add(product);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return "Your estoppel order for " + Street + " has been placed! File # " + product.filenumber;
        }

        // Create Tax Cert Order
        [HttpPost("NewTaxOrder")]
        public async Task<ActionResult<string>> OrderTaxSearch(TaxOrderType TCType , string Street, string Zip, string County, string Parcel, string City, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string BuyerName, string? AddressTwo, string? clientNumber, string? additionalContactEmail, string? legalDescription, int userId, bool Refinance = false, bool Vacant = false, bool Commercial = false)
        {

            var product = new Product((OrderType)TCType, (Status)1);

            var order = new Order(userId) { Clientfilenumber = clientNumber };

            var tc = new Tax(Street, Zip, County, City, (States)State, Parcel, Refinance, Vacant, Commercial, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, legalDescription, additionalContactEmail, clientNumber, (Researcher)0) { Product = product };

            product.Tax = tc;
            order.Products.Add(product);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return "Your tax cert order for " + Street + " has been placed! File # " + product.filenumber;
        }

        // Create Release Tracking Order
        [HttpPost("NewReleaseTrackingOrder")]
        public async Task<ActionResult<string>> OrderReleaseTracking(string Street, string Zip, string County, string Parcel, string City, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string? OwnerEmail, string? BuyerName, string? BuyerEmail, string? AddressTwo, string? clientNumber, string? additionalContactEmail, string? legalDescription, int userId, bool Refinance = false, bool Vacant = false, bool Commercial = false)
        {
            var product = new Product((OrderType)7, (Status)1);

            var order = new Order(userId) { Clientfilenumber = clientNumber };

            var rt = new ReleaseTracking(Street, Zip, County, City, (States)State, Parcel, Refinance, Vacant, Commercial, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, legalDescription, additionalContactEmail, clientNumber, (Researcher)0, OwnerEmail, BuyerEmail) { Product = product };

            product.RT = rt;
            order.Products.Add(product);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return "Your release tracking order for " + Street + " has been placed! File # " + product.filenumber;
        }

        // Creating Curative Services Order
        [HttpPost("NewCurativeServicesOrder")]
        public async Task<ActionResult<string>> OrderCurativeServices(string Street, string Zip, string County, string Parcel, string City, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string? OwnerEmail, string? BuyerName, string? BuyerEmail, string? AddressTwo, string? clientNumber, string? additionalContactEmail, string? legalDescription, int userId, bool Refinance = false, bool Vacant = false, bool Commercial = false)
        {
            var product = new Product((OrderType)8, (Status)1);

            var order = new Order(userId) { Clientfilenumber = clientNumber };

            var cs = new CurativeServices(Street, Zip, County, City, (States)State, Parcel, Refinance, Vacant, Commercial, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, legalDescription, additionalContactEmail, clientNumber, (Researcher)0, OwnerEmail, BuyerEmail) { Product = product };

            product.CS = cs;
            order.Products.Add(product);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return "Your curative services order for " + Street + " has been placed! File # " + product.filenumber;
        }

        // Update Order
        [HttpPost("Edit/{filenumber}")]
        public async Task UpdateOrder(int filenumber, string? Street, string? Zip, string? County, string? Parcel, string? City, States? State, DateTime? ClosingDate, DateTime? NeedByDate, bool? Rush, string? AdditionalComments, string? OwnerName, string? BuyerName, string? AddressTwo, string? clientNumber, string? additionalContactEmail, string? legalDescription, bool? Code, bool? Permit, bool? Tax, bool? Utility, bool? SpecialAssessments, bool? Refinance, bool? Commercial, string? OwnerEmail, string? BuyerEmail, bool? Vacant, Researcher? researcher)
        {
            var product = _context.Products.Include(p => p.Lien).Include(p => p.Estoppel).Include(p => p.Tax).Include(p => p.CS).Include(p => p.RT).Where(o => o.filenumber == filenumber).FirstOrDefault();
            if ((int)product.ProductType == 1 || (int)product.ProductType == 2)
            {
                product.Lien = (LienSearch)product.Lien.EditOrder(Street, Zip, County, Parcel, City, (States)State, (DateTime)ClosingDate, (DateTime)NeedByDate, (bool)Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, clientNumber, additionalContactEmail, legalDescription, (bool)Refinance, (bool)Commercial, (bool)Vacant, (Researcher)researcher);
                //if (Street != null) { ls.Street = Street; }
                //if (Zip != null) { ls.Zip = Zip; }
                //if (County != null) { ls.County = County; }
                //if (Parcel != null) { ls.Parcel = Parcel; }
                //if (City != null) { ls.City = City; }
                //if (State != null) { ls.State = (States)State; }
                //if (ClosingDate != null) { ls.ClosingDate = (DateTime)ClosingDate; }
                //if (NeedByDate != null) { ls.NeedByDate = (DateTime)NeedByDate; }
                //if (Rush != null) { ls.Rush = (bool)Rush; }
                //if (AdditionalComments != null) { ls.AdditionalComments = AdditionalComments; }
                //if (OwnerName != null) { ls.OwnerName = OwnerName; }
                //if (BuyerName != null) { ls.BuyerName = BuyerName; }
                //if (AddressTwo != null) { ls.AddressTwo = AddressTwo; }
                //if (clientNumber != null) { ls.Clientfilenumber = clientNumber; }
                //if (additionalContactEmail != null) { ls.AdditionalContactEmail = additionalContactEmail; }
                //if (legalDescription != null) { ls.LegalDescription = legalDescription; }
                //if (Code != null) { ls.Code = (bool)Code; }
                //if (Permit != null) {ls.Permit = (bool)Permit; }
                //if(Tax != null) { ls.Tax = (bool)Tax; }
                //if(Utility != null) { ls.Utility = (bool)Utility; }
                //if(SpecialAssessments != null) { ls.SpecialAssessments = (bool)SpecialAssessments; }
                //if(Refinance != null) { ls.Refinance = (bool)Refinance; }
                //if(Commercial != null) { ls.Commercial = (bool)Commercial; }
                //if(Vacant != null) { ls.Vacant = (bool)Vacant; }
                _context.Products.Update(product);
                await _context.SaveChangesAsync();  
            }
            else if((int)product.ProductType == 3)
            {
                var es = product.Estoppel;
                if (Street != null) { es.Street = Street; }
                if (Zip != null) { es.Zip = Zip; }
                if (County != null) { es.County = County; }
                if (Parcel != null) { es.Parcel = Parcel; }
                if (City != null) { es.City = City; }
                if (State != null) { es.State = (States)State; }
                if (ClosingDate != null) { es.ClosingDate = (DateTime)ClosingDate; }
                if (NeedByDate != null) { es.NeedByDate = (DateTime)NeedByDate; }
                if (Rush != null) { es.Rush = (bool)Rush; }
                if (AdditionalComments != null) { es.AdditionalComments = AdditionalComments; }
                if (OwnerName != null) { es.OwnerName = OwnerName; }
                if (BuyerName != null) { es.BuyerName = BuyerName; }
                if (AddressTwo != null) { es.AddressTwo = AddressTwo; }
                if (clientNumber != null) { es.Clientfilenumber = clientNumber; }
                if (additionalContactEmail != null) { es.AdditionalContactEmail = additionalContactEmail; }
                if (legalDescription != null) { es.LegalDescription = legalDescription; }
                if (Refinance != null) { es.Refinance = (bool)Refinance; }
                if (Commercial != null) { es.Commercial = (bool)Commercial; }
                if (Vacant != null) { es.Vacant = (bool)Vacant; }
                _context.EstoppelSearches.Update(es);
                await _context.SaveChangesAsync();
            }
            else if ((int)product.ProductType == 4 || (int)product.ProductType == 5 || (int)product.ProductType == 6)
            {
                var tc = product.Tax;
                if (Street != null) { tc.Street = Street; }
                if (Zip != null) { tc.Zip = Zip; }
                if (County != null) { tc.County = County; }
                if (Parcel != null) { tc.Parcel = Parcel; }
                if (City != null) { tc.City = City; }
                if (State != null) { tc.State = (States)State; }
                if (ClosingDate != null) { tc.ClosingDate = (DateTime)ClosingDate; }
                if (NeedByDate != null) { tc.NeedByDate = (DateTime)NeedByDate; }
                if (Rush != null) { tc.Rush = (bool)Rush; }
                if (AdditionalComments != null) { tc.AdditionalComments = AdditionalComments; }
                if (OwnerName != null) { tc.OwnerName = OwnerName; }
                if (BuyerName != null) { tc.BuyerName = BuyerName; }
                if (AddressTwo != null) { tc.AddressTwo = AddressTwo; }
                if (clientNumber != null) { tc.Clientfilenumber = clientNumber; }
                if (additionalContactEmail != null) { tc.AdditionalContactEmail = additionalContactEmail; }
                if (legalDescription != null) { tc.LegalDescription = legalDescription; }
                if (Refinance != null) { tc.Refinance = (bool)Refinance; }
                if (Commercial != null) { tc.Commercial = (bool)Commercial; }
                if (Vacant != null) { tc.Vacant = (bool)Vacant; }
                _context.TaxSearches.Update(tc);
                await _context.SaveChangesAsync();
            }
            else if((int)product.ProductType == 7)
            {
                var rt = product.RT;
                if (Street != null) { rt.Street = Street; }
                if (Zip != null) { rt.Zip = Zip; }
                if (County != null) { rt.County = County; }
                if (Parcel != null) { rt.Parcel = Parcel; }
                if (City != null) { rt.City = City; }
                if (State != null) { rt.State = (States)State; }
                if (ClosingDate != null) { rt.ClosingDate = (DateTime)ClosingDate; }
                if (NeedByDate != null) { rt.NeedByDate = (DateTime)NeedByDate; }
                if (Rush != null) { rt.Rush = (bool)Rush; }
                if (AdditionalComments != null) { rt.AdditionalComments = AdditionalComments; }
                if (OwnerName != null) { rt.OwnerName = OwnerName; }
                if (BuyerName != null) { rt.BuyerName = BuyerName; }
                if (AddressTwo != null) { rt.AddressTwo = AddressTwo; }
                if (clientNumber != null) { rt.Clientfilenumber = clientNumber; }
                if (additionalContactEmail != null) { rt.AdditionalContactEmail = additionalContactEmail; }
                if (legalDescription != null) { rt.LegalDescription = legalDescription; }
                if (Refinance != null){ rt.Refinance = (bool)Refinance; }
                if (Commercial != null) { rt.Commercial = (bool)Commercial; }
                if(OwnerEmail != null) { rt.OwnerEmail = OwnerEmail; }
                if (BuyerEmail != null) { rt.BuyerEmail = BuyerEmail; }
                if (Vacant != null) { rt.Vacant = (bool)Vacant; }
                _context.RTSearches.Update(rt);
                await _context.SaveChangesAsync();
            }
            //else if(order.productType == 8)
            //{
            //    var cs = _context.CSSearches.Where(c => c.filenumber == filenumber).FirstOrDefault();
            //    if (Street != null) { cs.Street = Street; }
            //    if (Zip != null) { cs.Zip = Zip; }
            //    if (County != null) { cs.County = County; }
            //    if (Parcel != null) { cs.Parcel = Parcel; }
            //    if (City != null) { cs.City = City; }
            //    if (State != null) { cs.State = State.ToString(); }
            //    if (ClosingDate != null) { cs.ClosingDate = (DateTime)ClosingDate; }
            //    if (NeedByDate != null) { cs.NeedByDate = (DateTime)NeedByDate; }
            //    if (Rush != null) { cs.Rush = (bool)Rush; }
            //    if (AdditionalComments != null) { cs.AdditionalComments = AdditionalComments; }
            //    if (OwnerName != null) { cs.OwnerName = OwnerName; }
            //    if (BuyerName != null) { cs.BuyerName = BuyerName; }
            //    if (AddressTwo != null) { cs.AddressTwo = AddressTwo; }
            //    if (clientNumber != null) { cs.Clientfilenumber = clientNumber; }
            //    if (additionalContactEmail != null) { cs.AdditionalContactEmail = additionalContactEmail; }
            //    if (legalDescription != null) { cs.LegalDescription = legalDescription; }
            //    if (Refinance != null) { cs.Refinance = (bool)Refinance; }
            //    if (Commercial != null) { cs.Commercial = (bool)Commercial; }
            //    if (OwnerEmail != null) { cs.OwnerEmail = OwnerEmail; }
            //    if (BuyerEmail != null) { cs.BuyerEmail = BuyerEmail; }
            //    if (Vacant != null) { cs.Vacant = (bool)Vacant; }
            //    _context.CSSearches.Update(cs);
            //    await _context.SaveChangesAsync();
            //}
        }

        // Cancel Order
        [HttpPost("CancelOrder/{filenumber}")]
        public async Task<Product> Cancelorder(int filenumber)
        {
            var product = _context.Products.Where(o => o.filenumber == filenumber).FirstOrDefault();
            product.OrderStatus = 0;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // Un-Cancel Order
        [HttpPost("UnCancelOrder/{filenumber}")]
        public async Task<Product> UnCancelorder(int filenumber)
        {
            var product = _context.Products.Where(o => o.filenumber == filenumber).FirstOrDefault();
            product.OrderStatus = (Status)1;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // Delete Order
        [HttpDelete("delete/{filenumber}")]
        public async void Delete(int filenumber)
        {
            var product = _context.Products.Where(o => o.filenumber == filenumber).FirstOrDefault();
            var order = product.Order;
            order.Products.Remove(product);

            //if (summary.productType == 1 || summary.productType == 2)
            //{
            //    var ls = _context.LienSearches.Where(f => f.filenumber == filenumber).FirstOrDefault();
            //    _context.Orders.Remove(order);
            //}

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

    }
}
