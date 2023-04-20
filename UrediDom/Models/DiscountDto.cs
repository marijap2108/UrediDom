using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class DiscountDto
    {
        /// <summary>
        /// Gets or Sets DiscountID
        /// </summary>

        [Key]
        [DataMember(Name = "discountID")]
        public long discountID { get; set; }

        /// <summary>
        /// Gets or Sets _Discount
        /// </summary>

        [DataMember(Name = "discountProcent")]
        public long? discountProcent { get; set; }

        /// <summary>
        /// Gets or Sets DiscountName
        /// </summary>

        [DataMember(Name = "discountName")]
        public string discountName { get; set; }

        /// <summary>
        /// Gets or Sets DiscountDescription
        /// </summary>

        [DataMember(Name = "discountDescription")]
        public string discountDescription { get; set; }

        /// <summary>
        /// Gets or Sets StartDay
        /// </summary>

        [DataMember(Name = "startDay")]
        public long? startDay { get; set; }

        /// <summary>
        /// Gets or Sets StartMonth
        /// </summary>

        [DataMember(Name = "startMonth")]
        public long? startMonth { get; set; }

        /// <summary>
        /// Gets or Sets EndDay
        /// </summary>

        [DataMember(Name = "endDay")]
        public long? endDay { get; set; }

        /// <summary>
        /// Gets or Sets EndMonth
        /// </summary>

        [DataMember(Name = "endMonth")]
        public long? endMonth { get; set; }
    }
}
