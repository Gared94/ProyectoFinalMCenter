using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCENTER.Models;
namespace MCENTER.Controllers
{
    public class VentasListadoController : Controller
    {

        private MCENTEREntities4 ce = new MCENTEREntities4();
        // GET: VentasListado
        public ActionResult Index()
        {
            return View(ce.Venta.ToList().OrderBy(x => x.DiaVenta));
        }

        public ActionResult Detalles(int idventa)
        {
            return View();
        }

    }
}