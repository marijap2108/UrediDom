using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class CategoryProductDto
    {
        /// <summary>
        /// Gets or Sets CategoryID
        /// </summary>

        [DataMember(Name = "categoryID")]
        public long categoryID { get; set; }

        /// <summary>
        /// Gets or Sets ProductID
        /// </summary>

        [DataMember(Name = "productID")]
        public long? productID { get; set; }
    }
}
