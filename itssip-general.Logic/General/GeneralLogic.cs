using itssip_general.Dto.Common;
using itssip_general.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using itssip_general.DataAccess.Legal;
using itssip_general.DataAccess;
using System.Reflection;
using System.Text.Json;
using System.Xml;
using System.Transactions;

namespace itssip_general.Logic.Legal
{
    public class GeneralLogic
    {
        /// <summary>
        /// Encapsula la configuración de la aplicación/api.
        /// </summary>
        private readonly AppSettingsDto appSettingsDto;

        private readonly GeneralDao generalDao;


        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="appSettingsDto">Congfiguración de la aplicación/api.</param>
        public GeneralLogic(AppSettingsDto? appSettingsDto)
        {
            this.appSettingsDto = appSettingsDto;
            generalDao = DataAccessFactory.Instance.GetNewGeneralDao(this.appSettingsDto.SqlServerConn);
        }

        public ResponseDto GetClientes()
        {
            return generalDao.GetClientes();
        }

        public ResponseDto GetClienteById(int id)
        {
            return generalDao.GetClienteById(id);
        }

        public ResponseDto AddCliente(ClienteDto cliente)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response = generalDao.AddCliente(cliente);
            }
            catch (HttpRequestException ex)
            {

                ex.SaveLog();
               response.Message=ex.Message;
                response.Success = false;
            }
           
            return response;
        }


        public ResponseDto UpdateCliente(int id, ClienteDto cliente)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response = generalDao.UpdateCliente(id, cliente);
            }
            catch (HttpRequestException ex)
            {

                ex.SaveLog();
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }




        public ResponseDto DeleteCliente(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response = generalDao.DeleteCliente(id);
            }
            catch (HttpRequestException ex)
            {

                ex.SaveLog();
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }


        public ResponseDto BuyCarrito(List<CarritoItemDto> lstCarrito)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                using (TransactionLogic transaction = new TransactionLogic(IsolationLevel.ReadUncommitted))
                {
                    foreach (var objCarrito in lstCarrito)
                    {
                        response = generalDao.BuyCarrito(objCarrito);
                    }
                    if (!response.Success)
                    {
                        throw new Exception("Error al guardar");
                    }
                    transaction.Commit();
                }
                    
            }
            catch (Exception ex)
            {

                ex.SaveLog();
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }


    }
}
