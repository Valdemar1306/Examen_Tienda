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
    public class TiendaLogic
    {
        /// <summary>
        /// Encapsula la configuración de la aplicación/api.
        /// </summary>
        private readonly AppSettingsDto appSettingsDto;

        private readonly TiendaDao tiendaDao;


        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="appSettingsDto">Congfiguración de la aplicación/api.</param>
        public TiendaLogic(AppSettingsDto? appSettingsDto)
        {
            this.appSettingsDto = appSettingsDto;
            tiendaDao = DataAccessFactory.Instance.GetNewTiendaDao(this.appSettingsDto.SqlServerConn);
        }

        public ResponseDto GetTiendas()
        {
            return tiendaDao.GetTiendas();
        }

        public ResponseDto GetTiendaById(int id)
        {
            return tiendaDao.GetTiendaById(id);
        }

        public ResponseDto AddTienda(TiendaDto tienda)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response = tiendaDao.AddTienda(tienda);
            }
            catch (HttpRequestException ex)
            {

                ex.SaveLog();
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }


        public ResponseDto UpdateTienda(int id, TiendaDto tienda)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response = tiendaDao.UpdateTienda(id, tienda);
            }
            catch (HttpRequestException ex)
            {

                ex.SaveLog();
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }




        public ResponseDto DeleteTienda(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response = tiendaDao.DeleteTienda(id);
            }
            catch (HttpRequestException ex)
            {

                ex.SaveLog();
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }


    }
}
