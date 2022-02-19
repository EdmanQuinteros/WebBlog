using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCore.Models.ViewModels
{
    public class HomeVM
    {
        //IEnumerable significa o se usa porque llamaremos varios archivos//
        public IEnumerable<Slider> Slider { get; set; }
        public IEnumerable<Articulo> ListaArticulos { get; set; }
    }
}
