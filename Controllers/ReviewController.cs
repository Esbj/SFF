using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        //[HttpPost("{id}")]
        ////Lägg till en reivew
        //public void AddReview(Review review)
        //{
        //    _context.Reviews.Add(review);
        //    _context.SaveChanges();
        //}
        //public async Task<ActionResult<IEnumerable<Review>>> RemoveReview(int id)
        //{
        //    var toRemove = await _context.Reviews.FindAsync(id);

        //    toRemove.Trivia = null;
        //    _context.SaveChanges();
        //    return;
            
        //}
    }
}