using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using atividade_15_04_2025.Models.Cadastros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace atividade_15_04_2025.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

         [HttpPost]
         public IActionResult Salvar(PessoaModel modelo){
            if(ModelState.IsValid){
                Console.WriteLine($"Nome: {modelo.Nome}");
                Console.WriteLine($"Sobrenome: {modelo.Sobrenome}");
                Console.WriteLine($"Endereço: {modelo.Endereco}");
                Console.WriteLine($"Cidade: {modelo.Cidade}");
                Console.WriteLine($"CEP: {modelo.CEP}");
                Console.WriteLine($"Telefone: {modelo.Telefone}");
                return View("Index");
            }else{
                ViewBag.Error="Dados Invalidos";
                return View("Index", modelo);
            }
         }
    }
}