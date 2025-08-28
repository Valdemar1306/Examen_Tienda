using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace itssip_general.DataAccess.SqlServer.Common
{
    internal sealed class ConnectionConfig
    {
        /// <summary>
        /// Instancia única de la clase.
        /// </summary>
        private static ConnectionConfig instance;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        private ConnectionConfig()
        {
        }

        /// <summary>
        /// Instancia única de la clase <see cref="ConnectionConfig"/>.
        /// </summary>
        public static ConnectionConfig Instance => instance ??= new ConnectionConfig();

        /// <summary>
        /// Obtiene la cadena de conexión a la base de datos.
        /// </summary>
        /// <returns>Cadena de conexión a la base de datos.</returns>
        public string GetConnectionString()
        {
            var varConnectionString = ConfigurationManager.ConnectionStrings["ConexionSqlServer"];
            if (varConnectionString != null)
            {
                return varConnectionString.ToString();
            }

            return string.Empty;
        }
    }
}