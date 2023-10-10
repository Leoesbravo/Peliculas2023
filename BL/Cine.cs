using Microsoft.EntityFrameworkCore;
using ML;

namespace BL
{
    public class Cine
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PruebaContext context = new DL.PruebaContext())
                {
                    var query = context.Cines.FromSqlRaw("CineGetAll").ToList();
                    if (query != null)
                    {

                        result.Objects = new List<object>();
                        foreach (var registro in query)
                        {
                            ML.CIne cine = new ML.CIne();
                            cine.IdCine = registro.IdCine;
                            cine.Nombre = registro.Nombre;
                            cine.Direccion = registro.Direccion;
                            cine.Ventas = registro.Ventas.Value;
                            cine.Zona = new ML.Zona();
                            cine.Zona.IdZona = registro.IdZona.Value;
                            cine.Zona.Nombre = registro.ZonaNombre;
                            result.Objects.Add(cine);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static Result GetById(int idCine)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PruebaContext context = new DL.PruebaContext())
                {
                    var query = context.Cines.FromSqlRaw($"CineGetById {idCine}").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        ML.CIne cine = new ML.CIne();
                        cine.IdCine = query.IdCine;
                        cine.Nombre = query.Nombre;
                        cine.Direccion = query.Direccion;
                        cine.Ventas = query.Ventas.Value;
                        cine.Zona = new ML.Zona();
                        cine.Zona.IdZona = query.IdZona.Value;
                        cine.Zona.Nombre = query.ZonaNombre;
                        result.Object = cine;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}