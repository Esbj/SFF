using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFF.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public int Score { get; set; }
        public string Trivia { get; set; }
    }
}
