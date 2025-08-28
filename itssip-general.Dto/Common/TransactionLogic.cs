using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace itssip_general.Dto.Common
{
    public class TransactionLogic : IDisposable
    {
        /// <summary>
        /// Ambiente de transacción.
        /// </summary>
        private TransactionScope transactionScope;

        /// <summary>
        /// Crea una unidad de trabajo default.
        /// </summary>
        public TransactionLogic()
        {
            this.transactionScope = new TransactionScope();
        }

        /// <summary>
        /// Crea una unidad de trabajo a partir de un IsolationLevel.
        /// </summary>
        /// <param name="isolationLevel">Nivel de insolation.</param>
        public TransactionLogic(IsolationLevel isolationLevel)
        {
            TransactionOptions transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = isolationLevel;
            this.transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }

        /// <summary>
        /// Crea una unidad de trabajo a partir de un IsolationLevel y minutos para el timeout.
        /// </summary>
        /// <param name="isolationLevel">Nivel de insolation.</param>
        /// <param name="minutes">Minutos de timeout.</param>
        public TransactionLogic(IsolationLevel isolationLevel, short minutes)
        {
            TransactionOptions transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = isolationLevel;
            transactionOptions.Timeout = TimeSpan.FromMinutes(minutes > 20 ? 20 : minutes);
            this.transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }

        /// <summary>
        /// Crea una unidad de trabajo a partir de opciones de transacción.
        /// </summary>
        /// <param name="transactionOptions">Opciones de transacción.</param>
        public TransactionLogic(TransactionOptions transactionOptions)
        {
            if (transactionOptions == null)
            {
                transactionOptions = new TransactionOptions();
            }

            this.transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }

        /// <summary>
        /// Crea una unidad de trabajo a partir de opciones de ambiente de transacción transacción.
        /// </summary>
        /// <param name="transactionScopeOption">Opciones del ambiente de transacción.</param>
        public TransactionLogic(TransactionScopeOption transactionScopeOption)
        {
            this.transactionScope = new TransactionScope(transactionScopeOption);
        }

        /// <summary>
        /// Crea una unidad de trabajo a partir de opciones de ambiente de transacción y opciones de transacción.
        /// </summary>
        /// <param name="transactionScopeOption">Opciones del ambiente de transacción.</param>
        /// <param name="transactionOptions">Opciones de transacción.</param>
        public TransactionLogic(TransactionScopeOption transactionScopeOption, TransactionOptions transactionOptions)
        {
            if (transactionOptions == null)
            {
                transactionOptions = new TransactionOptions();
            }

            this.transactionScope = new TransactionScope(transactionScopeOption, transactionOptions);
        }

        /// <summary>
        /// Crea una unidad de trabajo a partir de opciones de ambiente de transacción y opciones de transacción.
        /// </summary>
        /// <param name="transactionScopeOption">Opciones del ambiente de transacción.</param>
        /// <param name="isolationLevel">>Nivel de insolation.</param>
        public TransactionLogic(TransactionScopeOption transactionScopeOption, IsolationLevel isolationLevel)
        {
            TransactionOptions transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = isolationLevel;
            this.transactionScope = new TransactionScope(transactionScopeOption, transactionOptions);
        }

        /// <summary>
        /// Crea una unidad de trabajo a partir de opciones de ambiente de transacción y opciones de transacción.
        /// </summary>
        /// <param name="transactionScopeOption">Opciones del ambiente de transacción.</param>
        /// <param name="isolationLevel">>Nivel de insolation.</param>
        /// <param name="minutes">Minutos de timeout.</param>
        public TransactionLogic(TransactionScopeOption transactionScopeOption, IsolationLevel isolationLevel, short minutes)
        {
            TransactionOptions transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = isolationLevel;
            transactionOptions.Timeout = TimeSpan.FromMinutes(minutes > 20 ? 20 : minutes);
            this.transactionScope = new TransactionScope(transactionScopeOption, transactionOptions);
        }

        /// <summary>
        /// Indica que finalizan correctamente todas las operaciones dentro del ámbito.
        /// </summary>
        public void Commit()
        {
            this.transactionScope.Complete();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                    if (this.transactionScope != null)
                    {
                        this.transactionScope.Dispose();
                    }
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        ~TransactionLogic()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(false);
        }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
