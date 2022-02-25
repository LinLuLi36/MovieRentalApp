using System;
using System.Collections.Generic;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Interfaces.Services
{
    public interface IMovieService
    {
        public MovieType? GetMovieTypeByMovieId(int movieId);
        public string GetMovieTitleByMovieId(int movieId);
    }
}