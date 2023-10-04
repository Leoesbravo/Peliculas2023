using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class CineController : Controller
    {
        public ActionResult GetAll()
        {
            //consumir el servicio

            return View();
        }
        public ActionResult Form()
        {

            return View();
        }
    }
}
