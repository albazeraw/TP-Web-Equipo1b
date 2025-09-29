using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class articulos
    {
        public int idArticulo { get; set; }
        [DisplayName("Código")]

        public string codigo { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Descripción")]

        public string descripcion { get; set; }
        [DisplayName("Precio")]
        public decimal precio { get; set; }
        [DisplayName("Marca")]
        public marcas marca { get; set; }
        [DisplayName("Categoría")]
        public categorias categoria { get; set; }
        public string imagenUrl { get; set; }

    }
}
