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
    public class ReleaseTracking : OrderTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rtnumber { get; set; }
        
        [StringLength(100, ErrorMessage = "The value of this field is limited to 100 characters")]
        public string? OwnerEmail { get; set; }
        [ForeignKey("Product")]
        public int productId { get; set; }
        public Product Product { get; set; }

        public ReleaseTracking(string street, string zip, string county, string city, string state, string parcel, bool refinance, bool vacant, bool commercial, DateTime closingDate, DateTime needByDate, bool rush, string? additionalComments, string ownerName, string? buyerName, string? addressTwo, string? legalDescription, string? additionalContactEmail, string? clientfilenumber, Researcher? assignedResearcher, string? OwnerEmail)
            : base(street, zip, county, city, state, parcel, refinance, vacant, commercial, closingDate, needByDate, rush, additionalComments, ownerName, buyerName, addressTwo, legalDescription, additionalContactEmail, clientfilenumber, assignedResearcher)
        { }
    }
}
