using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCENTER.Models;

namespace MCENTER.Controllers
{
    public class ProductoListadoController : Controller
    {
        // GET: Producto

        private MCENTEREntities4 ce = new MCENTEREntities4();


        public ActionResult Index()
        {



            return View(ce.Producto.ToList().OrderBy(x=>x.Nombre));
        }
    }
}