using HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelloMvc.Controllers
{
    public class OgrenciDersController : Controller
    {
        public IActionResult Index()
        {
            List<OgrenciDersler> lst;
            using (var ctx = new OkulDbContext())
            {
                lst = ctx.OgrenciDersleri.ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public IActionResult alinanDersler(int ogrenciid)
        {
            List<OgrenciDersler> ogDersleri;
            using (var ctx = new OkulDbContext())
            {
                ogDersleri = ctx.OgrenciDersleri
                                .Include(od => od.ders)
                                .Include(od => od.Ogrenci)
                                .Where(od => od.Ogrenciid == ogrenciid)
                                .ToList();
                ViewBag.OgrenciId = ogrenciid;
            }
            return View(ogDersleri);
        }

        [HttpGet]
        public IActionResult OgrenciDersEkle(int ogrenciid)
        {
            using (var ctx = new OkulDbContext())
            {
                var existingDersIds = ctx.OgrenciDersleri
                                         .Where(od => od.Ogrenciid == ogrenciid)
                                         .Select(od => od.Dersid)
                                         .ToList();

                var availableDersler = ctx.Dersler
                                          .Where(d => !existingDersIds.Contains(d.DersId))
                                          .ToList();

                ViewData["OgrenciId"] = ogrenciid;
                return View(availableDersler);
            }
        }

        [HttpPost]
        public IActionResult OgrenciDersEkle(int ogrenciid, int dersid)
        {
            var ogrenciDersler = new OgrenciDersler
            {
                Ogrenciid = ogrenciid,
                Dersid = dersid
            };

            using (var ctx = new OkulDbContext())
            {
                ctx.OgrenciDersleri.Add(ogrenciDersler);
                ctx.SaveChanges();
            }

            return RedirectToAction("alinanDersler", new { Ogrenciid = ogrenciid });
        }

    }
}
