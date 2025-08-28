using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itssip_general.Dto
{
    /// <summary>
    /// Modelo que encapsula la configuración de la aplicación.
    /// </summary>
    public record AppSettingsDto
    {
        /// <summary>
        /// Obtiene y/o establece la ruta de la Unidad de almacenamiento de archivos.
        /// </summary>
        public string PathFiles { get; init; }

        /// <summary>
        /// Obtiene y/o establece la cadena de conexión a la base de datos de SQL Server.
        /// </summary>
        public string SqlServerConn { get; init; }

        /// <summary>
        /// Obtiene y/o establece la clave de token de SingNow
        /// </summary>
        public string ApiTokenSingNow { get; init; }
    }
}
