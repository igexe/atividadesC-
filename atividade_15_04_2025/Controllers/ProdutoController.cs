using atividade_15_04_2025.Models.Cadastros;
using Microsoft.AspNetCore.Mvc;

namespace atividade_15_04_2025.controllers{
    public class ProdutoController:Controller{
        public IActionResult Produto(){
            return View();
        }


        [HttpPost]
        public IActionResult Salvar(ProdutoModel modelo){
            if(ModelState.IsValid){
                Console.WriteLine($"Descricao: {modelo.Descricao}");
                Console.WriteLine($"Preço: {modelo.Preco}");
                Console.WriteLine($"NCM: {modelo.NCM}");
                Console.WriteLine($"Quantidade: {modelo.Quantidade}");
                return View("Produto");
            }else{
                ViewBag.Error="Dados Invalidos";
                return View("Produto",modelo);
            }
        }
    }
}