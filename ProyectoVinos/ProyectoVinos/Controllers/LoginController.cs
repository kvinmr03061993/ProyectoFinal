using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoVinos.Data;
using ProyectoVinos.Models;

namespace ProyectoVinos.Controllers
{
    public class LoginController : Controller
    {
        private readonly ProyectoVinosContext _context;

        public LoginController(ProyectoVinosContext context)
        {
            _context = context;
        }

        // GET: Login
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        public IActionResult InicioSesion()
        {
            return View(); ;
        }


        public async Task<IActionResult> InicioSesion2(Cliente cli)
        {
            var result = await _context.Cliente.Where(x => x.Correo == cli.Correo && x.Pass == cli.Pass).FirstOrDefaultAsync();
            if (result != null)
            {
        


                if (result.Rol == "cliente")
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                    identity.AddClaim(new Claim(ClaimTypes.Name, result.Correo.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.Nombre.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Role, result.Rol.ToString()));

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddHours(1),
                        IsPersistent = true
                    });


                    return RedirectToAction("Index", "Home");
                }
                else if (result.Rol == "Admin")
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                    identity.AddClaim(new Claim(ClaimTypes.Name, result.Correo.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.Nombre.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Role, result.Rol.ToString()));

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddHours(1),
                        IsPersistent = true
                    });

                    return RedirectToAction("Index2", "Home");
                }
                else
                {
                    return RedirectToAction("InicioSesion", "Clientes");
                }
            }

            else
            {
                ViewBag.MensajeInicio = "El nombre de usuario o la contraseña no coinciden con nuestros registros. Por favor, revisar e intentarlo de nuevo.";
                return View("InicioSesion");
            }
        }



        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }







        // GET: Login/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Login/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,Nombre,PrimerApellido,SegundoApellido,Correo,Telefono,Usuario,Pass,Direccion,Provincia,Canton,Distrito,FechaNacimiento,Rol")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Login/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,Nombre,PrimerApellido,SegundoApellido,Correo,Telefono,Usuario,Pass,Direccion,Provincia,Canton,Distrito,FechaNacimiento,Rol")] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.IdCliente))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Login/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.IdCliente == id);
        }
    }
}
