using System.ComponentModel.DataAnnotations;

namespace PetLifeWEB.Models
{
    public class VendumModel
    {
        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Id { get; set; } = null!;

        [Display(Name = "Data de Venda")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataVenda { get; set; }

        [Display(Name = "Forma de Pagamento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string FormaPagamento { get; set; } = null!;
        
        [Display(Name = "Parcelas")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public uint? Parcelas { get; set; }

        [Display(Name = "Pago")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public sbyte Pago { get; set; }
    }
}
