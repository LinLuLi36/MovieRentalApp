using System.Linq;
using MovieRentalApp.Web.Interfaces.Repositories;
using MovieRentalApp.Web.Interfaces.Services;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        private Movie GetMovieByMovieId(int movieId)
        {
            return _movieRepository.GetMovies().FirstOrDefault(m => m.MovieId == movieId);
        }

        public MovieType? GetMovieTypeByMovieId(int movieId)
        {
            return GetMovieByMovieId(movieId)?.Type;
        }

        public string GetMovieTitleByMovieId(int movieId)
        {
            return GetMovieByMovieId(movieId)?.Title;
        }
    }
}