using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SFF.Models;
using Microsoft.EntityFrameworkCore;


namespace SFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly SFFContext _context;
        public MovieController(SFFContext context)
        {
            _context = context;
        }
        //GET: Hämta alla filmer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {

            return await _context.Movies.ToListAsync();
        }
        //Lägg till en film
        [HttpPost]
        public void PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        //Uppdatera en films 
        [HttpPut]
        //Uppdatera max uthyrningar
        public async Task<ActionResult<IEnumerable<Movie>>> ChangeMaxRentals(Movie movie, int NewRentLimit)
        {
            var result = (from Movie in _context.Movies
                            where movie.Id == Movie.Id
                            select movie).FirstOrDefault();

            result.MaxRentals = NewRentLimit;
            _context.SaveChanges(); 
            return await _context.Movies.ToListAsync();
        }
        
    }
}