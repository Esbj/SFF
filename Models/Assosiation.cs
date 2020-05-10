using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFF.Models
{
    public class Assosiation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; } = true;
    }
}