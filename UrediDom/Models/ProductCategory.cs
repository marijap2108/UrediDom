using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class ProductCategory
    {
        /// <summary>
        /// Gets or Sets CategoryID
        /// </summary>

        [DataMember(Name = "categoryID")]
        public long? CategoryID { get; set; }

        /// <summary>
        /// Gets or Sets Category
        /// </summary>

        [DataMember(Name = "category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or Sets ValueCat
        /// </summary>

        [DataMember(Name = "valueCat")]
        public string ValueCat { get; set; }
    }
}
