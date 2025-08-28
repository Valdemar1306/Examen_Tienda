using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itssip_general.Dto.Common
{
    public class HelpersCommon
    {
            /// <summary>
            /// Encapsula la configuración de la aplicación/api.
            /// </summary>
            private readonly AppSettingsDto appSettingsDto;


            /// <summary>
            /// Constructor de la clase.
            /// </summary>
            /// <param name="appSettingsDto">Congfiguración de la aplicación/api.</param>
            public HelpersCommon(AppSettingsDto? appSettingsDto)
            {
                this.appSettingsDto = appSettingsDto;
            }
    }
}
