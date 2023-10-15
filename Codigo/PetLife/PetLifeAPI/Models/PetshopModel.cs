using System.ComponentModel.DataAnnotations;

namespace PetLifeAPI.Models
{
    public class PetshopModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código do pessoa é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome da Pessoa deve ter entre 5 e 50 caracteres")]
        public string Nome { get; set; } = null!;

        [Display(Name = "CNPJ")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deverá conter 14 caracteres")]
        public string? Cnpj { get; set; }

        [Display(Name = "e-mail")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Email { get; set; } = null!;

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(13, MinimumLength = 8, ErrorMessage = "O Senha deverá conter o 8 digitos no minimo")]
        public string Senha { get; set; } = null!;

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(13, MinimumLength = 11, ErrorMessage = "O Telefone deverá conter o DDD e um número valido")]
        public string Telefone { get; set; } = null!;

        [Required(ErrorMessage = "Campo Requerido")]
        public string Cidade { get; set; } = null!;

        [Required(ErrorMessage = "Campo Requerido")]
        public string Estado { get; set; } = null!;

        [Required(ErrorMessage = "Campo Requerido")]
        public string Rua { get; set; } = null!;

        [Display(Name = "Número Petshop")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Numero { get; set; } = null!;

        [Display(Name = "CEP")]
        public string Cep { get; set; } = null!;
        
    }
}
