using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_29_07_Mine.Models;

namespace Web_Api_29_07_Mine.Models
{
    public class Inventario
    {
        public int PlayerId { get; set; }

        public Player? Player { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public int Quantidade { get; set; }
    }
}