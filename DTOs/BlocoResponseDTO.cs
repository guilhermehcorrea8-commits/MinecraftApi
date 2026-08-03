using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_29_07_Mine.DTOs
{
    public class BlocoResponseDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

        public double Resistencia { get; set; }

        public bool Empilhavel { get; set; }

        public string? ImagemUrl { get; set; }
    }
}