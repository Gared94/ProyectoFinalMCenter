using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MCENTER.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.USUARIOS objUsers)
        {
            if (ModelState.IsValid)
            {
                using (Models.MCENTEREntities4 db = new Models.MCENTEREntities4())
                {
                    var obj = db.USUARIOS.Where(a => a.usuario.Equals(objUsers.usuario) && a.clave.Equals(objUsers.clave)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["id_usuario"] = obj.id_usuario.ToString();
                        Session["usuario"] = obj.usuario.ToString();
                        Session["id_rol"] = obj.id_rol.ToString();
                        String rol = obj.id_rol.ToString();

                        if (rol == "1") { 
                       
                        return RedirectToAction("Index_admin", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            return View(objUsers);



        }



        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}