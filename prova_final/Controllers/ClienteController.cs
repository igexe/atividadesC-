using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using prova_final.Models;
using System.Text.Json;

namespace prova_final.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly Repositorio<ClienteModel> repositorio = new Repositorio<ClienteModel>();

        private void CarregarEstadosECidades()
        {
            string caminhoJson = Path.Combine(Directory.GetCurrentDirectory(), "estados-cidades.json");

            if (System.IO.File.Exists(caminhoJson))
            {
                var json = System.IO.File.ReadAllText(caminhoJson);
                ViewBag.EstadosJson = json;
            }
            else
            {
                ViewBag.EstadosJson = "[]";
            }
        }

        public IActionResult Listar()
        {
            var dados = repositorio.Listar();
            return View(dados);
        }

        public IActionResult Cadastro(int? id)
        {
            CarregarEstadosECidades();

            if (id.HasValue)
            {
                var cliente = repositorio.Buscar(id.Value);
                if (cliente == null)
                    return NotFound();

                return View(cliente);
            }

            return View(new ClienteModel { Id = 0 });
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(ClienteModel modelo, IFormFile imagemUpload)
        {
            if (modelo.DataNascimento == null || modelo.DataNascimento < new DateTime(1950, 1, 1))
            {
                ModelState.AddModelError("DataNascimento", "A data deve ser posterior a 01/01/1950.");
            }

            if (!ModelState.IsValid)
            {
                CarregarEstadosECidades();
                ViewBag.Erro = "Dados inválidos.";
                return View("Cadastro", modelo);
            }

            var clientes = repositorio.Listar();

            bool duplicado = clientes.Any(c =>
                (c.CodigoFiscal == modelo.CodigoFiscal || c.InscricaoEstatudal == modelo.InscricaoEstatudal)
                && c.Id != modelo.Id);

            if (duplicado)
            {
                CarregarEstadosECidades();
                ViewBag.Erro = "Já existe um cliente com o mesmo Código Fiscal ou Inscrição Estadual.";
                return View("Cadastro", modelo);
            }

            // Upload de imagem
            if (modelo.Id == 0 && (imagemUpload == null || imagemUpload.Length == 0))
            {
                ModelState.AddModelError("imagemUpload", "A imagem é obrigatória para novos cadastros.");
            }
            else if (imagemUpload != null && imagemUpload.Length > 0)
            {
                var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagemUpload.FileName);
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens");
                Directory.CreateDirectory(caminhoPasta); // Garante que a pasta existe

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await imagemUpload.CopyToAsync(stream);
                }

                modelo.Imagem = "/imagens/" + nomeArquivo;
            }


            if (modelo.Id == 0)
                repositorio.Adicionar(modelo);
            else
                repositorio.Atualizar(modelo);

            return RedirectToAction("Listar");
        }

        public IActionResult Remover(int id)
        {
            repositorio.Remover(id);
            return RedirectToAction("Listar");
        }

        public IActionResult Exportar(int id)
        {
            var cliente = repositorio.Buscar(id);
            if (cliente == null)
                return NotFound();

            var json = System.Text.Json.JsonSerializer.Serialize(cliente, new JsonSerializerOptions { WriteIndented = true });
            var fileBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var nomeArquivo = $"cliente_{id}.json";

            return File(fileBytes, "application/json", nomeArquivo);
        }
    }
}