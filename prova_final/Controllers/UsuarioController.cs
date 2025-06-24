using Microsoft.AspNetCore.Mvc;
using prova_final.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography;

namespace prova_final.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly Repositorio<UsuarioModel> repo = new Repositorio<UsuarioModel>();

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(); // Login
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(UsuarioModel model)
        {
            List<UsuarioModel> usuarios = repo.Listar();

            if (string.IsNullOrEmpty(model.Usuario) || string.IsNullOrEmpty(model.Senha))
            {
                ViewBag.Errors = "Campo login e senha é obrigatório";
                return View("Index", model);
            }

            var usuario = usuarios.FirstOrDefault(p => p.Usuario == model.Usuario);
            Hash hash = new Hash(SHA256.Create());

            if (usuario != null && hash.validarSenha(model.Senha, usuario.Senha))
            {
                HttpContext.Session.SetString("UsuarioLogado", model.Usuario);

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.Usuario));
                identity.AddClaim(new Claim(ClaimTypes.Name, model.Usuario));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

                var principal = new ClaimsPrincipal(identity);

                var authProps = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                    IsPersistent = true
                };

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps).Wait();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Errors = "Usuário ou senha inválidos";
                return View("Index", model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Cadastrar(UsuarioModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            List<UsuarioModel> usuarios = repo.Listar();

            if (usuarios.Any(u => u.Usuario == model.Usuario))
            {
                ViewBag.Errors = "Usuário já existe";
                return View(model);
            }

            Hash hash = new Hash(SHA256.Create());
            model.Senha = hash.CriptografarSenha(model.Senha);

            repo.Adicionar(model);

            TempData["Message"] = "Usuário cadastrado com sucesso. Faça login para continuar.";
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Editar()
        {
            var usuarioLogado = HttpContext.User.Identity?.Name;
            var usuario = repo.Listar().FirstOrDefault(u => u.Usuario == usuarioLogado);

            if (usuario == null)
                return Unauthorized();

            return View(usuario);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Editar(UsuarioModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuarioLogado = HttpContext.User.Identity?.Name;
            var usuario = repo.Listar().FirstOrDefault(u => u.Usuario == usuarioLogado);

            if (usuario == null)
                return Unauthorized();

            Hash hash = new Hash(SHA256.Create());
            usuario.Usuario = model.Usuario;
            usuario.Senha = hash.CriptografarSenha(model.Senha);

            repo.Atualizar(usuario);

            TempData["Message"] = "Usuário atualizado com sucesso.";
            return RedirectToAction("Index", "Home");
        }

    }
}