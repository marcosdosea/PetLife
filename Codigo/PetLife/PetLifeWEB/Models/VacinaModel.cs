﻿using System.ComponentModel.DataAnnotations;

namespace PetLifeWEB.Models 
{
    public class VacinaModel 
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Id { get; set; }

        [Display(Name = "Nome da vacina")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Nome da vacina deve conter entre 1 e 30 caracteres")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Período")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public uint Periodo { get; set; }
    }
}
