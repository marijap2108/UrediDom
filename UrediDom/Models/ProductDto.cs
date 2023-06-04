using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class ProductDto
    {
        /// <summary>
        /// Gets or Sets ProductID
        /// </summary>

        [Key]
        [DataMember(Name = "productID")]
        public long productID { get; set; }

        /// <summary>
        /// Gets or Sets ProductName
        /// </summary>

        [DataMember(Name = "productName")]
        public string productName { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>

        [DataMember(Name = "price")]
        public float? price { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>

        [DataMember(Name = "description")]
        public string description { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>

        [DataMember(Name = "quantity")]
        public long? quantity { get; set; }

        /// <summary>
        /// Gets or Sets TypeID
        /// </summary>

        [DataMember(Name = "typeID")]
        public long? typeID { get; set; }

        /// <summary>
        /// Gets or Sets GroupID
        /// </summary>

        [DataMember(Name = "groupID")]
        public long? groupID { get; set; }

        /// <summary>
        /// Gets or Sets ImgSrc
        /// </summary>

        [DataMember(Name = "imgSrc")]
        public string imgSrc { get; set; }
    }
}
