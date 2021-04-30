using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspiApiShop.Models
{
    public class DetailsViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long NbElem { get; set; }
        public int DeliveryDays { get; set; }
        public decimal SellingPrice { get; set; }
    }
}