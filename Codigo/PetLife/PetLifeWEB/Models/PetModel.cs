using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PetLifeWEB.Models
{
    public class PetModel
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Id { get; set; }
        [Display(Name = "Nome do pet")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Nome do pet deve conter entre 1 e 30 caracteres")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Espécie")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Espécie deve conter entre 1 e 15 caracteres")]
        public string Especie { get; set; } = null!;

        [Display(Name = "Raça")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Raça deve conter entre 1 e 15 caracteres")]
        public string Raca { get; set; } = null!;

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(1, ErrorMessage = "Sexo deve conter apenas 1 caractere")]
        public string Sexo { get; set; } = null!;

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public double Peso { get; set; }
    }
}
