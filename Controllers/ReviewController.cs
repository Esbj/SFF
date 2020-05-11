using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFF.Models;

namespace SFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly SFFContext _context;
        public ReviewController(SFFContext context)
        {
            _context = context;
        }
        [HttpGet]
        //hämta alla trivias
        public async Task<IEnumerable<Review>> GetReviews()
        {
            var reviews = await _context.Reviews.ToListAsync();
            return reviews;
        }

        [HttpPost("add")]
        //Lägg till en reivew
        public void AddReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
        [HttpPut("removeTrivia/{id}")]
        //ta bort en trivia
        //nullar endast trivia istället för hela obj för att kunna fortf räkna ut medelbetyg
        public async Task<ActionResult<Review>> RemoveReview(int id)
        {
            var toRemove = await _context.Reviews.FindAsync(id);

            toRemove.Trivia = null;
            await _context.SaveChangesAsync();
            return toRemove;
        }
    }
}