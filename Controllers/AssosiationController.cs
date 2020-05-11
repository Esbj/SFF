using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SFF.Models;

namespace SFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AssosiationController : ControllerBase
    {
        private readonly SFFContext _context;
        public AssosiationController(SFFContext context)
        {
            _context = context;
        }
        
        //Lägg till en filmstudio
        [HttpPost]
        public void AddAssisiation(Assosiation assosiation)
        {
            _context.Add(assosiation);
            _context.SaveChanges();
        }


        //hämta en filmstudio
        [HttpGet("{id}")]
        public async Task<ActionResult<Assosiation>> GetAssosiation (int id)
        {
            var assosiation = await _context.Assosiations.FindAsync(id);
            if (assosiation == null)
                return NotFound();

            return assosiation;
        }
        [HttpDelete("{id}")]
        public void DeleteAssosiation(int id)
        {

        }
        
        //Ta bort en filmstudio (gör den till inaktiv för att inte förstöra kopplingar)
        [HttpPut("remove/{id}")]
        public async Task<ActionResult<Assosiation>> DeActivateAssiosiation(int id)
        {
            var toRemove = await _context.Assosiations.FindAsync(id);

            toRemove.IsActive = false;
            _context.SaveChanges();
            return toRemove;

        }
        //updatera informationen om en filmstudio
        [HttpPut("update/{id}")]
        public async Task<ActionResult<Assosiation>> UppdateAsosiation(Assosiation assosiation, int id)
        {
            var toUpdate = await _context.Assosiations.FindAsync(id);
            
            if (toUpdate.Id != id)
                return StatusCode(500);

            toUpdate.Location = assosiation.Location;
            toUpdate.Name = assosiation.Name;
            await _context.SaveChangesAsync();
            return toUpdate;
        }

        [HttpGet ("rented/{id}") ]
        //Visa lånade filmer av filmstudion 
        public async Task<ActionResult<IEnumerable<Movie>>> FindBorrowedMovies(int id)
        {
            //Hitta filmklubben det gäller
            var assosiation = await _context.Assosiations.FindAsync(id);
            //hämta uthyrningarna
            var rentals = await (from Rentals in _context.Rentals
                                  where assosiation.Id == Rentals.AssosiationId && Rentals.Rented == true
                                  select Rentals).ToListAsync();



            //sortera ut filmerna som har rätt Id och stoppa i resultatet
            var borrowedMovies = new List<Movie>();
            foreach(var Rental in rentals)
            {
                var movie = _context.Movies.Where(m => m.Id == Rental.MovieId).First();
                borrowedMovies.Add(movie);
            }

            return borrowedMovies;
        }
    }
}