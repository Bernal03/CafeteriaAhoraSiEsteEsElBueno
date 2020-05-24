using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CafeteriaAhoraSiEsteEsElBueno.Models
{
    public class Pedid
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}