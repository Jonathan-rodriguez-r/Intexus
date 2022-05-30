using Intexus.DAL.Conexion;
using Intexus.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Intexus.Comun.Entities;

namespace Intexus.DAL.Afiliado
{
    public class DALCrudAfiliados
    {

        private string conexion;
        private string statementType;
        public DALCrudAfiliados(string connectionString)
        {
            conexion = connectionString;
        }
        public void InsertarAfiliado(Comun.Entities.Afiliado afiliado)
        {
            try
            {
        //Comentario prueba
        statementType = "Insert";
                ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
                List<Parameter> listaParametros = new List<Parameter>
                {
                    new Parameter { Nombre = "nombre", ValorEnviar = afiliado.Nombre, TipoDato = TipoDato.Varchar, Tamano = afiliado.Nombre.Length },
                    new Parameter { Nombre = "apellido", ValorEnviar = afiliado.Apellido, TipoDato = TipoDato.Varchar, Tamano = afiliado.Apellido.Length },
                    new Parameter { Nombre = "fechanacimiento", ValorEnviar = afiliado.FechaNacimiento.ToString(), TipoDato = TipoDato.Date, Tamano = afiliado.FechaNacimiento.ToString().Length },
                    new Parameter { Nombre = "sexo", ValorEnviar = afiliado.Sexo, TipoDato = TipoDato.Char, Tamano = afiliado.Sexo.ToString().Length }  ,
                    new Parameter { Nombre = "recaudo", ValorEnviar = afiliado.Recaudo.ToString(), TipoDato = TipoDato.Decimal, Tamano = afiliado.Recaudo.ToString().Length },
                    new Parameter { Nombre = "type", ValorEnviar =statementType, TipoDato = TipoDato.Varchar, Tamano = statementType.ToString().Length }

                };
                conexionBaseDatos.EjecutarProcedure(conexion, "sp_masterafiliado", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarAfiliado(Comun.Entities.Afiliado afiliado)
        {
            try
            {
                statementType = "Update";
                ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
                List<Parameter> listaParametros = new List<Parameter>
                {
                    new Parameter { Nombre = "id", ValorEnviar = afiliado.Id.ToString(), TipoDato = TipoDato.Integer, Tamano = afiliado.Id.ToString().Length },
                    new Parameter { Nombre = "nombre", ValorEnviar = afiliado.Nombre, TipoDato = TipoDato.Varchar, Tamano = afiliado.Nombre.Length },
                    new Parameter { Nombre = "apellido", ValorEnviar = afiliado.Apellido, TipoDato = TipoDato.Varchar, Tamano = afiliado.Apellido.Length },
                    new Parameter { Nombre = "fechanacimiento", ValorEnviar = afiliado.FechaNacimiento.ToString(), TipoDato = TipoDato.Date, Tamano = afiliado.FechaNacimiento.ToString().Length },
                    new Parameter { Nombre = "sexo", ValorEnviar = afiliado.Sexo, TipoDato = TipoDato.Char, Tamano = afiliado.Sexo.ToString().Length }  ,
                    new Parameter { Nombre = "recaudo", ValorEnviar = afiliado.Recaudo.ToString(), TipoDato = TipoDato.Decimal, Tamano = afiliado.Recaudo.ToString().Length },
                    new Parameter { Nombre = "type", ValorEnviar =statementType, TipoDato = TipoDato.Varchar, Tamano = statementType.ToString().Length }

                };
                conexionBaseDatos.EjecutarProcedure(conexion, "sp_masterafiliado", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Comun.Entities.Afiliado> ObtenerAfiliados()
        {
            List<Comun.Entities.Afiliado> resultado = new List<Comun.Entities.Afiliado>();
            try
            {
            
                statementType = "Select";
                ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
                List<Parameter> listaParametros = new List<Parameter>
                {
                    new Parameter { Nombre = "type", ValorEnviar =statementType, TipoDato = TipoDato.Varchar, Tamano = statementType.ToString().Length }

                };
                DataSet dtResult = conexionBaseDatos.EjecutarProcedure(conexion, "sp_masterafiliado", listaParametros);
                if (dtResult != null && dtResult.Tables.Count > 0)
                {

                    using (DataTable dt = dtResult.Tables[0])
                    {
                        if (dtResult.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow item in dt.Rows)
                            {
                                DateTime fechaNacimiento = new DateTime();
                                if (!Convert.IsDBNull(item["FECHA_NACIMIENTO"]))
                                    fechaNacimiento = Convert.ToDateTime(item["FECHA_NACIMIENTO"].ToString());
                                resultado.Add(new Comun.Entities.Afiliado
                                {
                                    Id = Convert.ToInt32(item["ID"]),
                                    Nombre = item["NOMBRE"].ToString(),
                                    Apellido = item["APELLIDO"].ToString(),
                                    FechaNacimiento = fechaNacimiento,
                                    Sexo = item["SEXO"].ToString(),
                                    Recaudo = Convert.ToDecimal(item["RECAUDO"].ToString())
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public void EliminarAfiliados(int id)
        {
            try
            {
                statementType = "Delete";
                ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
                List<Parameter> listaParametros = new List<Parameter>
                {
                    new Parameter { Nombre = "id", ValorEnviar = id.ToString(), TipoDato = TipoDato.Integer, Tamano = id.ToString().Length },
                    new Parameter { Nombre = "type", ValorEnviar =statementType, TipoDato = TipoDato.Varchar, Tamano = statementType.ToString().Length }

                };
                conexionBaseDatos.EjecutarProcedure(conexion, "sp_masterafiliado", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
