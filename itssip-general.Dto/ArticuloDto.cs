using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace itssip_general.Dto
{
    public class ArticuloDto
    {
        public int IdArticulo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? UrlImagen { get; set; }
        public float Stock { get; set; }
        public string Nombre { get; set; }
        public int IdTienda { get; set; }
        public string? Sucursal { get; set; }

    }
}
