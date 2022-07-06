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
           //var order = _context.Orders.Where(o => o.orderId == orderDetails.orderId).FirstOrDefault();

            if (orderDetails.productType == 1 || orderDetails.productType == 2)
            {
                var ls = order.LienSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
                return "File #: " + ls.filenumber + "    Product Type: Lien Search    Property Address: " + ls.Street + " " + ls.City + " " + ls.State + ", " + ls.Zip;
            }
            else if(orderDetails.productType == 3)
            {
                var es = _context.EstoppelSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
                return "File #: " + es.filenumber + "    Product Type: Estoppel    Property Address: " + es.Street + " " + es.City + " " + es.State + ", " + es.Zip;
            }
            else if (orderDetails.productType == 4)
            {
                var tc = _context.TaxSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
                return "File #: " + tc.filenumber + "    Product Type: Tax Cert    Property Address: " + tc.Street + " " + tc.City + " " + tc.State + ", " + tc.Zip;
            }
            else if (orderDetails.productType == 5)
            {
                var tc = _context.TaxSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
                return "File #: " + tc.filenumber + "    Product Type: Tax Cert Basic    Property Address: " + tc.Street + " " + tc.City + " " + tc.State + ", " + tc.Zip;
            }
            else if (orderDetails.productType == 6)
            {
                var tc = _context.TaxSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
                return "File #: " + tc.filenumber + "    Product Type: Tax Cert HOA   Property Address: " + tc.Street + " " + tc.City + " " + tc.State + ", " + tc.Zip;
            }
            else if (orderDetails.productType == 7)
            {
                var rt = _context.RTSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
                return "File #: " + rt.filenumber + "    Product Type: Release Tracking    Property Address: " + rt.Street + " " + rt.City + " " + rt.State + ", " + rt.Zip;
            }
            else if (orderDetails.productType == 8)
            {
                var cs = _context.CSSearches.Where(o => o.filenumber == filenumber).FirstOrDefault();
                return "File #: " + cs.filenumber + "    Product Type: Curative Services    Property Address: " + cs.Street + " " + cs.City + " " + cs.State + ", " + cs.Zip;
            }
            return "Order not found";
        }


        //Create Lien Search Order
        [HttpPost("NewLienSearchOrder")]
        public async Task<string> OrderLienSearch(string Street, string Zip, string County, string Parcel, string City, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string BuyerName, string? AddressTwo, string? clientNumber, string? additionalContactEmail, string? legalDescription, int userId, bool Code = true, bool Permit = true, bool Tax = true, bool Utility = true, bool SpecialAssessments = true, bool Refinance = false, bool Vacant = false, bool Commercial = false)
        {
            int product = 1;
            if (!Permit)
            {
                product = 2;
            }

            var summary = new OrderSummary()
            {
                productType = product,
                OrderStatus = 1
            };

            var order = new Order()
            {
                userId = userId
            };

            var ls = new LienSearch()
            {
                Order = order,
                Street = Street,
                Zip = Zip,
                County = County,
                Parcel = Parcel,
                City = City,
                State = State.ToString(),
                ClosingDate = ClosingDate,
                NeedByDate = NeedByDate,
                Rush = Rush,
                AdditionalComments = AdditionalComments,
                OwnerName = OwnerName,
                BuyerName = BuyerName,
                AddressTwo = AddressTwo,
                Code = Code,
                Permit = Permit,
                Tax = Tax,
                Utility = Utility,
                SpecialAssessments = SpecialAssessments,
                Clientfilenumber = clientNumber,
                AdditionalContactEmail = additionalContactEmail,
                LegalDescription = legalDescription,
                Refinance = Refinance,
                Vacant = Vacant,
                Commercial = Commercial
            };

            order.LienSearches.Add(ls);
            order.Summaries.Add(summary);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return "Your lien search order for " + Street + " has been placed! File # " + summary.filenumber;
        }

        // Create Estoppel Order
        [HttpPost("NewEstoppelOrder")]
        public async Task<ActionResult<string>> OrderEstoppelSearch(string Street, string Zip, string County, string Parcel, string City, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string BuyerName, string? AddressTwo, string? additionalContactEmail, string? legalDescription,int userId, bool Sale = true)
        {
            string transactionType;
            if (Sale == false)
            {
                transactionType = "Refinance";
            }
            else
            {
                transactionType = "Sale";
            }
            var summary = new OrderSummary()
            {
                productType = 3,
                OrderStatus = 1
            };

            var order = new Order()
            {
                userId = userId,
            };

            var es = new Estoppel()
            {
                Street = Street,
                Zip = Zip,
                County = County,
                Parcel = Parcel,
                City = City,
                State = State.ToString(),
                ClosingDate = ClosingDate,
                NeedByDate = NeedByDate,
                Rush = Rush,
                AdditionalComments = AdditionalComments,
                OwnerName = OwnerName,
                BuyerName = BuyerName,
                AddressTwo = AddressTwo,
                Sale = transactionType,
                AdditionalContactEmail = additionalContactEmail,
                LegalDescription = legalDescription
            };

            order.EstoppelSearches.Add(es);
            order.Summaries.Add(summary);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return "Your estoppel order for " + Street + " has been placed! File # " + summary.filenumber;
        }

        // Create Tax Cert Order
        [HttpPost("NewTaxOrder")]
        public async Task<ActionResult<string>> OrderTaxSearch(TaxOrderType OrderType , string Street, string Zip, string County, string Parcel, string City, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string BuyerName, string? AddressTwo, string? additionalContactEmail, string? legalDescription, int userId, bool Refinance = false, bool Vacant = false, bool Commercial = false)
        {

            var summary = new OrderSummary()
            {
                productType = (int)OrderType,
                OrderStatus = 1
            };

            var order = new Order()
            {
                userId = userId,
            };

            var tc = new Tax()
            {
                Street = Street,
                Zip = Zip,
                County = County,
                Parcel = Parcel,
                City = City,
                State = State.ToString(),
                ClosingDate = ClosingDate,
                NeedByDate = NeedByDate,
                Rush = Rush,
                AdditionalComments = AdditionalComments,
                OwnerName = OwnerName,
                BuyerName = BuyerName,
                AddressTwo = AddressTwo,
                Refinance = Refinance,
                Vacant = Vacant,
                Commercial = Commercial,
                AdditionalContactEmail = additionalContactEmail,
                LegalDescription = legalDescription
            };

            order.TaxSearches.Add(tc);
            order.Summaries.Add(summary);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return "Your tax cert order for " + Street + " has been placed! File # " + summary.filenumber;
        }

        // Create Release Tracking Order
        [HttpPost("NewReleaseTrackingOrder")]
        public async Task<ActionResult<string>> OrderReleaseTracking(string Street, string Zip, string County, string Parcel, string City, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string? OwnerEmail, string BuyerName, string? BuyerEmail, string? AddressTwo, string? additionalContactEmail, string? legalDescription, int userId, bool Refinance = false, bool Vacant = false, bool Commercial = false)
        {
            var summary = new OrderSummary()
            {
                productType = 7,
                OrderStatus = 1
            };

            var order = new Order()
            {
                userId = userId,
            };

            var rt = new ReleaseTracking()
            {
                Street = Street,
                Zip = Zip,
                County = County,
                Parcel = Parcel,
                City = City,
                State = State.ToString(),
                ClosingDate = ClosingDate,
                NeedByDate = NeedByDate,
                Rush = Rush,
                AdditionalComments = AdditionalComments,
                OwnerName = OwnerName,
                OwnerEmail = OwnerEmail,
                BuyerName = BuyerName,
                BuyerEmail = BuyerEmail,
                AddressTwo = AddressTwo,
                Refinance = Refinance,
                Vacant = Vacant,
                Commercial = Commercial,
                AdditionalContactEmail = additionalContactEmail,
                LegalDescription = legalDescription
            };

            order.RTSearches.Add(rt);
            order.Summaries.Add(summary);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return "Your release tracking order for " + Street + " has been placed! File # " + summary.filenumber;
        }

        // Creating Curative Services Order
        [HttpPost("NewCurativeServicesOrder")]
        public async Task<ActionResult<string>> OrderCurativeServices(string Street, string Zip, string County, string Parcel, string City, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string? AdditionalComments, string OwnerName, string? OwnerEmail, string BuyerName, string? BuyerEmail, string? AddressTwo, string? additionalContactEmail, string? legalDescription, int userId, bool Refinance = false, bool Vacant = false, bool Commercial = false)
        {
            var summary = new OrderSummary()
            {
                productType = 8,
                OrderStatus = 1
            };

            var order = new Order()
            {
                userId = userId
            };

            var cs = new CurativeServices()
            {
                Street = Street,
                Zip = Zip,
                County = County,
                Parcel = Parcel,
                City = City,
                State = State.ToString(),
                ClosingDate = ClosingDate,
                NeedByDate = NeedByDate,
                Rush = Rush,
                AdditionalComments = AdditionalComments,
                OwnerName = OwnerName,
                OwnerEmail = OwnerEmail,
                BuyerName = BuyerName,
                BuyerEmail = BuyerEmail,
                AddressTwo = AddressTwo,
                Refinance = Refinance,
                Vacant = Vacant,
                Commercial = Commercial,
                AdditionalContactEmail = additionalContactEmail,
                LegalDescription = legalDescription
            };

            order.CSSearches.Add(cs);
            order.Summaries.Add(summary);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return "Your curative services order for " + Street + " has been placed! File # " + summary.filenumber;
        }

        // Update Order
        [HttpPost("Edit/{filenumber}")]
        public async Task UpdateOrder(int filenumber, string? Street, string? Zip, string? County, string? Parcel, string? City, States? State, DateTime? ClosingDate, DateTime? NeedByDate, bool? Rush, string? AdditionalComments, string? OwnerName, string? BuyerName, string? AddressTwo, string? clientNumber, string? additionalContactEmail, string? legalDescription, bool? Code, bool? Permit, bool? Tax, bool? Utility, bool? SpecialAssessments, bool? Refinance, bool? Commercial, string? OwnerEmail, string? BuyerEmail, bool? Vacant)
        {
            var order = _context.Summaries.Where(o => o.filenumber == filenumber).FirstOrDefault();
            if (order.productType == 1 || order.productType == 2)
            {
                var ls = _context.LienSearches.Where(l => l.filenumber == filenumber).FirstOrDefault();
                if (Street != null) { ls.Street = Street; }
                if (Zip != null) { ls.Zip = Zip; }
                if (County != null) { ls.County = County; }
                if (Parcel != null) { ls.Parcel = Parcel; }
                if (City != null) { ls.City = City; }
                if (State != null) { ls.State = State.ToString(); }
                if (ClosingDate != null) { ls.ClosingDate = (DateTime)ClosingDate; }
                if (NeedByDate != null) { ls.NeedByDate = (DateTime)NeedByDate; }
                if (Rush != null) { ls.Rush = (bool)Rush; }
                if (AdditionalComments != null) { ls.AdditionalComments = AdditionalComments; }
                if (OwnerName != null) { ls.OwnerName = OwnerName; }
                if (BuyerName != null) { ls.BuyerName = BuyerName; }
                if (AddressTwo != null) { ls.AddressTwo = AddressTwo; }
                if (clientNumber != null) { ls.Clientfilenumber = clientNumber; }
                if (additionalContactEmail != null) { ls.AdditionalContactEmail = additionalContactEmail; }
                if (legalDescription != null) { ls.LegalDescription = legalDescription; }
                if (Code != null) { ls.Code = (bool)Code; }
                if (Permit != null) {ls.Permit = (bool)Permit; }
                if(Tax != null) { ls.Tax = (bool)Tax; }
                if(Utility != null) { ls.Utility = (bool)Utility; }
                if(SpecialAssessments != null) { ls.SpecialAssessments = (bool)SpecialAssessments; }
                if(Refinance != null) { ls.Refinance = (bool)Refinance; }
                if(Commercial != null) { ls.Commercial = (bool)Commercial; }
                if(Vacant != null) { ls.Vacant = (bool)Vacant; }
                _context.LienSearches.Update(ls);
                await _context.SaveChangesAsync();  
            }
            else if(order.productType == 3)
            {
                var es = _context.EstoppelSearches.Where(e => e.filenumber == filenumber).FirstOrDefault();
                if (Street != null) { es.Street = Street; }
                if (Zip != null) { es.Zip = Zip; }
                if (County != null) { es.County = County; }
                if (Parcel != null) { es.Parcel = Parcel; }
                if (City != null) { es.City = City; }
                if (State != null) { es.State = State.ToString(); }
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
                if (Refinance != null) {
                    if ((bool)Refinance)
                    {
                        es.Sale = "Refinance";
                    }
                    else
                    {
                        es.Sale = "Sale";
                    }
                }
                if (Commercial != null) { es.Commercial = (bool)Commercial; }
                if (Vacant != null) { es.Vacant = (bool)Vacant; }
                _context.EstoppelSearches.Update(es);
                await _context.SaveChangesAsync();
            }
            else if (order.productType == 4 || order.productType == 5 || order.productType == 6)
            {
                var tc = _context.TaxSearches.Where(t => t.filenumber == filenumber).FirstOrDefault();
                if (Street != null) { tc.Street = Street; }
                if (Zip != null) { tc.Zip = Zip; }
                if (County != null) { tc.County = County; }
                if (Parcel != null) { tc.Parcel = Parcel; }
                if (City != null) { tc.City = City; }
                if (State != null) { tc.State = State.ToString(); }
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
            else if(order.productType == 7)
            {
                var rt = _context.RTSearches.Where(r => r.filenumber == filenumber).FirstOrDefault();
                if (Street != null) { rt.Street = Street; }
                if (Zip != null) { rt.Zip = Zip; }
                if (County != null) { rt.County = County; }
                if (Parcel != null) { rt.Parcel = Parcel; }
                if (City != null) { rt.City = City; }
                if (State != null) { rt.State = State.ToString(); }
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
            else if(order.productType == 8)
            {
                var cs = _context.CSSearches.Where(c => c.filenumber == filenumber).FirstOrDefault();
                if (Street != null) { cs.Street = Street; }
                if (Zip != null) { cs.Zip = Zip; }
                if (County != null) { cs.County = County; }
                if (Parcel != null) { cs.Parcel = Parcel; }
                if (City != null) { cs.City = City; }
                if (State != null) { cs.State = State.ToString(); }
                if (ClosingDate != null) { cs.ClosingDate = (DateTime)ClosingDate; }
                if (NeedByDate != null) { cs.NeedByDate = (DateTime)NeedByDate; }
                if (Rush != null) { cs.Rush = (bool)Rush; }
                if (AdditionalComments != null) { cs.AdditionalComments = AdditionalComments; }
                if (OwnerName != null) { cs.OwnerName = OwnerName; }
                if (BuyerName != null) { cs.BuyerName = BuyerName; }
                if (AddressTwo != null) { cs.AddressTwo = AddressTwo; }
                if (clientNumber != null) { cs.Clientfilenumber = clientNumber; }
                if (additionalContactEmail != null) { cs.AdditionalContactEmail = additionalContactEmail; }
                if (legalDescription != null) { cs.LegalDescription = legalDescription; }
                if (Refinance != null) { cs.Refinance = (bool)Refinance; }
                if (Commercial != null) { cs.Commercial = (bool)Commercial; }
                if (OwnerEmail != null) { cs.OwnerEmail = OwnerEmail; }
                if (BuyerEmail != null) { cs.BuyerEmail = BuyerEmail; }
                if (Vacant != null) { cs.Vacant = (bool)Vacant; }
                _context.CSSearches.Update(cs);
                await _context.SaveChangesAsync();
            }
        }

        // Cancel Order
        [HttpPost("CancelOrder/{filenumber}")]
        public async Task<OrderSummary> Cancelorder(int filenumber)
        {
            var order = _context.Summaries.Where(o => o.filenumber == filenumber).FirstOrDefault();
            order.OrderStatus = 0;
            _context.Summaries.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        // Un-Cancel Order
        [HttpPost("UnCancelOrder/{filenumber}")]
        public async Task<OrderSummary> UnCancelorder(int filenumber)
        {
            var order = _context.Summaries.Where(o => o.filenumber == filenumber).FirstOrDefault();
            order.OrderStatus = 1;
            _context.Summaries.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        // Delete Order
        [HttpDelete("delete/{filenumber}")]
        public async void Delete(int filenumber)
        {
            var summary = _context.Summaries.Where(o => o.filenumber == filenumber).FirstOrDefault();
            var order = _context.Orders.Include(o => o.LienSearches.Select(f => f.filenumber == filenumber)).FirstOrDefault();

            if (summary.productType == 1 || summary.productType == 2)
            {
                var ls = _context.LienSearches.Where(f => f.filenumber == filenumber).FirstOrDefault();
                _context.Orders.Remove(order);
            }

            _context.Orders.Remove(ls);
            await _context.SaveChangesAsync();
        }

    }
}
