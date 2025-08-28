using itssip_general.Dto;
using itssip_general.Dto.Common;
using itssip_general.Logic.Legal;

namespace itssip_general.Logic
{
    /// <summary>
    /// Clase factory de lógica de la aplicación.
    /// </summary>
    public sealed class LogicFactory
    {
        /// <summary>
        /// Instancia única de la clase.
        /// </summary>
        private static LogicFactory instance;

        /// <summary>
        /// Constructor privado de la clase.
        /// </summary>
        private LogicFactory()
        {
        }

        /// <summary>
        /// Devuelve la instancia única de la clase <see cref="LogicFactory"/>.
        /// </summary>
        public static LogicFactory Instance => instance ??= new LogicFactory();

        /// <summary>
        /// Obtiene una instancia de LegalLogic <see cref="GeneralLogic"/>.
        /// </summary>
        /// <param name="appSettingsDto">Información de la configuración de la aplicación. El valor puede ser null.</param>
        /// <returns>Instancia de la clase.</returns>
        public GeneralLogic GetNewGeneralLogic(AppSettingsDto? appSettingsDto = null)
        {
            return new GeneralLogic(appSettingsDto);
        }

        /// <summary>
        /// Obtiene una instancia de HelpersCommon <see cref="HelpersCommon"/>.
        /// </summary>
        /// <param name="appSettingsDto">Información de la configuración de la aplicación. El valor puede ser null.</param>
        /// <returns>Instancia de la clase.</returns>
        public HelpersCommon GetNewHelperLogic(AppSettingsDto? appSettingsDto = null)
        {
            return new HelpersCommon(appSettingsDto);
        }

        public ArticuloLogic GetNewArticuloLogic(AppSettingsDto? appSettingsDto = null)
        {
            return new ArticuloLogic(appSettingsDto);
        }
        public TiendaLogic GetNewTiendaLogic(AppSettingsDto? appSettingsDto = null)
        {
            return new TiendaLogic(appSettingsDto);
        }
    }
}

