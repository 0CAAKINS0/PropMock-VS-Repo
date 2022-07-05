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
    public class Order
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ordernumber { get; set; }
        [StringLength(50, ErrorMessage = "The value of this field is limited to 50 characters")]
        public string? Clientfilenumber { get; set; }
        [Required]
        public int userId { get; set; }
        public Order(int userId)
        {
            this.userId = userId;
        }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
