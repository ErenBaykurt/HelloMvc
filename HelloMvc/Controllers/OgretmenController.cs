using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers
{
    public class OgretmenController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult OgretmenListe()
        {
            return View();
        }
    }
}
