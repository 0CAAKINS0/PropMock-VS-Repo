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
    public class Product
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int filenumber { get; set; }
        [Required]
        public OrderType ProductType { get; set; }
        [Required]
        [DefaultValue((Status)1)]
        public Status OrderStatus { get; set; }
        [ForeignKey("Order")]
        public int orderNumber { get; set; }
        public Order Order { get; set; }
        public LienSearch? Lien { get; set; }
        public Estoppel? Estoppel { get; set; }
        public Tax? Tax { get; set; }
        public ReleaseTracking? RT { get; set; }
        public CurativeServices? CS { get; set; }

        public Product(OrderType productType, Status OrderStatus)
        {
            this.ProductType = productType;
            this.OrderStatus = OrderStatus;
        }
        public string DisplayProductDetails()
        {
            if ((int)this.ProductType == 1 || (int)this.ProductType == 2) { return "File #: " + this.filenumber + "    Product Type: " + this.ProductType.ToString().Replace("_", " ") + "    Property Address: " + this.Lien.Street + " " + this.Lien.City + " " + this.Lien.State + ", " + this.Lien.Zip + "    Order Status:   " + this.OrderStatus; }
            else if((int)this.ProductType == 3) { return "File #: " + this.filenumber + "    Product Type: " + this.ProductType.ToString().Replace("_", " ") + "    Property Address: " + this.Estoppel.Street + " " + this.Estoppel.City + " " + this.Estoppel.State + ", " + this.Estoppel.Zip + "    Order Status:   " + this.OrderStatus; }
            else if ((int)this.ProductType == 4 || (int)this.ProductType == 5 || (int)this.ProductType == 6) { return "File #: " + this.filenumber + "    Product Type: " + this.ProductType.ToString().Replace("_", " ") + "    Property Address: " + this.Tax.Street + " " + this.Tax.City + " " + this.Tax.State + ", " + this.Tax.Zip + "    Order Status:   " + this.OrderStatus; }
            else if ((int)this.ProductType == 7) { return "File #: " + this.filenumber + "    Product Type: " + this.ProductType.ToString().Replace("_", " ") + "    Property Address: " + this.RT.Street + " " + this.RT.City + " " + this.RT.State + ", " + this.RT.Zip + "    Order Status:   " + this.OrderStatus; }
            else if ((int)this.ProductType == 8) { return "File #: " + this.filenumber + "    Product Type: " + this.ProductType.ToString().Replace("_", " ") + "    Property Address: " + this.CS.Street + " " + this.CS.City + " " + this.CS.State + ", " + this.CS.Zip + "    Order Status:   " + this.OrderStatus; }
            else { return "Order not found!"; }
        }

    }
}
