using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_29_07_Mine.DTOs
{
    public class MobResponseDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public bool Hostil { get; set; }

        public int Vida { get; set; }

        public string Drop { get; set; } = string.Empty;

        public string Bioma { get; set; } = string.Empty;

        public string? ImagemUrl { get; set; }
    }
}