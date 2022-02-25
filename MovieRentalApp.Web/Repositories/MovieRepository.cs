using System.Collections.Generic;
using MovieRentalApp.Web.DAL;
using MovieRentalApp.Web.Interfaces.Repositories;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Repositories
{
    public class MovieRepository: IMovieRepository
    {
        private readonly VideoShopContext _entities;

        public MovieRepository(VideoShopContext entities)
        {
            _entities = entities;
        }

        public void AddMovie(Movie movie)
        {
            _entities.Movies.Add(movie);
            _entities.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _entities.Movies.Update(movie);
            _entities.SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            _entities.Remove(movie);
            _entities.SaveChanges();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _entities.Movies;
        }
    }
}
