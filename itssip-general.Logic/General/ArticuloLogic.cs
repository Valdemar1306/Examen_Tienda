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
    public class ArticuloLogic
    {
        /// <summary>
        /// Encapsula la configuración de la aplicación/api.
        /// </summary>
        private readonly AppSettingsDto appSettingsDto;

        private readonly ArticuloDao articuloDao;


        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="appSettingsDto">Congfiguración de la aplicación/api.</param>
        public ArticuloLogic(AppSettingsDto? appSettingsDto)
        {
            this.appSettingsDto = appSettingsDto;
            articuloDao = DataAccessFactory.Instance.GetNewArticuloDao(this.appSettingsDto.SqlServerConn);
        }

        public ResponseDto GetArticulos()
        {
            return articuloDao.GetArticulos();
        }

        public ResponseDto GetArticuloById(int id)
        {
            return articuloDao.GetArticuloById(id);
        }

        public ResponseDto AddArticulo(ArticuloDto articulo)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response = articuloDao.AddArticulo(articulo);
            }
            catch (HttpRequestException ex)
            {

                ex.SaveLog();
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }


        public ResponseDto UpdateArticulo(int id, ArticuloDto articulo)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response = articuloDao.UpdateArticulo(id, articulo);
            }
            catch (HttpRequestException ex)
            {
            
                ex.SaveLog();
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }




        public ResponseDto DeleteArticulo(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response = articuloDao.DeleteArticulo(id);
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
