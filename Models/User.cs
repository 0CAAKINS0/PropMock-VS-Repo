using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropMockModels
{
    public class User
    {
        [Required]
        [StringLength(50, ErrorMessage = "The value of this field is limited to 50 characters")]
        public string userFirst { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The value of this field is limited to 50 characters")]
        public string userLast { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The value of this field is limited to 50 characters")]
        public string companyName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The value of this field is limited to 20 characters")]
        public string userType { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50, ErrorMessage = "The value of this field is limited to 50 characters")]
        public string email { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The value of this field is limited to 20 characters")]
        public string phone { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The value of this field is limited to 50 characters")]
        public string address { get; set; }
        [StringLength(100, ErrorMessage = "The value of this field is limited to 100 characters")]
        public string? additionalContacts { get; set; }
        [Required]
        [Key]
        public int userId { get; private set; }
        [StringLength(500, ErrorMessage = "The value of this field is limited to 500 characters")]
        public string? userNotes { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        public int clientId { get; set; }
        public Client Client { get; set; }
    }
}