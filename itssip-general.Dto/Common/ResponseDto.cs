using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itssip_general.Dto.Common
{
    /// <summary>
    /// Modelo que encapsula la información de respuestas en peticiones.
    /// </summary>
    public class ResponseDto
    {
        /// <summary>
        /// Identificador general numérico.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador general numérico long.
        /// </summary>
        public long IdLong { get; set; }

        /// <summary>
        /// Identificador general string.
        /// </summary>
        public string IdString { get; set; }

        /// <summary>
        /// Indica si la respuesta es satisfactoria (true) o no (false).
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Descripción de un mensaje.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Código de respuesta.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Indica si la respuesta contiene un código.
        /// </summary>
        public bool HasCode { get; set; }

        /// <summary>
        /// Indica si el mensaje es error.
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Almacena información genérica.
        /// </summary>
        public object Generic { get; set; }
    }
}
