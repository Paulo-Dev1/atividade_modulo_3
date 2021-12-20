using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Flyturismo.Models
{
    public class Cliente
    {
        [Key]
        public int Id_Cliente {get;set;}

        [Required]
        public string Nome {get;set;}

        [Required]
        public int Idade {get;set;}

        [Required]
        public int CPF {get;set;}

        [Required]
        public string Telefone {get;set;}

        [Required]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [Required]
        public int DestinoId_destino { get; set; }
        [DisplayName("Cidade")]
        public Destino Destino { get; set;}
        

        [Required]
        public int HospedagemId_hospedagem {get; set;}
        [DisplayName("Entrada")]
        public Hospedagem Hospedagem { get; set;}
    }
}