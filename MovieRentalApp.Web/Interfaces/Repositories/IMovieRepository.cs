using System.Collections.Generic;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        public void AddMovie(Movie movie);
        public void UpdateMovie(Movie movie);
        public void DeleteMovie(Movie movie);
        public IEnumerable<Movie> GetMovies();
    }
}
