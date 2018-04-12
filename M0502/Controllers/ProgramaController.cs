using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M0502.Controllers
{
    public class ProgramaController : Controller
    {
        // GET: Programa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(int id)
        {
            var Context = new Models.SaludMovilEntities();
            var Programa = Context.sm_Programa.Find(id);
            return View(Programa);
        }

        //public FileStreamResult GetImage()
        //{

        //}
    }
}