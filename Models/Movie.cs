using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFF.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int MaxRentals { get; set; }
        public bool IsDigital { get; set; }
    }
}
