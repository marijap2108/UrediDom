using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class ProductOrder
    {
        /// <summary>
        /// Gets or Sets ProductID
        /// </summary>

        [DataMember(Name = "productID")]
        public long? ProductID { get; set; }

        /// <summary>
        /// Gets or Sets OrderID
        /// </summary>

        [DataMember(Name = "orderID")]
        public long? OrderID { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>

        [DataMember(Name = "quantity")]
        public long? Quantity { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>

        [DataMember(Name = "price")]
        public long? Price { get; set; }
    }
}
