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
        public MovieController(SFFContext context)
        {
            _context = context;
        }
        //Create a rental
        [HttpPost]
        public void NewRental()
        {
            
        }
    }
}