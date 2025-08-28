using itssip_general.DataAccess.SqlServer.Common;
using itssip_general.Dto;
using itssip_general.Dto.Common;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;


namespace itssip_general.DataAccess.SqlServer.Legal
{
    public abstract class GeneralSqlServerDao : SqlServerDataBaseConnection
    {
        /// <summary>
        /// Constructor protected de la clase que inicializa la cadena de conexión a la base de datos.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión de la base de datos. El valor puede ser null.</param>
        protected GeneralSqlServerDao(string? connectionString) : base(connectionString)
        {
        }

        public ResponseDto GetClientes()
        {
            ResponseDto response=new ResponseDto();
            SqlDataReader reader=null;
            try
            {
                reader = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.StoredProcedure, "GetClientes", null);
                ;
                if (reader != null)
                {
                    response.Success = true;
                    response.Generic = Mapper.MapperReader.CreateList<ClienteDto>(reader);
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

        public ResponseDto GetClienteById(int id)
        {
            ResponseDto response = new ResponseDto();
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.StoredProcedure, "GetClientesById", new List<SqlParameter>
                {
                   new SqlParameter("@IdCliente", SqlDbType.Int) { Value = id == 0 ? (object)DBNull.Value : id }
                }.ToArray());
                ;
                if (reader != null)
                {
                    response.Success = true;
                    response.Generic = Mapper.MapperReader.CreateObject<ClienteDto>(reader);
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

        public ResponseDto AddCliente(ClienteDto cliente)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                int id = 0;
                object identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.StoredProcedure, "AddCliente", new List<SqlParameter>
                {
                   new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = cliente.Nombre == "" ? (object)DBNull.Value : cliente.Nombre},
                   new SqlParameter("@Apellidos", SqlDbType.VarChar) { Value = cliente.Apellidos == "" ? (object)DBNull.Value : cliente.Apellidos },
                   new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = cliente.Direccion == "" ? (object)DBNull.Value : cliente.Direccion }
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


        public ResponseDto UpdateCliente(int idCliente, ClienteDto cliente)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                int id = 0;
                object identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.StoredProcedure, "UpdateCliente", new List<SqlParameter>
                {

                   new SqlParameter("@IdCliente", SqlDbType.Int) { Value = idCliente == 0 ? (object)DBNull.Value : idCliente},
                   new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = cliente.Nombre == "" ? (object)DBNull.Value : cliente.Nombre},
                   new SqlParameter("@Apellidos", SqlDbType.VarChar) { Value = cliente.Apellidos == "" ? (object)DBNull.Value : cliente.Apellidos },
                   new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = cliente.Direccion == "" ? (object)DBNull.Value : cliente.Direccion }
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



        public ResponseDto DeleteCliente(int idCliente)
        {
            ResponseDto response = new ResponseDto();

            try
            {
                int id = 0;

                object identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.StoredProcedure, "DeleteCliente", new List<SqlParameter>
                {

                   new SqlParameter("@IdCliente", SqlDbType.Int) { Value = idCliente == 0 ? (object)DBNull.Value : idCliente}
                   
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


        public ResponseDto BuyCarrito(CarritoItemDto carrito)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                int id = 0;
                object identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.StoredProcedure, "BuyCarrito", new List<SqlParameter>
                {
                   new SqlParameter("@IdArticulo", SqlDbType.Int) { Value = carrito.articulo.IdArticulo == 0 ? (object)DBNull.Value : carrito.articulo.IdArticulo},
                   new SqlParameter("@Cantidad", SqlDbType.Decimal) { Value = carrito.cantidad == 0 ? (object)DBNull.Value : carrito.cantidad }
                   
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
