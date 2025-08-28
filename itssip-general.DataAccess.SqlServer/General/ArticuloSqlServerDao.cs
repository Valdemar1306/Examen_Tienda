using itssip_general.DataAccess.SqlServer.Common;
using itssip_general.Dto;
using itssip_general.Dto.Common;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;


namespace itssip_general.DataAccess.SqlServer.Legal
{
    public abstract class ArticuloSqlServerDao : SqlServerDataBaseConnection
    {
        /// <summary>
        /// Constructor protected de la clase que inicializa la cadena de conexión a la base de datos.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión de la base de datos. El valor puede ser null.</param>
        protected ArticuloSqlServerDao(string? connectionString) : base(connectionString)
        {
        }

        public ResponseDto GetArticulos()
        {
            ResponseDto response = new ResponseDto();
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.StoredProcedure, "GetArticulo", null);
                ;
                if (reader != null)
                {
                    response.Success = true;
                    response.Generic = Mapper.MapperReader.CreateList<ArticuloDto>(reader);
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

        public ResponseDto GetArticuloById(int id)
        {
            ResponseDto response = new ResponseDto();
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.StoredProcedure, "GetArticuloById", new List<SqlParameter>
                {
                   new SqlParameter("@IdArticulo", SqlDbType.Int) { Value = id == 0 ? (object)DBNull.Value : id }
                }.ToArray());
                ;
                if (reader != null)
                {
                    response.Success = true;
                    response.Generic = Mapper.MapperReader.CreateObject<ArticuloDto>(reader);
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

        public ResponseDto AddArticulo(ArticuloDto articulo)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                int id = 0;
                object identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.StoredProcedure, "AddArticulo", new List<SqlParameter>
                {
                   new SqlParameter("@Codigo", SqlDbType.VarChar) { Value = articulo.Codigo == "" ? (object)DBNull.Value : articulo.Codigo},
                   new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = articulo.Descripcion == "" ? (object)DBNull.Value : articulo.Descripcion },
                   new SqlParameter("@Precio", SqlDbType.Decimal) { Value = articulo.Precio == 0 ? (object)DBNull.Value : articulo.Precio },
                   new SqlParameter("@Imagen", SqlDbType.VarChar) { Value = articulo.UrlImagen == "" ? (object)DBNull.Value : articulo.UrlImagen },
                   new SqlParameter("@Stock", SqlDbType.Decimal) { Value = articulo.Stock == 0 ? (object)DBNull.Value : articulo.Stock },
                   new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = articulo.Nombre == "" ? (object)DBNull.Value : articulo.Nombre},
                   new SqlParameter("@IdTienda", SqlDbType.Int) { Value = articulo.IdTienda == 0 ? (object)DBNull.Value : articulo.IdTienda}

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


        public ResponseDto UpdateArticulo(int idArticulo, ArticuloDto articulo)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                int id = 0;
                object identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.StoredProcedure, "UpdateArticulo", new List<SqlParameter>
                {

                   new SqlParameter("@IdArticulo", SqlDbType.Int) { Value = idArticulo == 0 ? (object)DBNull.Value : idArticulo},
                   new SqlParameter("@Codigo", SqlDbType.VarChar) { Value = articulo.Codigo == "" ? (object)DBNull.Value : articulo.Codigo},
                   new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = articulo.Descripcion == "" ? (object)DBNull.Value : articulo.Descripcion },
                   new SqlParameter("@Precio", SqlDbType.Decimal) { Value = articulo.Precio == 0 ? (object)DBNull.Value : articulo.Precio },
                   new SqlParameter("@Imagen", SqlDbType.VarChar) { Value = articulo.UrlImagen == "" ? (object)DBNull.Value : articulo.UrlImagen },
                   new SqlParameter("@Stock", SqlDbType.Decimal) { Value = articulo.Stock == 0 ? (object)DBNull.Value : articulo.Stock },
                   new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = articulo.Nombre == "" ? (object)DBNull.Value : articulo.Nombre},
                   new SqlParameter("@IdTienda", SqlDbType.Int) { Value = articulo.IdTienda == 0 ? (object)DBNull.Value : articulo.IdTienda}
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



        public ResponseDto DeleteArticulo(int idArticulo)
        {
            ResponseDto response = new ResponseDto();

            try
            {
                int id = 0;

                object identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.StoredProcedure, "DeleteArticulo", new List<SqlParameter>
                {

                   new SqlParameter("@idArticulo", SqlDbType.Int) { Value = idArticulo == 0 ? (object)DBNull.Value : idArticulo}

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
