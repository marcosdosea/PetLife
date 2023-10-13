using System.ComponentModel.DataAnnotations;

namespace PetLifeWEB.Models
{
    public class ConsultumModel
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public uint Id { get; set; }

        [Display(Name = "Data do Agendamento")]
        [DataType(DataType.Date, ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAgendamento { get; set; }

        [Display(Name = "Data da Consulta")]
        [DataType(DataType.Date, ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataConsulta { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(1, ErrorMessage = "Opções A, R e C")]
        public string Status { get; set; } = null!;

        [Display(Name = "ID do Petshop")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public uint IdPetshop { get; set; }

        [Display(Name = "ID do Atendente")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public uint IdAtendente { get; set; }

        [Display(Name = "ID do Veterinário")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public uint IdVeterinario { get; set; }

        [Display(Name = "ID do Cliente")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public uint IdCliente { get; set; }

        [Display(Name = "ID do Veterinário")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public uint IdPet { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(1000, ErrorMessage = "Limite máximo de caractere atingido")]
        public string Descricao { get; set; } = null!;

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public double Preco { get; set; }
    }
}
