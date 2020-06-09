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
            if (!TryValidateModel(movie))
            {
                return View(movie);
            }
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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie movieFromDb = _movieDatabase.GetMovie((int)id);

            MovieEditViewModel movie = new MovieEditViewModel()
            {
                Title = movieFromDb.Title,
                Genre = movieFromDb.Genre,
                Description = movieFromDb.Description,
                ReleaseDate = movieFromDb.ReleaseDate
            };

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieEditViewModel movie)
        {
            if (!TryValidateModel(movie))
            {
                return View(movie);
            }

            _movieDatabase.Update(id, new Movie()
            {
                Title = movie.Title,
                Genre = movie.Genre,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate
            });

            return RedirectToAction("Detail", new { Id = id });

        }

        public IActionResult Delete(int id)
        {
            Movie movieFromDb = _movieDatabase.GetMovie(id);

            MovieDeleteViewModel movie = new MovieDeleteViewModel()
            {
                Id = movieFromDb.Id,
                Title = movieFromDb.Title,
            };

            return View(movie);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            _movieDatabase.Delete(id);

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
