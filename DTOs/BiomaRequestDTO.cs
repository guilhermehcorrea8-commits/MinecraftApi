using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_29_07_Mine.DTOs
{
    public class BiomaRequestDTO
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        public double Temperatura { get; set; }

        public bool Chove { get; set; }

        public string? ImagemUrl { get; set; }
    }
}