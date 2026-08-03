using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_29_07_Mine.Models;

using System.ComponentModel.DataAnnotations;

namespace Web_Api_29_07_Mine.Models
{
    public class Mundo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Bioma { get; set; } = string.Empty;

        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}