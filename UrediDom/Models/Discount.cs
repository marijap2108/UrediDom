using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class Discount
    {
        /// <summary>
        /// Gets or Sets DiscountID
        /// </summary>

        [DataMember(Name = "discountID")]
        public long? DiscountID { get; set; }

        /// <summary>
        /// Gets or Sets _Discount
        /// </summary>

        [DataMember(Name = "discountProcent")]
        public long? DiscountProcent { get; set; }

        /// <summary>
        /// Gets or Sets DiscountName
        /// </summary>

        [DataMember(Name = "discountName")]
        public string DiscountName { get; set; }

        /// <summary>
        /// Gets or Sets DiscountDescription
        /// </summary>

        [DataMember(Name = "discountDescription")]
        public string DiscountDescription { get; set; }

        /// <summary>
        /// Gets or Sets StartDay
        /// </summary>

        [DataMember(Name = "startDay")]
        public long? StartDay { get; set; }

        /// <summary>
        /// Gets or Sets StartMonth
        /// </summary>

        [DataMember(Name = "startMonth")]
        public long? StartMonth { get; set; }

        /// <summary>
        /// Gets or Sets EndDay
        /// </summary>

        [DataMember(Name = "endDay")]
        public long? EndDay { get; set; }

        /// <summary>
        /// Gets or Sets EndMonth
        /// </summary>

        [DataMember(Name = "endMonth")]
        public long? EndMonth { get; set; }
    }
}
