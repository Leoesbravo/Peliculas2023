using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PL.Models;
using System.Drawing.Drawing2D;

namespace PL.Controllers
{
    public class MovieController : Controller
    {
        public ActionResult Index(int? page)
        {
            Movie movie = new Movie();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.themoviedb.org/3/");
                page = page == null ? 1 : page;
                string url = "movie/popular?api_key=eb04040ca9589124d619ba905db90548&language=es-ES&page=" + page;
                var responseTask = client.GetAsync(url);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    dynamic resultJSON = JObject.Parse(readTask.Result);
                    readTask.Wait();
                    movie.Movies = new List<object>();
                    foreach (var resultItem in resultJSON.results)
                    {
                        Movie movieItem = new Movie();
                        movieItem.IdMovie = resultItem.id;
                        movieItem.Descripcion = resultItem.overview;
                        movieItem.Nombre = resultItem.title;
                        movieItem.Fecha = resultItem.release_date;
                        movieItem.Imagen = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2" + resultItem.poster_path;
                        movie.Movies.Add(movieItem);
                    }
                }
            }
            ViewBag.page = page;
            return View(movie);
        }
        public ActionResult AddFavorite(int idMovie)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.themoviedb.org/3/");
                var json = new
                {
                    media_type = "movie",
                    media_id = idMovie,
                    favorite = true
                };

                var postTask = client.PostAsJsonAsync("account/20522085/favorite?api_key=eb04040ca9589124d619ba905db90548&session_id=aaba7e8ce3beb79adae0a94f08f1d27b702eaf90", json);
                postTask.Wait();

                var resultMovie = postTask.Result;
                if (resultMovie.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Pelicula añadida a tus favoritos!";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al añadir la pelicula a tus favoritos";
                }
            }
            return RedirectToAction("Index", "Movie");
        }
        public ActionResult Favorites(int? page)
        {
            Movie movie = new Movie();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.themoviedb.org/3/");
                page = page == null ? 1 : page;
                string url = "account/20522085/favorite/movies?api_key=eb04040ca9589124d619ba905db90548&session_id=aaba7e8ce3beb79adae0a94f08f1d27b702eaf90&language=es-ES&page=" + page;

                var responseTask = client.GetAsync(url);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    dynamic resultJSON = JObject.Parse(readTask.Result.ToString());
                    readTask.Wait();
                    movie.Movies = new List<object>();
                    foreach (var resultItem in resultJSON.results)
                    {
                        Movie movieItem = new Movie();
                        movieItem.IdMovie = resultItem.id;
                        movieItem.Descripcion = resultItem.overview;
                        movieItem.Nombre = resultItem.title;
                        movieItem.Fecha = resultItem.release_date;
                        movieItem.Imagen = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2" + resultItem.poster_path;
                        movie.Movies.Add(movieItem);
                    }
                }
                ViewBag.page = page;
            }          
            return View(movie);
        }
    }
}
