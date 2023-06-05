using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace UrediDom.Models
{
    public class ProductOrderDto
    {
        /// <summary>
        /// Gets or Sets productOrderID
        /// </summary>

        [Key]
        [DataMember(Name = "productOrderID")]
        public long productOrderID { get; set; }

        /// <summary>
        /// Gets or Sets ProductID
        /// </summary>

        [DataMember(Name = "productID")]
        public long productID { get; set; }

        /// <summary>
        /// Gets or Sets OrderID
        /// </summary>

        [DataMember(Name = "orderID")]
        public long? orderID { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>

        [DataMember(Name = "quantity")]
        public long? quantity { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>

        [DataMember(Name = "price")]
        public long? price { get; set; }
    }
}
