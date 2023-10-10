using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estadistica
    {
        //metodo para calcular los promedios
        public static ML.Estadistica CaculcarPorcentaje(List<object> cines)
        {
            ML.Estadistica estadistica = new ML.Estadistica();
            decimal total = 0;
            try
            {
                foreach (ML.CIne cine in cines)
                {
                    if (cine.Zona.Nombre == "Norte")
                    {
                        estadistica.Norte += cine.Ventas;
                    }
                    //repetir proceso
                    //calcular total
                    total += cine.Ventas;
                }
                estadistica.Norte = (estadistica.Norte / total) * 100;
                //repetir calculo


            }
            catch (Exception ex)
            {

            }
            return estadistica;
        }
    }
}
