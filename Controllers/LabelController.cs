using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using SFF.Models;
using SQLitePCL;

namespace SFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly SFFContext _context;
        public LabelController (SFFContext context)
        {
            _context = context;
        }

        //Hämta XML data till posten
        [HttpGet ("{RentalId}")]
        [Produces("application/xml")]
        public async Task<ActionResult<Models.Label>> CreateLabel(int RentalId)
        {
            var rental = await _context.Rentals.FindAsync(RentalId);

            var movie = await (from Movie in _context.Movies
                               where rental.MovieId == Movie.Id
                               select Movie).ToListAsync();

            var assosiation = await (from Assos in _context.Assosiations
                                     where rental.AssosiationId == Assos.Id
                                     select Assos).ToListAsync();

            var adress = assosiation.FirstOrDefault();
            var title = movie.FirstOrDefault();

            Models.Label label = new Models.Label();

            label.Adress = adress.Location;
            label.Title = title.Title;
            label.Date = rental.Date;

            return label;
        }
    }
}