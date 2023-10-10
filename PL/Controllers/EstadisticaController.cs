using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace PL.Controllers
{
    public class EstadisticaController : Controller
    {
        public ActionResult Index()
        {
            ML.Result result = BL.Cine.GetAll();
            ML.CIne cine = new ML.CIne(result.Objects);
            ML.Estadistica estadistica = BL.Estadistica.CaculcarPorcentaje(cine.Cines);
            cine.Estadistica = new ML.Estadistica(estadistica.Norte, estadistica.Sur, estadistica.Este, estadistica.Oeste);
            return View(cine);
        }
         
    }
}
