using Intexus.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Intexus.DAL.Conexion
{
   public class ConexionBaseDatos
    {
        public DataSet EjecutarProcedure(string conexionBD, string nombreSP, List<Parameter> parametros)
        {
      //Comentario prueba
      DataSet result = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                SqlCommand objCommand = ObtenerParametros(nombreSP, parametros);
                objCommand.Connection = new SqlConnection(conexionBD);
                objCommand.CommandTimeout = 60;
                objCommand.Connection.Open();
                try
                {
                    adapter = new SqlDataAdapter(objCommand);
                    adapter.Fill(result, "Result");
                    objCommand.Connection.Close();
                    objCommand.Parameters.Clear();
                }
                finally
                {
                    if (adapter != null)
                    {
                        adapter.Dispose();
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                 throw ex;
            }
            finally
            {
                result.Dispose();
            }
        }

        public SqlCommand ObtenerParametros(string nombreSP, List<Parameter> parametros)
        {
            try
            {
                SqlCommand command = new SqlCommand(nombreSP);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var param in parametros)
                {
          //Comentario prueba
          command.Parameters.Add("@" + param.Nombre, this.ConvertirDato(param.TipoDato), param.Tamano);
                    if (string.IsNullOrEmpty(param.ValorEnviar))
                        command.Parameters["@" + param.Nombre].Value = param.Byte;
                    else
                        command.Parameters["@" + param.Nombre].Value = param.ValorEnviar;

                }

                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    //Comentario prueba

    private SqlDbType ConvertirDato(TipoDato tipoDato)
        {
            switch (tipoDato)
            {
                case TipoDato.Decimal:
                    return SqlDbType.Decimal;
                case TipoDato.Char:
                    return SqlDbType.Char;              
                case TipoDato.Integer:
                    return SqlDbType.Int;
                case TipoDato.Date:
                    return SqlDbType.Date;
                case TipoDato.Boolean:
                    return SqlDbType.Bit;
                case TipoDato.Varchar:
                    return SqlDbType.VarChar;
                case TipoDato.Double:
                    return SqlDbType.Float;
                default:
                    return SqlDbType.VarBinary;
            }
        }
    }
}
