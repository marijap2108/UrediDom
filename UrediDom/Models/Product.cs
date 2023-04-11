using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class Product
    {
        /// <summary>
        /// Gets or Sets ProductID
        /// </summary>

        [DataMember(Name = "productID")]
        public long? ProductID { get; set; }

        /// <summary>
        /// Gets or Sets ProductName
        /// </summary>

        [DataMember(Name = "productName")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>

        [DataMember(Name = "price")]
        public float? Price { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>

        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>

        [DataMember(Name = "quantity")]
        public long? Quantity { get; set; }

        /// <summary>
        /// Gets or Sets TypeID
        /// </summary>

        [DataMember(Name = "typeID")]
        public long? TypeID { get; set; }

        /// <summary>
        /// Gets or Sets GroupID
        /// </summary>

        [DataMember(Name = "groupID")]
        public long? GroupID { get; set; }
    }
}
