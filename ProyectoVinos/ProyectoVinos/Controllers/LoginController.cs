using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoVinos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoVinos.Data;
using Microsoft.EntityFrameworkCore;
using ProyectoVinos.Class;

namespace ProyectoVinos.Controllers
{
    public class LoginController : Controller
    {
        ProyectoVinosContext ctx;

        public LoginController(ProyectoVinosContext _ctx)
        {
            ctx = _ctx;
        }



        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult Registrarse()
        {
            return View();
        }
        public ActionResult Registrarse2()
        {
            return View();
        }





        [BindProperty]
        public Cliente Cliente { get; set; }
        public ActionResult SetCliente()
        {
            return Json(Cliente);
        }

        public ActionResult Login()
        {
            return View();

        }

      
        public ActionResult Login1()
        {
            return View();

        }





        public string Email { get; set; }
        public string pass { get; set; }


        public bool Autenticar()
        {
            return ctx.Cliente.Where(u => u.Correo == this.Email
            && u.Pass == this.pass).FirstOrDefault() != null;
        }




        /*
        [BindProperty]
        public Cliente Usuarios { get; set; }

        public async Task<IActionResult> Login()
    {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {

                var result = ctx.Cliente.Where(x => x.Correo == Usuarios.Correo).SingleOrDefaultAsync();
                if (result == null)
                {
                    NotFound();
                }
                else
                {
                    return Ok();
                }

                return View();

            }


        }

        */


        /*        public async Task<IActionResult> Login1()
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();
                    }
                    else
                    {

                        var result = ctx.Cliente.Where(x => x.Correo == Usuarios.Correo).SingleOrDefaultAsync();
                        if (result == null)
                        {
                            NotFound();
                        }
                        else
                        {
                            return Ok();
                        }

                        return View();

                    }


                }
        */

        // GET: LoginController/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

