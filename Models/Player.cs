using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_29_07_Mine.Models;

using System.ComponentModel.DataAnnotations;

namespace Web_Api_29_07_Mine.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nickname { get; set; } = string.Empty;

        [Range(1, 1000)]
        public int Nivel { get; set; }

        public string? Uuid { get; set; }

        public string? SkinUrl { get; set; }

        public int MundoId { get; set; }

        public Mundo? Mundo { get; set; }

        public ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
    }
}