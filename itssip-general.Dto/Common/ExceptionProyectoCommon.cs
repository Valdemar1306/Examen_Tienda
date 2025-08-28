using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace itssip_general.Dto.Common
{
        /// <summary>
        /// Clase personalizada de excepciones.
        /// </summary>
        public class ExceptionProyectoCommon : Exception
        {
            /// <summary>
            /// Información del error.
            /// </summary>
            public ResponseDto Response { get; set; }

            /// <summary>
            /// Constructor de la excepción.
            /// </summary>
            public ExceptionProyectoCommon()
            {

            }

            /// <summary>
            /// Constructor de la excepción.
            /// </summary>
            /// <param name="message">Mensaje de la excepción.</param>
            public ExceptionProyectoCommon(string message) : base(message)
            {

            }

            /// <summary>
            /// Constructor de la excepción.
            /// </summary>
            /// <param name="message">Mensaje de la excepción.</param>
            /// <param name="inner">Exception generada.</param>
            public ExceptionProyectoCommon(string message, Exception inner) : base(message, inner)
            {

            }

            /// <summary>
            /// Constructor de la excepción.
            /// </summary>
            /// <param name="message">Objeto con la información del mensaje de la excepción.</param>
            public ExceptionProyectoCommon(ResponseDto message) : base(message.Message)
            {
                this.Response = message;
            }

            /// <summary>
            /// Constructor de la excepción.
            /// </summary>
            /// <param name="message">Objeto con la información del mensaje de la excepción.</param>
            /// <param name="inner">Exception generada.</param>
            public ExceptionProyectoCommon(ResponseDto message, Exception inner) : base(message.Message, inner)
            {
                this.Response = message;
                inner?.SaveLog(inner.Message);
            }

            /// <summary>
            /// Constructor de la excepción.
            /// </summary>
            /// <param name="info">Información de serialización.</param>
            /// <param name="context">Contexto del streaming</param>
            protected ExceptionProyectoCommon(SerializationInfo info, StreamingContext context)
            {
            }
        }
    }
