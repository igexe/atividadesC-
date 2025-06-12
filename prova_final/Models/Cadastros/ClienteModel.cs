using System.ComponentModel.DataAnnotations;

namespace prova_final.Models.Cadastros;

public class ClienteModel : Entity
{
    [Required(ErrorMessage = "Campo obrigatorio")]
    public string CodigoFiscal { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo obrigatorio")]
    [RegularExpression(@"^\d{1,15}$", ErrorMessage = "Campo deve ter no maximo 15 digitos")]
    public string InscricaoEstatudal { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo obrigatorio")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo obrigatorio")]
    public string NomeFantasia { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo obrigatorio")]
    public string Endereco { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo obrigatorio")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "Campo obrigatorio")]
    public string Bairro { get; set; } = string.Empty;
}