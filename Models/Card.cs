using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TCGInventory.Models
{
    public class Card
    {
        public int Id { get; set; } // PK
        [Display(Name = "Nombre")]
        public required string Name { get; set; } // Carta
        [Display(Name = "Rareza")]
        public required Rareza Rarity { get; set; } // Rareza (común, raro, épico, legendario, mitico)
        [Display(Name = "Ataque")]
        public int Attack { get; set; } // PA
        [Display(Name = "Defensa")]
        public int Defense { get; set; } // PD
        [Display(Name = "Imagen")]
        public string? ImageUrl { get; set; } // URL de la imagen de la carta (acepta null, por las dudas)
        [Display(Name = "Año Lanzamiento")]
        public int YearReleased { get; set; } // Año de lanzamiento de la carta
        [Display(Name = "Set")]
        public required string Set { get; set; } // Conjunto o Marca al que pertenece la carta
        [Display(Name = "Puntaje")]
        public required Puntaje Score{get; set;} // Puntaje de la carta carta
    }

    public enum Rareza
    {
        Comun,
        Raro,
        Épico,
        Legendario,
        Mítico
    }

    public enum Puntaje{
        Mint,
        NearMint,
        Excellent,
        Good,
        LightPlayed,
        Played,
        Poor 
    }

}