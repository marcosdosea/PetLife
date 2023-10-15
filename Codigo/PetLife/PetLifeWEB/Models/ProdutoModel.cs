using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PetLifeWEB.Models
{
    public class ProdutoModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Id do produto é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Nome do Produto deve ter entre 5 e 40 caracteres")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código do produto é obrigatório")]
        public uint Codigo { get; set; }

        [Display(Name = "Ativo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public sbyte Ativo { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public uint Quantidade { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(400, MinimumLength = 5, ErrorMessage = "A descrição do Produto deve ter no mínimo 5 e no máximo 400 caracteres")]
        public string Descricao { get; set; } = null!;


        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public double Preco { get; set; }

        [Display(Name = "IdPetshop")]
        [Required(ErrorMessage = "Id do petshop é obrigatório")]
        [Key]
        public uint IdPetshop { get; set; }
    }
}
