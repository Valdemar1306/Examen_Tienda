using itssip_general.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace itssip_general_API.WebApi.Controllers.Base
{
    /// <summary>
    /// Controlador base.
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Modelo que encapsula la información de configuración del sitio.
        /// </summary>
        private AppSettingsDto? _appSettingsDto = null;

        /// <summary>
        /// Modelo que encapsula la información de configuración del sitio.
        /// </summary>
        protected readonly AppSettingsDto appSettingsModel;


        /// <summary>
        /// Modelo que encapsula la información de configuración del sitio.
        /// </summary>
        protected AppSettingsDto appSettingsDto
        {
            get
            {
                this._appSettingsDto = new AppSettingsDto();
                return this._appSettingsDto with
                {
                    SqlServerConn = this.appSettingsModel.SqlServerConn,
                    PathFiles = this.appSettingsModel.PathFiles,
                };
            }
        }

        /// <summary>
        /// Contructor de la controller que inicializa los settings del sitio.
        /// </summary>
        /// <param name="AppSettingsDto">Settings del sitio.</param>
        public BaseController(IOptions<AppSettingsDto> appSettingsModel)
        {
            this.appSettingsModel = appSettingsModel.Value;
        }

        protected string GetCurrentToken()
        {
            // Obtener el token desde el encabezado "TokenApp"
            string token = Request.Headers["TokenApp"];

            // Verificar si se encontró el token y devolverlo si existe
            if (!string.IsNullOrEmpty(token))
            {
                return token;
            }

            // Si no se encuentra el token, retornar una cadena vacía
            return string.Empty;
        }
    }
}