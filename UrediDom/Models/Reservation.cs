using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class Reservation
    {
        /// <summary>
        /// Gets or Sets ReservationID
        /// </summary>

        [DataMember(Name = "reservationID")]
        public long? ReservationID { get; set; }

        /// <summary>
        /// Gets or Sets StartDate
        /// </summary>

        [DataMember(Name = "startDate")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or Sets EndDate
        /// </summary>

        [DataMember(Name = "endDate")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or Sets RepairmanID
        /// </summary>

        [DataMember(Name = "repairmanID")]
        public long? RepairmanID { get; set; }
    }
}
