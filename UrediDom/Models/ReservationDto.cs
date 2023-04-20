using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class ReservationDto
    {
        /// <summary>
        /// Gets or Sets ReservationID
        /// </summary>

        [Key]
        [DataMember(Name = "reservationID")]
        public long reservationID { get; set; }

        /// <summary>
        /// Gets or Sets StartDate
        /// </summary>

        [DataMember(Name = "startDate")]
        public DateTime? startDate { get; set; }

        /// <summary>
        /// Gets or Sets EndDate
        /// </summary>

        [DataMember(Name = "endDate")]
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Gets or Sets RepairmanID
        /// </summary>

        [DataMember(Name = "repairmanID")]
        public long? repairmanID { get; set; }
    }
}
