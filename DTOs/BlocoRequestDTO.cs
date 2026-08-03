using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Web_Api_29_07_Mine.DTOs
{
    public class BlocoRequestDTO
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

        public double Resistencia { get; set; }

        public bool Empilhavel { get; set; }

        public string? ImagemUrl { get; set; }
    }
}