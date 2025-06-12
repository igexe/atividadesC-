using Microsoft.AspNetCore.Mvc;
using prova_final.Models.Cadastros;

namespace prova_final.Controllers;

public class ClienteController : Controller
{
    public IActionResult Cadastro()
    {
        return View(new ClienteModel{Id=0});
    }

    public IActionResult Listar()
    {
        Repositorio<ClienteModel> repositorio = new Repositorio<ClienteModel>();
        var dados = repositorio.Listar();
        return View(dados);
    }

    [HttpPost]
    public IActionResult Salvar(ClienteModel modelo)
    {
        if (ModelState.IsValid)
        {
            return View("Cliente");
        }
        else
        {
            ViewBag.Error = "Dados Invalidos";
            return View("Produto", modelo);
        }
    }
}