using itssip_general.DataAccess.SqlServer.Common;
using itssip_general.Dto;
using itssip_general.Dto.Common;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;


namespace itssip_general.DataAccess.SqlServer.Legal
{
    public abstract class TiendaSqlServerDao : SqlServerDataBaseConnection
    {
        /// <summary>
        /// Constructor protected de la clase que inicializa la cadena de conexión a la base de datos.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión de la base de datos. El valor puede ser null.</param>
        protected TiendaSqlServerDao(string? connectionString) : base(connectionString)
        {
        }

        public ResponseDto GetTiendas()
        {
            ResponseDto response = new ResponseDto();
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.StoredProcedure, "GetTiendas", null);
                ;
                if (reader != null)
                {
                    response.Success = true;
                    response.Generic = Mapper.MapperReader.CreateList<TiendaDto>(reader);
                }


            }
            catch (Exception ex)
            {
                ex.SaveLog();
                response.Success = false;
                response.Message = ex.Message;
            }
            finally { reader?.Close(); }

            return response;
        }

        public ResponseDto GetTiendaById(int id)
        {
            ResponseDto response = new ResponseDto();
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.StoredProcedure, "GetTiendaById", new List<SqlParameter>
                {
                   new SqlParameter("@IdTienda", SqlDbType.Int) { Value = id == 0 ? (object)DBNull.Value : id }
                }.ToArray());
                ;
                if (reader != null)
                {
                    response.Success = true;
                    response.Generic = Mapper.MapperReader.CreateObject<TiendaDto>(reader);
                }


            }
            catch (Exception ex)
            {
                ex.SaveLog();
                response.Success = false;
                response.Message = ex.Message;
            }
            finally { reader?.Close(); }
            return response;
        }

        public ResponseDto AddTienda(TiendaDto tienda)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                int id = 0;
                object identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.StoredProcedure, "AddTienda", new List<SqlParameter>
                {
                   new SqlParameter("@Sucursal", SqlDbType.VarChar) { Value = tienda.Sucursal == "" ? (object)DBNull.Value : tienda.Sucursal},
                   new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = tienda.Direccion == "" ? (object)DBNull.Value : tienda.Direccion }
                   
                }.ToArray());
                if (identity != null)
                {
                    int.TryParse(identity.ToString(), out id);
                }

                response.Success = true;
                response.Id = id;
                return response;
            }
            catch (Exception ex)
            {
                ex.SaveLog();
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }


        public ResponseDto UpdateTienda(int idTienda, TiendaDto tienda)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                int id = 0;
                object identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.StoredProcedure, "UpdateTienda", new List<SqlParameter>
                {

                   new SqlParameter("@IdTienda", SqlDbType.Int) { Value = idTienda == 0 ? (object)DBNull.Value : idTienda},
                   new SqlParameter("@Sucursal", SqlDbType.VarChar) { Value = tienda.Sucursal == "" ? (object)DBNull.Value : tienda.Sucursal},
                   new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = tienda.Direccion == "" ? (object)DBNull.Value : tienda.Direccion }
                   
                }.ToArray());
                if (identity != null)
                {
                    int.TryParse(identity.ToString(), out id);
                }

                response.Success = true;
                response.Id = id;
                return response;
            }
            catch (Exception ex)
            {
                ex.SaveLog();
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }



        public ResponseDto DeleteTienda(int idTienda)
        {
            ResponseDto response = new ResponseDto();

            try
            {
                int id = 0;

                object identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.StoredProcedure, "DeleteTienda", new List<SqlParameter>
                {

                   new SqlParameter("@Idtienda", SqlDbType.Int) { Value = idTienda == 0 ? (object)DBNull.Value : idTienda}

                }.ToArray());
                if (identity != null)
                {
                    int.TryParse(identity.ToString(), out id);
                }

                response.Success = true;
                response.Id = id;
                return response;
            }
            catch (Exception ex)
            {
                ex.SaveLog();
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }


    }
}
