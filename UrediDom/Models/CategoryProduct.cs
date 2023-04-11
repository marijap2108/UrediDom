using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class CategoryProduct
    {
        /// <summary>
        /// Gets or Sets CategoryID
        /// </summary>

        [DataMember(Name = "categoryID")]
        public long? CategoryID { get; set; }

        /// <summary>
        /// Gets or Sets ProductID
        /// </summary>

        [DataMember(Name = "productID")]
        public long? ProductID { get; set; }
    }
}
