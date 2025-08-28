using itssip_general.DataAccess.Legal;

namespace itssip_general.DataAccess
{
    /// <summary>
    /// Clase factory para el acceso a datos.
    /// </summary>
    public sealed class DataAccessFactory
    {
        /// <summary>
        /// Instancia única de la clase.
        /// </summary>
        private static DataAccessFactory instance;

        /// <summary>
        /// Constructor privado de la clase.
        /// </summary>
        private DataAccessFactory()
        {
        }

        /// <summary>
        /// Devuelve la instancia única de la clase <see cref="DataAccessFactory"/>.
        /// </summary>
        public static DataAccessFactory Instance => instance ??= new DataAccessFactory();



        /// <summary>
        /// Obtiene una instancia de LegalDao <see cref="GeneralDao"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos. El valor puede ser null.</param>
        /// <returns>Instancia de la clase.</returns>
        public GeneralDao GetNewGeneralDao(string? connectionString = null)
        {
            return new GeneralDao(connectionString);
        }

        public ArticuloDao GetNewArticuloDao(string? connectionString = null)
        {
            return new ArticuloDao(connectionString);
        }

        public TiendaDao GetNewTiendaDao(string? connectionString = null)
        {
            return new TiendaDao(connectionString);
        }

    }
}
