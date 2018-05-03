using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M0502.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            var Comment = new Models.Comment();
            Comment.Subject = "Buen Producto";
            Comment.HtmlSubject = "El producto es <i> muy bueno </i>";
            return View(Comment);
        }
    }
}