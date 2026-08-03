using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_29_07_Mine.DTOs
{
    public class PlayerResponseDTO
    {
        public int Id { get; set; }

        public string Nickname { get; set; } = string.Empty;

        public int Nivel { get; set; }

        public string? Uuid { get; set; }

        public string? SkinUrl { get; set; }

        public string Mundo { get; set; } = string.Empty;
    }
}