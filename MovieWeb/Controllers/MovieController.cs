using Microsoft.AspNetCore.Mvc;
using MovieWeb.Domain;
using MovieWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MovieWeb.Database.Moviedatabase;

namespace MovieWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieDatabase _movieDatabase;

        public MovieController(IMovieDatabase movieDatabase)
        {
            _movieDatabase = movieDatabase;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> moviesFromDb = _movieDatabase.GetMovies();
            List<MovieListViewModel> movies = new List<MovieListViewModel>();
            foreach (Movie movie in moviesFromDb)
            {
                movies.Add(new MovieListViewModel() { Id = movie.Id, Title = movie.Title });
            }
            return View(movies);
        }
        public IActionResult Detail(int id)
        {
            Movie movieFromDb = _movieDatabase.GetMovie(id);
            MovieDetailViewModel movie = new MovieDetailViewModel()
            {
                Title = movieFromDb.Title,
                Description = movieFromDb.Description,
                ReleaseDate = movieFromDb.ReleaseDate,
                Genre = movieFromDb.Genre
            };
            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(MovieCreateViewModel movie)
        {
            Movie newMovie = new Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Genre = movie.Genre
            };

            _movieDatabase.Insert(newMovie);

            return RedirectToAction("Index");
        }

        //public IActionResult Detail()
        //{
        //    MovieDetailViewModel lionKing = new MovieDetailViewModel()
        //    {
        //        Title = "Lion King",
        //        Description ="Rare film",
        //        Genre = "disney"
        //    };
        //    return View(lionKing);
        //}

        //    [Route("movie")]
        //    public IActionResult Index()
        //    {
        //        var movies = new List<MovieListViewModel>();
        //        movies.Add(new MovieListViewModel { Title = "Lotr" });
        //        movies.Add(new MovieListViewModel { Title = "Hp" });
        //        movies.Add(new MovieListViewModel { Title = "Lotr2" });
        //        return View(movies);
        //    }
    }
}
