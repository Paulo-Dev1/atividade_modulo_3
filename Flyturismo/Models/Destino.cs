using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Flyturismo.Models
{
    public class Destino
    {
        [Key]
        public int Id_Destino { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        [DisplayName("País")]
        public string Pais { get; set; }
    }
}