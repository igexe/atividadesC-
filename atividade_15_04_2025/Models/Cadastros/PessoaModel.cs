namespace atividade_15_04_2025.Models.Cadastros;
using System.ComponentModel.DataAnnotations;

public class PessoaModel{
    [Required(ErrorMessage ="Informe o nome")]
    public string Nome{get;set;}=string.Empty;
    
    [Required(ErrorMessage ="Informe o sobrenome")]
    public string Sobrenome{get;set;}=string.Empty;
    
    [Required(ErrorMessage ="Informe o endereço")]
    public string Endereco{get;set;}=string.Empty;
    
    [Required(ErrorMessage ="Informe a cidade")]
    public string Cidade{get;set;}=string.Empty;
    
    [Required(ErrorMessage ="Informe o CEP")]
    public int CEP{get;set;}

    [Required(ErrorMessage ="Informe o telefone")]
    public string Telefone{get;set;}=string.Empty;
}
