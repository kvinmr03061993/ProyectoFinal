using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoVinos.Class;
using ProyectoVinos.Data;
using ProyectoVinos.Models;

namespace ProyectoVinos.Controllers
{

    public class ClientesController : Controller
    {
        private readonly ProyectoVinosContext _context;

        public ClientesController(ProyectoVinosContext context)
        {
            _context = context;
        }
        // GET: Clientes

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        // GET: Clientes/Details/5
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


   
        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
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
                //llenar cookie
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.Name, cliente.IdCliente.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, cliente.Nombre.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Role, cliente.Rol.ToString()));

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddHours(1),
                    IsPersistent = true
                    
                });
                return RedirectToAction("Index", "Home");

                //return RedirectToAction(nameof(Index));

            }
            return View(cliente);
        }
        [Authorize(Roles = "Admin")]
        // GET: Clientes/Edit/5
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
        [Authorize(Roles = "Admin")]
        // POST: Clientes/Edit/5
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
        [Authorize(Roles = "Admin")]
        // GET: Clientes/Delete/5
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
        [Authorize(Roles = "Admin")]
        // POST: Clientes/Delete/5
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
        [Authorize(Roles = "cliente")]
        public async Task<IActionResult> ActualizarCliente()
        {
            int idCliente = Int32.Parse(SessionHelper.GetName(User));
            var result = await _context.Cliente.Where(x => x.IdCliente == idCliente).FirstOrDefaultAsync();

            Cliente usu = new Cliente();
            usu.IdCliente = result.IdCliente;
            usu.Nombre = result.Nombre;
            usu.PrimerApellido = result.PrimerApellido;
            usu.SegundoApellido = result.SegundoApellido;
            usu.Correo = result.Correo;
            usu.Telefono = result.Telefono;
            usu.Usuario = result.Usuario;
            usu.Pass = result.Pass;
            usu.Direccion = result.Direccion;
            usu.Provincia = result.Provincia;
            usu.Canton = result.Canton;
            usu.Distrito = result.Distrito;
            usu.FechaNacimiento = result.FechaNacimiento;
            usu.Rol = result.Rol;

            return View(usu);

        }
        [Authorize(Roles = "cliente")]
        public async Task<IActionResult> ActualizarCliente2(Cliente cliente) {
           
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}


