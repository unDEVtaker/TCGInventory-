using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCGInventory.Models;

namespace TCGInventory.ViewModels
{
    public class CardVM
    {
        public List<Card> Cards {get; set;} = new List<Card>();
        

    }
}