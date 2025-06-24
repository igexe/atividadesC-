using System.ComponentModel.DataAnnotations;

namespace prova_final.Models
{
    public class ClienteModel : Entity
    {
        [Required(ErrorMessage = "Campo Codigo Fiscal obrigatório")]
        public string CodigoFiscal { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Inscrição Estadual obrigatório")]
        [RegularExpression(@"^\d{1,15}$", ErrorMessage = "Campo deve ter no máximo 15 dígitos")]
        public string InscricaoEstatudal { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Nome obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Nome Fantasia obrigatório")]
        public string NomeFantasia { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Endereço obrigatório")]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Número obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo Bairro obrigatório")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Cidade obrigatório")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Estado obrigatório")]
        [StringLength(2, ErrorMessage = "Estado deve ter 2 caracteres")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Data obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string? Imagem { get; set; }
    }
}
