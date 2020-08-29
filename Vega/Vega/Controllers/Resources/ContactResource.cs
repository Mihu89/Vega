using System.ComponentModel.DataAnnotations;

namespace Vega.Controllers.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        public string Phone { get; set; }
    }
}
