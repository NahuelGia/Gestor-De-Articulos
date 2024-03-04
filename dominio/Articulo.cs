using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {

        private decimal precio;
        public int Id { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public string Nombre { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public Marca Marca { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        public string UrlImagen { get; set; }

        public decimal Precio 
        {
            get { return precio; }
            set { precio = Math.Round(value, 2); }
        }

    }



}
