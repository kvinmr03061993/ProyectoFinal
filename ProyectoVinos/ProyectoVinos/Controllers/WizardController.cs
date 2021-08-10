using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoVinos.Models;
using ProyectoVinos.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProyectoVinos.Class;
using Microsoft.EntityFrameworkCore;

namespace ProyectoVinos.Controllers
{
    public class WizardController : Controller
    {

        private readonly ProyectoVinosContext _context;

     
        public WizardController (ProyectoVinosContext context)
        {
            _context = context;
        }

  
        public ActionResult RealizarPedido()
        {
            var model = new ModeloWizard();
            model.VinoList = new SelectList(_context.Vino.Select(r => new SelectListItem
            {
                Text = r.Nombre+"-"+r.Marca+"-"+r.Año,
                Value = r.IdVino.ToString(),
            }), "Value", "Text");

            model.DiseñoList = new SelectList(_context.Diseño.Select(r => new SelectListItem
            {
                Text = r.Nombre,
                Value = r.IdDiseño.ToString(),
            }), "Value", "Text");

      


            return View(model);
        }

        [HttpPost]
        public ActionResult RealizarPedido(ModeloWizard model)
        {
            if (!ModelState.IsValid)
            {
                model.VinoList = new SelectList(_context.Vino.Select(r => new SelectListItem
                {
                    Text = r.Nombre + "-" + r.Marca + "-" + r.Año,
                    Value = r.IdVino.ToString(),
                }), "Value", "Text");

                model.DiseñoList = new SelectList(_context.Diseño.Select(r => new SelectListItem
                {
                    Text = r.Nombre,
                    Value = r.IdDiseño.ToString(),
                }), "Value", "Text");
                return View(model);
            }

            model.Diseño = _context.Diseño.Find(model.IdDiseño);
            model.Vino = _context.Vino.Find(model.IdVino);
            model.Descripcion = model.Descripcion;
            model.PrecioTotal = ( model.Vino.PrecioBase);
            model.FechaEntrega = DateTime.Now.AddDays(3);
            
     

            HttpContext.Session.SetString("Pedido", JsonConvert.SerializeObject(model));


            return View("DetallesPedido", model);
        }

        [HttpPost]
        public ActionResult RealizarPedido2(ModeloWizard model)
        {
            if (!ModelState.IsValid)
            {
                model.VinoList = new SelectList(_context.Vino.Select(r => new SelectListItem
                {
                    Text = r.Nombre + "-" + r.Marca + "-" + r.Año,
                    Value = r.IdVino.ToString(),
                }), "Value", "Text");

                model.DiseñoList = new SelectList(_context.Diseño.Select(r => new SelectListItem
                {
                    Text = r.Nombre,
                    Value = r.IdDiseño.ToString(),
                }), "Value", "Text");
                return View(model);
            }

            model.Diseño = _context.Diseño.Find(model.IdDiseño);
            model.Vino = _context.Vino.Find(model.IdVino);
            model.PrecioTotal = (model.Vino.PrecioBase);
            model.FechaEntrega = DateTime.Now.AddDays(3);



            HttpContext.Session.SetString("Pedido", JsonConvert.SerializeObject(model));


            return View("DetallesPedido", model);
        }


        private int getUserId()
        {
            return _context.Cliente.Where(u => u.IdCliente == Int32.Parse(SessionHelper.GetName(User))).First().IdCliente;
        }




        [HttpPost]
        public ActionResult DetallesPedido()
        {
            var modelo = JsonConvert.DeserializeObject<ModeloWizard>(HttpContext.Session.GetString("Pedido")) as ModeloWizard;
            
            String usuario = SessionHelper.GetName(User);
            int user2 = Int32.Parse(usuario);

            String NumPedido = getUserId()+""+ Random();
            int Numconv = Int32.Parse(NumPedido);
            /*
            int idPe = Int32.Parse(usuario + "" + Random());
            */
            var PedidoFinal = _context.Pedido.Add(new Pedido
            {
                IdPedido = Numconv,
                FechaCreacion = DateTime.Now,
                FechaEntrega = modelo.FechaEntrega,
                IdCliente = getUserId(),
                PrecioTotal = modelo.PrecioTotal,
                Estado="Pediente"
            });; ;


            _context.SaveChanges();

          


            _context.ItemPedido.Add(new ItemPedido
            {
                Cantidad = modelo.IdDiseño,
                IdPedido = Numconv,
                Descripcion = modelo.Descripcion,
                IdVino = modelo.IdVino,
                Precio = modelo.PrecioTotal,
                IdDiseño = modelo.IdDiseño,
            });

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        public int Random() {


            Random r = new Random();

           
            int num = r.Next(10, 500);

            

            return num;
        
        }
            

        public IActionResult Index()
        {
            return View();
        }
    }
}
