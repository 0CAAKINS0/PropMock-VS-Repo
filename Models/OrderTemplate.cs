using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PropMockModels.Enums;

namespace PropMockModels
{
    public class OrderTemplate
    {
        public string Street { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Parcel { get; set; }
        public bool Refinance { get; set; }
        public bool Vacant { get; set; }
        public bool Commercial { get; set; }
        public DateTime ClosingDate { get; set; }
        public DateTime NeedByDate { get; set; }
        public bool Rush { get; set; }
        public string? AdditionalComments { get; set; }
        public string OwnerName { get; set; }
        public string? BuyerName { get; set; }
        public string? AddressTwo { get; set; }
        public string? LegalDescription { get; set; }
        public string? AdditionalContactEmail { get; set; }
        public string? Clientfilenumber { get; set; }
        public Researcher? AssignedResearcher { get; set; }
        public string? OwnerEmail { get; set; }
        public OrderTemplate(string street, string zip, string county, string city, string state, string parcel, bool refinance, bool vacant, bool commercial, DateTime closingDate, DateTime needByDate, bool rush, string? additionalComments, string ownerName, string? buyerName, string? addressTwo, string? legalDescription, string? additionalContactEmail, string? clientfilenumber, Researcher? assignedResearcher)
        {
            this.Street = street;
            this.Zip = zip;
            this.County = county;
            this.City = city;
            this.State = state;
            this.Parcel = parcel;
            this.Refinance = refinance;
            this.Vacant = vacant;
            this.Commercial = commercial;
            this.ClosingDate = closingDate;
            this.NeedByDate = needByDate;
            this.Rush = rush;
            this.AdditionalComments = additionalComments;
            this.OwnerName = ownerName;
            this.BuyerName = buyerName;
            this.AddressTwo = addressTwo;
            this.LegalDescription = legalDescription;
            this.AdditionalContactEmail = additionalContactEmail;
            this.Clientfilenumber = clientfilenumber;
            this.AssignedResearcher = assignedResearcher;

        }
    }
}
