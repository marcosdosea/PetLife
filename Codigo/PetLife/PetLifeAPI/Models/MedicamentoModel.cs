using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PetLifeAPI.Models
{
    public class MedicamentoModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código do medicamento é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Nome do Medicamento deve ter entre 5 e 30 caracteres")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Importado")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Preencher com sim ou não")]
        public string? Importado { get; set; } = null!;

        [Display(Name = "Ativo")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Preencher com sim ou não")]
        public string? Ativo { get; set; } = null!;
    }
}
