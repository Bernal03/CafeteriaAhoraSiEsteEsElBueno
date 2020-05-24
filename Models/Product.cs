using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeteriaAhoraSiEsteEsElBueno.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
    }
}