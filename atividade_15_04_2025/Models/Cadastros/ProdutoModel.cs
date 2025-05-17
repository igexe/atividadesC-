using System.ComponentModel.DataAnnotations;

namespace atividade_15_04_2025.Models.Cadastros;

public class ProdutoModel{
    [Required(ErrorMessage="Insira a descrição")]
    public string Descricao{get;set;}=string.Empty;

    [Required(ErrorMessage ="Insira o preço")]
    public double Preco{get;set;}

    [Required(ErrorMessage ="Insira o NCM")]
    public int NCM{get;set;}

    [Required(ErrorMessage="Insira a quantidade")]
    public int Quantidade{get;set;}
}
