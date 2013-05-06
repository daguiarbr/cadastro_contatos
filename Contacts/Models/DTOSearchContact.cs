using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{

    public class DTOSearchContact
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}
