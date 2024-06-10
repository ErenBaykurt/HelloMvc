using HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<Ogrenci> lst = null;
            using(var ctx = new OkulDbContext())
            {
                 lst = ctx.Ogrenciler.ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public IActionResult AddStudent() {
        return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Ogrenci ogr)
        {
            if (ogr != null)
            {
                using (var ctx= new OkulDbContext())
                {
                    ctx.Ogrenciler.Add(ogr);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }


        public IActionResult EditStudent(int id)
        {
            Ogrenci ogr = null;
            using(var ctx = new OkulDbContext())
            {
                ogr = ctx.Ogrenciler.Find(id);
            }
            return View(ogr);
        }
        [HttpPost]
        public IActionResult EditStudent(Ogrenci ogr)
        {
            using (var ctx= new OkulDbContext())
            {
                ctx.Entry(ogr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();  
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteStudent(int id)
        {
            using (var ctx = new OkulDbContext())
            {
               ctx.Ogrenciler.Remove(ctx.Ogrenciler.Find(id));
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
