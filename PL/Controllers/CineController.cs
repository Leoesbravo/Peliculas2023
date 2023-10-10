using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class CineController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result result = BL.Cine.GetAll();
            ML.CIne cine = new ML.CIne(result.Objects);
            //consumir el servicio

            return View(cine);
        }
        [HttpGet]
        public ActionResult Form(int? idCine)
        {
            if(idCine > 0)
            {
                ML.Result result = BL.Cine.GetById(idCine.Value);
                ML.CIne cine = (ML.CIne)result.Object;
                return View(cine);
            }
            else
            {
                return View();
            }
        }
    }
}
