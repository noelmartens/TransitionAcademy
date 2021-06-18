using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSONParser
{
    class Contact
    {
        public int Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
        public string Skill { get; set; }
        public string height { get; set; }

    }
}
