using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PropMockModels.Enums;

namespace PropMockModels
{
    public class LienSearch : OrderTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int liensearchnumber { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Code { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Permit { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Tax { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Utility { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool SpecialAssessments { get; set; }
        [ForeignKey("Product")]
        public int productId { get; set; }
        public Product Product { get; set; }

        public LienSearch(string street, string zip, string county, string city, States state, string parcel, bool refinance, bool vacant, bool commercial, DateTime closingDate, DateTime needByDate, bool rush, string? additionalComments, string ownerName, string? buyerName, string? addressTwo, string? legalDescription, string? additionalContactEmail, string? clientfilenumber, Researcher? assignedResearcher, bool Code, bool Permit, bool Tax, bool Utility, bool SpecialAssessments) 
            :base(street, zip, county, city, state, parcel, refinance, vacant, commercial, closingDate, needByDate, rush, additionalComments, ownerName, buyerName, addressTwo, legalDescription, additionalContactEmail, clientfilenumber, assignedResearcher) 
        { }

        public virtual LienSearch EditOrder(string Street, string Zip, string County, string Parcel, string City, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string AdditionalComments, string OwnerName, string BuyerName, string AddressTwo, string clientNumber, string additionalContactEmail, string legalDescription, bool Refinance, bool Commercial, bool Vacant, Researcher researcher, bool? Code, bool? Permit, bool? Tax, bool? Utility, bool? SpecialAssessments)
        {
            var update = (LienSearch)base.EditOrder(Street, Zip, County, Parcel, City, State, ClosingDate, NeedByDate, Rush, AdditionalComments, OwnerName, BuyerName, AddressTwo, clientNumber, additionalContactEmail, legalDescription, Refinance, Commercial, Vacant, researcher);
            if (Code != null) { update.Code = (bool)Code; }
            if (Permit != null)
            {
                update.Permit = (bool)Permit;
                if (update.Permit == false) { update.Product.ProductType = (OrderType)2; } else { update.Product.ProductType = (OrderType)1; }
            }
            if (Tax != null) { update.Tax = (bool)Tax; }
            if (Utility != null) { update.Utility = (bool)Utility; }
            if (SpecialAssessments != null) { update.SpecialAssessments = (bool)SpecialAssessments; }
            return update;
        }
    }
}
