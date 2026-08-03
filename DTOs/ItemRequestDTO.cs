using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Web_Api_29_07_Mine.DTOs
{
    public class ItemRequestDTO
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Tipo { get; set; } = string.Empty;

        public string? ImagemUrl { get; set; }
    }
}