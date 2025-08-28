using itssip_general.DataAccess.SqlServer.Legal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itssip_general.DataAccess.Legal
{
    public class TiendaDao : TiendaSqlServerDao
    {
        /// <summary>
        /// Constructor interno de la clase que inicializa la cadena de conexión a la base de datos.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión de la base de datos. El valor puede ser null.</param>
        internal TiendaDao(string? connectionString) : base(connectionString)
        {
        }
    }
}