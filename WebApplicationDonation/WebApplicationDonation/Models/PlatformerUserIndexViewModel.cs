using System.Collections.Generic;

namespace WebApplicationDonation.Models
{
    public class PlatformerUserIndexViewModel
    {
        public string Search { get; set; }
        public bool OrderAscendant { get; set; }
        public IEnumerable<PlatformerUserViewModel> Users { get; set; }
    }
}
