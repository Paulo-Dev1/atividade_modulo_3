using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Flyturismo.Models
{
    public class Hospedagem
    {
        [Key]
        public int Id_Hospedagem { get; set; }

        [Required]
        [DisplayName("Tipo de hospedagem")]
        public string Tipo_Hospedagem { get; set; }

        [Required]
        [DisplayName("Data de entrada")]
        public string Data_Entrada { get; set; }

        [Required]
        [DisplayName("Data de saída")]
        public string Data_Saida { get; set; }
    }
}