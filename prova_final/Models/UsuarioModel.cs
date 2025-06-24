using System.ComponentModel.DataAnnotations;

namespace prova_final.Models
{
    public class UsuarioModel : Entity
    {
        [Required(ErrorMessage = "Campo usuário é obrigatório")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        public string Senha { get; set; } = string.Empty;
    }
}
