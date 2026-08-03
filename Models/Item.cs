using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_29_07_Mine.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

        public string? ImagemUrl { get; set; }

        public ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
    }
}