using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MCENTER.Controllers
{
    public class MisionVisionController : Controller
    {
        // GET: MisionVision
        public ActionResult MisionVision()
        {
            ViewBag.Message = "Nuestra Mision y Vision.";
            return View();
        }



        public ActionResult QuienesSomos()
        {
            ViewBag.Message = "Quienes somos.";
            return View();
        }
    }
}