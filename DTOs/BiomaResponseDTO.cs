using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_29_07_Mine.DTOs
{
    public class BiomaResponseDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public double Temperatura { get; set; }

        public bool Chove { get; set; }

        public string? ImagemUrl { get; set; }
    }
}