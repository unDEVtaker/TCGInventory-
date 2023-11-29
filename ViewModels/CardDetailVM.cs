using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCGInventory.Models;

namespace TCGInventory.ViewModels
{
    public class CardDetailVM
    {
        public List<CardVM> Cards { get; set; } = new List<CardVM>();
        public string? Filter { get; set; }
    
    }
}