using CrudEFCoreNet6.Datos;
using CrudEFCoreNet6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace CrudEFCoreNet6.Controllers
{
    public class HomeController : Controller
    {
        private readonly AplicationDBContext _contexto;

        public HomeController(AplicationDBContext contexto)
        {
            _contexto= contexto;
            
        }
        [HttpGet]

        public IActionResult  Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                _contexto.Usuarios.Add(usuario);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuarios.Update(usuario);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _contexto.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Detalle(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var usuario = _contexto.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpGet]
        public  IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _contexto.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);

        }
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>BorrarUsuario(int? id)
        {
          var usuario = await _contexto.Usuarios.FindAsync(id);
            if (ModelState.IsValid)
            {
                _contexto.Usuarios.Remove(usuario);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Usuarios.ToListAsync());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}