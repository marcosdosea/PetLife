using System.ComponentModel.DataAnnotations;

namespace PetLifeAPI.Models
{
    public class VacinaModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da vacina é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Nome da vacina deve ter entre 1 e 30 caracteres")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Período")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public uint Periodo { get; set; }
    }
}
