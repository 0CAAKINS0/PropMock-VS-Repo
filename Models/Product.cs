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
    public class Product
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int filenumber { get; set; }
        [Required]
        public OrderType ProductType { get; set; }
        [ForeignKey("Order")]
        public int orderNumber { get; set; }
        public Order Order { get; set; }

        public Product(OrderType productType)
        {
            this.ProductType = productType;
        }
       }
}
