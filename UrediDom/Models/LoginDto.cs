using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class LoginDto
    {
        /// <summary>
        /// Gets or Sets Email
        /// </summary>

        [DataMember(Name = "email")]
        public string email { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>

        [DataMember(Name = "password")]
        public string password { get; set; }
    }
}
