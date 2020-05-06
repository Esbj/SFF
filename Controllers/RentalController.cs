using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using SFF.Models;
using Microsoft.EntityFrameworkCore;

namespace SFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly SFFContext _context;
        public RentalController(SFFContext context)
        {
            _context = context;
        }
        //Create a rental
        [HttpPost]
        public void NewRental(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
        }
        //Sätt en film till utlålad
        [HttpPut]
        public async Task<ActionResult<IEnumerable<Rental>>> CreateInactiveRental(Rental rental)
        {
            var result = (from Rental in _context.Rentals
                            where rental == Rental
                            select Rental).FirstOrDefault();
            result.Rented = false;
            _context.SaveChanges();
            return await _context.Rentals.ToListAsync();
        }
    }
}