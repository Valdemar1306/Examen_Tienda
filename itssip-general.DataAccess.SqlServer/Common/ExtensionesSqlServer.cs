using itssip_general.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itssip_general.DataAccess.SqlServer.Common
{
    // <summary>
    /// Clase para las operaciones de extensiones.
    /// </summary>
    public static class ExtensionesSqlServer
    {
        /// <summary>
        /// Guarda un log a partir de una exception de SqlServer.
        /// </summary>
        /// <param name="ex">Exeption de SqlServer.</param>
        public static void SaveLog(this SqlException ex)
        {
            ExtensionesCommon.SaveLog(ex);
        }

        /// <summary>
        /// Guarda un log a partir de una exception general.
        /// </summary>
        /// <param name="ex">Exeption general.</param>
        public static void SaveLog(this Exception ex)
        {
            ExtensionesCommon.SaveLog(ex);
        }
    }
}
