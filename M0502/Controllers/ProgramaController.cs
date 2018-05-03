using M0502.Models;
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
            var Context = new SaludMovilEntities();
            var Programas = Context.sm_Programa.ToArray();
            return View(Programas);
        }

        public ActionResult Display(int id)
        {
            var Context = new Models.SaludMovilEntities();
            var Programa = Context.sm_Programa.Where(p => p.idPrograma == id).FirstOrDefault();
            return View(Programa);
        }

        //public FileStreamResult GetImage()
        //{

        //}

        public ActionResult Create()
        {
            var Programa = new sm_Programa();
            return View(Programa);
        }

        [HttpPost]
        public ActionResult Create(sm_Programa newPrograma)
        {
            ActionResult Result = View(newPrograma);
            if (ModelState.IsValid)
            {
                using (var Context = new SaludMovilEntities())
                {
                    Context.sm_Programa.Add(newPrograma);
                    Context.SaveChanges();
                    Result = RedirectToAction("Display", new { id = newPrograma.idPrograma});
                }
            }
            return Result;
        }
        [HttpPost]
        public ActionResult UploadPhoto2(sm_Programa newPrograma, HttpPostedFileBase file)
        {
            ActionResult Result = View(newPrograma);

            if (file != null && file.ContentLength > 0)
            {
                Result = File(file.InputStream, file.ContentType);
            }
            return Result;
        }

        [HttpPost]
        public ActionResult UploadPhoto(sm_Programa newPrograma)
        {
            ActionResult Result = View(newPrograma);

            if (Request.Files.Count > 0 && Request.Files[0].ContentLength> 0)
            {
                Result = File(Request.Files[0].InputStream, Request.Files[0].ContentType);
            }
            return Result;
        }
    }
}