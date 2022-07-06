using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PropMockModels.Enums;

namespace PropMockModels
{
    public class OrderTemplate
    {
        [Required]
        [StringLength(100, ErrorMessage = "The value of this field is limited to 100 characters")]
        public string Street { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The value of this field is limited to 20 characters")]
        public string Zip { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The value of this field is limited to 50 characters")]
        public string County { get; set; }
        [StringLength(100, ErrorMessage = "The value of this field is limited to 100 characters")]
        [Required]
        public string City { get; set; }
        [Required]
        public States State { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The value of this field is limited to 100 characters")]
        public string Parcel { get; set; }
        [Required]
        public bool Refinance { get; set; }
        [Required]
        public bool Vacant { get; set; }
        [Required]
        public bool Commercial { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime ClosingDate { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime NeedByDate { get; set; }
        [Required]
        public bool Rush { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The value of this field is limited to 500 characters")]
        public string? AdditionalComments { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The value of this field is limited to 100 characters")]
        public string OwnerName { get; set; }
        [StringLength(100, ErrorMessage = "The value of this field is limited to 100 characters")]
        public string? BuyerName { get; set; }
        [StringLength(100, ErrorMessage = "The value of this field is limited to 100 characters")]
        public string? AddressTwo { get; set; }
        [StringLength(250, ErrorMessage = "The value of this field is limited to 250 characters")]
        public string? LegalDescription { get; set; }
        [StringLength(100, ErrorMessage = "The value of this field is limited to 100 characters")]
        public string? AdditionalContactEmail { get; set; }
        [StringLength(100, ErrorMessage = "The value of this field is limited to 100 characters")]
        public string? Clientfilenumber { get; set; }
        public Researcher? AssignedResearcher { get; set; }
        [StringLength(100, ErrorMessage = "The value of this field is limited to 100 characters")]
        public string? OwnerEmail { get; set; }
        public OrderTemplate(string street, string zip, string county, string city, States state, string parcel, bool refinance, bool vacant, bool commercial, DateTime closingDate, DateTime needByDate, bool rush, string? additionalComments, string ownerName, string? buyerName, string? addressTwo, string? legalDescription, string? additionalContactEmail, string? clientfilenumber, Researcher? assignedResearcher)
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

        public virtual OrderTemplate EditOrder(string Street, string Zip, string County, string Parcel, string City, States State, DateTime ClosingDate, DateTime NeedByDate, bool Rush, string AdditionalComments, string OwnerName, string BuyerName, string AddressTwo, string clientNumber, string additionalContactEmail, string legalDescription, bool Refinance, bool Commercial, bool Vacant, Researcher researcher)
        {
            if (Street != null) { this.Street = Street; }
            if (Zip != null) { this.Zip = Zip; }
            if (County != null) { this.County = County; }
            if (Parcel != null) { this.Parcel = Parcel; }
            if (City != null) { this.City = City; }
            if (State != null) { this.State = (States)State; }
            if (ClosingDate != null) { this.ClosingDate = (DateTime)ClosingDate; }
            if (NeedByDate != null) { this.NeedByDate = (DateTime)NeedByDate; }
            if (Rush != null) { this.Rush = (bool)Rush; }
            if (AdditionalComments != null) { this.AdditionalComments = AdditionalComments; }
            if (OwnerName != null) { this.OwnerName = OwnerName; }
            if (BuyerName != null) { this.BuyerName = BuyerName; }
            if (AddressTwo != null) { this.AddressTwo = AddressTwo; }
            if (Clientfilenumber != null) { this.Clientfilenumber = Clientfilenumber; }
            if (AdditionalContactEmail != null) { this.AdditionalContactEmail = AdditionalContactEmail; }
            if (LegalDescription != null) { this.LegalDescription = LegalDescription; }
            if (Refinance != null) { this.Refinance = (bool)Refinance; }
            if (Commercial != null) { this.Commercial = (bool)Commercial; }
            if (Vacant != null) { this.Vacant = (bool)Vacant; }
            if(researcher != null) { this.AssignedResearcher = researcher; }

            return this;
        }
    }
}
