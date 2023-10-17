using System.ComponentModel.DataAnnotations;

namespace PetLifeWEB.Models
{
    public class VendumModel
    {
        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Data de Venda")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataVenda { get; set; }

        [Display(Name = "Forma de Pagamento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string FormaPagamento { get; set; } = null!;

        [Display(Name = "Parcelas")]
        public uint? Parcelas { get; set; }

        [Display(Name = "Pago")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Preencher com sim ou não")]
        public sbyte Pago { get; set; }
    }
}
