using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_29_07_Mine.DTOs
{
    public class PlayerRequestDTO
    {
        [Required(ErrorMessage = "O nickname é obrigatório.")]
        [StringLength(30)]
        public string Nickname { get; set; } = string.Empty;

        [Range(1, 1000)]
        public int Nivel { get; set; }

        [Required]
        public int MundoId { get; set; }
    }
}