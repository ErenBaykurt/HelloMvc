using HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelloMvc.Controllers
{
    public class DersController : Controller
    {
        public IActionResult Index()
        {
            List<Ders> lst = null;
            using (var c = new OkulDbContext())
            {
                lst = c.Dersler.ToList();
               
            }
            return View(lst);
        }
        public IActionResult AddDers()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddDers(Ders ders)
        {
            if (ders != null)
            {
                using (var c = new OkulDbContext())
                {
                    c.Dersler.Add(ders);
                    c.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult EditDers(int id)
        {
            Ders ders = null;
            using (var c = new OkulDbContext())
            {
                ders = c.Dersler.Find(id);
            }
            return View(ders);
        }
        
        [HttpPost]
        public IActionResult EditDers(Ders ders)
        {
            using (var c = new OkulDbContext())
            {
                c.Entry(ders).State = EntityState.Modified;
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDers(int id)
        {
            using (var c = new OkulDbContext())
            {
                c.Dersler.Remove(c.Dersler.Find(id));
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
