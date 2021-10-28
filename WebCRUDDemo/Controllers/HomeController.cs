using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCRUDDemo.Models;

namespace WebCRUDDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<student> list = null;
            using (var db = new DbModel())
            {
                list = db.students.ToList();

            }
            ViewBag.Data = list;

            return View();
        }


        public ActionResult GetAdd()
        {
            return View();
        }

        public JsonResult Add()
        {
            string name = Request.Form["name"].ToString();

            using (var db = new DbModel())
            {
                var model = new student() {
                    name = name
                };
                db.students.Add(model);
            
                var intIndex = db.SaveChanges();
                if (intIndex > 0)
                {

                    return Json(new { Status = "ok" });
                }
                else
                {
                    return Json(new { Status = "error" });
                }
            }
        }


        public ViewResult GetEdit(int id)
        {
            student model = null;
            using (var db = new DbModel())
            {
                model = db.students.FirstOrDefault(x => x.id == id);
            }

            ViewData.Model = model;

            return View();
        }

        public JsonResult Edit()
        {
            string name = Request.Form["name"].ToString();
            string id = Request.Form["id"].ToString();
            var idInt = Convert.ToInt64(id);
            using (var db = new DbModel())
            {
                var model = db.students.FirstOrDefault(x => x.id == idInt);
                model.name = name;
                var intIndex = db.SaveChanges();
                if (intIndex > 0)
                {

                    return Json(new { Status = "ok" });
                }
                else
                {
                    return Json(new { Status = "error" });
                }
            }
        }

        public ActionResult Del(int id)
        {
            using (var db = new DbModel())
            {
                var model = db.students.FirstOrDefault(x => x.id == id);

                if (model != null)
                {
                    db.students.Remove(model);
                }
               

                var intIndex = db.SaveChanges();
                if (intIndex > 0)
                {

                    return Redirect("/Home/Index");
                }
                else
                {
                    return Json(new { Status = "error" });
                }
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}