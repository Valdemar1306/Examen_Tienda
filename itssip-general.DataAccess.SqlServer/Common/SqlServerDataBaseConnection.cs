using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itssip_general.DataAccess.SqlServer.Common
{
    /// <summary>
    /// Clase para las operaciones de conexión con SqlServer.
    /// </summary>
    public abstract class SqlServerDataBaseConnection
    {
        /// <summary>
        /// Cadena de conexión a base de datos.
        /// </summary>
        protected readonly string ConnectionString;

        /// <summary>
        /// Constructor de la clase que inicializa la cadena de conexión.
        /// </summary>
        protected SqlServerDataBaseConnection(string? connectionString)
        {
            this.ConnectionString = string.IsNullOrEmpty(connectionString) ? ConnectionConfig.Instance.GetConnectionString() : connectionString;
        }
    }
}
