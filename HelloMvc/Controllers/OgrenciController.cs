using HelloMvc.Models;
using HelloMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers
{
    public class OgrenciController : Controller
    {
        public string Index()//Action Metod
        {

            return "Ogrenci İslemleri Ana Sayfası";
        }
        public ViewResult OgrenciDetay(int id) 
        {
            var drs = new Ders { DersAd = "Programlama" };
            var ogrt = new Ogretmen { Ad="a",Soyad="b",OgretmenId=1};
            Ogrenci ogr = null;
            if (id == 1)
            {
                ogr = new Ogrenci { Ad = "Ahmet",Soyad = "Mehmet", Numara= 456};
            }
            else if (id == 2)
            {
                ogr = new Ogrenci { Ad = "Ali", Soyad = "Veli", Numara = 123 };
            }
            
            ViewData["ogrenci"]=ogr;
            ViewBag.student = ogr;
            ViewBag.teacher = ogrt;
            
            OgrViewModel vm = new OgrViewModel();
            vm.Ogretmen = ogrt;
            vm.Ogrenci = ogr;
            vm.Ders = drs;
            //vm.Ders=new Ders {DersAd = "Programlama"};
            return View(vm);
        }

        public ViewResult OgrenciListe()
        {
            var lst = new List<Ogrenci>();
            lst.Add(new Ogrenci { Ad = "Ali", Soyad = "Veli", Numara = 123 });
            lst.Add(new Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Numara = 456 });

            return View(lst);
        }
    }
    //Controller'dan View'e Veri Taşıma Yöntemleri
    //ViewData: Koleksiyon yapısıdır. Dictinory türünde koleksiyonlardır. Dictionary yapıları key-value pair'lerden oluşur.Keyler tekil olmalıdır.(Dynamic değil)
    //Keyler string, value'lar object türündedir.
    //ViewBag: ViewData üstüne geliştirilmiş bir yapıdır. Arkaplanda ViewData koleksiyonunu kullanır.(Dynamic)
    //ViewModel
}
