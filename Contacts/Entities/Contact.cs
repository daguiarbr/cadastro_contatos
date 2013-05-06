using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Entities
{
    [Table("contacts")]
    public class Contact
    {
        [Key]
        [Display(Name = "Código")]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("Name")]
        [Required(ErrorMessage = "Nome é requerido")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 80 caracteres")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Column("Email")]
        [Required(ErrorMessage = "Email é requerido")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Email não é válido")]
        public string Email { get; set; }

        [Display(Name = "Endereço")]
        [Column("Address")]
        [Required(ErrorMessage = "Endereço é requerido")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Endereço deve ter entre 3 e 80 caracteres")]
        public string Address { get; set; }

        [Display(Name = "Número")]
        [Column("Number")]
        [Required(ErrorMessage = "Número é requerido")]
        public string Number { get; set; }

        [Display(Name = "Bairro")]
        [Column("Neighborhood")]
        [Required(ErrorMessage = "Bairro é requerido")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Bairro deve ter entre 3 e 25 caracteres")]
        public string Neighborhood { get; set; }

        [Display(Name = "Cidade")]
        [Column("City")]
        [Required(ErrorMessage = "Cidade é requerida")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Cidade deve ter entre 3 e 25 caracteres")]
        public string City { get; set; }

        [Display(Name = "Estado")]
        [Column("State")]
        [Required(ErrorMessage = "Estado é requerido")]
        [RegularExpression("([a-zA-Z])*", ErrorMessage = "Estado não é válido")]
        public string State { get; set; }

        [Display(Name = "Cep")]
        [Column("ZipCode")]
        [Required(ErrorMessage = "Cep é requerido")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "Cep não é válido")]
        public string ZipCode { get; set; }

        [Display(Name = "DDD")]
        [Column("Ddd")]
        [Required(ErrorMessage = "DDD é requerido")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Ddd não é válido")]
        public string Ddd { get; set; }

        [Display(Name = "Telefone")]
        [Column("PhoneNumber")]
        [Required(ErrorMessage = "Telefone é requerido")]
        [RegularExpression(@"\d{4}-\d{4}$", ErrorMessage = "Telefone não é válido")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Data de Criação")]
        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }

        public string AddressNumber
        {
            get { return Address + " " + Number; }
        }

        public string CityState
        {
            get { return City + "/" + State; }
        }

        public string DddPhoneNumber
        {
            get { return "(" + Ddd + ")" + " " + PhoneNumber; }
        }

    }
}