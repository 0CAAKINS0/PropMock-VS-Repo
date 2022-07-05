using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropMockModels
{
    public class Client
    {
        [Required]
        [StringLength(50, ErrorMessage = "The value of this field is limited to 50 characters")]
        public string companyName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50, ErrorMessage = "The value of this field is limited to 50 characters")]
        public string email { get; set; }
        [StringLength(500, ErrorMessage = "The value of this field is limited to 500 characters")]
        private string clientNotes { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The value of this field is limited to 20 characters")]
        public string phone { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The value of this field is limited to 50 characters")]
        public string address { get; set; }
        [Required]
        [DefaultValue(85)]
        [Range(0, 200)]
        public int lsPricing { get; set; }
        [Required]
        [DefaultValue(85)]
        [Range(0, 200)]
        public int esPricing { get; set; }
        [Required]
        [Key, ForeignKey("User")]
        public int clientId { get; private set; }
        [Required]
        [DefaultValue(100)]
        [Range(0,200)]
        public int rtPricing { get; set; }
        [Required]
        [DefaultValue(60)]
        [Range(0, 200)]
        public int tcPricing { get; set; }
        [Required]
        [DefaultValue(70)]
        [Range(0, 200)]
        public int lnpPricing { get; set; }
        [Required]
        [DefaultValue(100)]
        [Range(0, 200)]
        public int csPricing { get; set; }

        public  ICollection<User> Users { get; set; } = new List<User>();
        public Client()
        {
            this.Users = new List<User>();
        }
    }
}
