using System;
using System.ComponentModel.DataAnnotations;

namespace GolFullStack.Integration.ViewModels.Business
{
    public class AirplaneViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime RegistradoEm { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QuantidadePassageiros { get; set; }

        public bool Ativo{ get; set; }
        public bool Excluido { get; set; }


    }
}
