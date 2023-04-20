using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class ProductCategoryDto
    {
        /// <summary>
        /// Gets or Sets CategoryID
        /// </summary>

        [Key]
        [DataMember(Name = "categoryID")]
        public long categoryID { get; set; }

        /// <summary>
        /// Gets or Sets Category
        /// </summary>

        [DataMember(Name = "category")]
        public string category { get; set; }

        /// <summary>
        /// Gets or Sets ValueCat
        /// </summary>

        [DataMember(Name = "valueCat")]
        public string valueCat { get; set; }
    }
}
