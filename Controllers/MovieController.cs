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
        //Hämta alla filmer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }
        //Lägg till en film
        [HttpPost("add")]
        public Movie PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;

        }
        
        
        //Uppdatera max uthyrningar
        [HttpPut("update/{id}/{newRental}")]
        public async Task<ActionResult<Movie>> ChangeMaxRentals(int id, int newRental)
        {
            var result = await _context.Movies.FindAsync(id);

            result.MaxRentals = newRental;
            _context.SaveChanges();
            return result;
        }
    }
}