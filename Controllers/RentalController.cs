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
        //Skapa en utlåning
        [HttpPost]
        public void NewRental(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
        }
        //Sätt en film till återlämnad
        [HttpPut("return/{Id}")]
        public async Task<ActionResult<Rental>> ReturnRental(int id)
        {
            var result = await _context.Rentals.FindAsync(id);
            if (result == null)
                return NotFound();


            result.Rented = false;
            _context.SaveChanges();
            return result;
        }
    }
}