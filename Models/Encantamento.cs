using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Web_Api_29_07_Mine.Models
{
    public class Encantamento
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        public int NivelMaximo { get; set; }

        public string Categoria { get; set; } = string.Empty;

        public string? Descricao { get; set; }
    }
}