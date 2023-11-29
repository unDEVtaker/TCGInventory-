using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCGInventory.ViewModels
{
    public class CardExpansionVM
    {
        public int Id { get; set; } // PK
        [Display(Name = "Nombre")]
        public required string Name { get; set; } // Carta
        [Display(Name = "Compañía")]
        public required string Company { get; set; } // Carta
        [Display(Name = "Imagen")]
        public string? ImageUrl { get; set; } // URL de la imagen de la carta (acepta null, por las dudas)'
    }
}