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
    }
}