using Intexus.Comun.Api;
using Intexus.Comun.Entities;
using Intexus.DAL.Afiliado;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intexus.PruebaTecnica.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly IConfiguration configuracion;
        public CrudController(IConfiguration configuration)
        {
            configuracion = configuration;
        }

        [HttpPut]
        [Route("InsertarAfiliadoPut")]
        public ApiResponse InsertarAfiliadoPut([FromBody] Afiliado afiliado)
        {
            try
            {
                DALCrudAfiliados dALCrudAfiliados = new DALCrudAfiliados(configuracion["ConexionSqlServer"]);
                dALCrudAfiliados.InsertarAfiliado(afiliado);
                return new ApiResponse { Respuesta = ApiStatus.OK, Mensaje = "Afiliado creado correctamente." };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Respuesta = ApiStatus.Error, Mensaje = $"El Afiliado no fue creado correctamente error: {ex.Message}." };

            }
        }



        [HttpPost]
        [Route("InsertarAfiliado")]
        public ApiResponse InsertarAfiliado([FromBody] Afiliado afiliado)
        {
            try
            {
                DALCrudAfiliados dALCrudAfiliados = new DALCrudAfiliados(configuracion["ConexionSqlServer"]);
                dALCrudAfiliados.InsertarAfiliado(afiliado);
                return new ApiResponse { Respuesta = ApiStatus.OK, Mensaje = "Afiliado creado correctamente." };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Respuesta = ApiStatus.Error, Mensaje = $"El Afiliado no fue creado correctamente error: {ex.Message}." };

            }
        }

        [HttpPut]
        [Route("ActualizarAfiliadoPut")]
        public ApiResponse ActualizarAfiliadoPut([FromBody] Afiliado afiliado)
        {
            try
            {
                DALCrudAfiliados dALCrudAfiliados = new DALCrudAfiliados(configuracion["ConexionSqlServer"]);
                dALCrudAfiliados.ActualizarAfiliado(afiliado);
                return new ApiResponse { Respuesta = ApiStatus.OK, Mensaje = "Afiliado creado correctamente." };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Respuesta = ApiStatus.Error, Mensaje = $"El Afiliado no se pudo actualizar correctamente error: {ex.Message}." };

            }
        }

        [HttpPost]
        [Route("ActualizarAfiliado")]
        public ApiResponse ActualizarAfiliado([FromBody] Afiliado afiliado)
        {
            try
            {
                DALCrudAfiliados dALCrudAfiliados = new DALCrudAfiliados(configuracion["ConexionSqlServer"]);
                dALCrudAfiliados.ActualizarAfiliado(afiliado);
                return new ApiResponse { Respuesta = ApiStatus.OK, Mensaje = "Afiliado creado correctamente." };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Respuesta = ApiStatus.Error, Mensaje = $"El Afiliado no se pudo actualizar correctamente error: {ex.Message}." };

            }
        }

        [HttpGet]
        public ApiResponse ListarAfiliadosGet()
        {
            try
            {
                DALCrudAfiliados dALCrudAfiliados = new DALCrudAfiliados(configuracion["ConexionSqlServer"]);
                List<Afiliado> listAfiliado = dALCrudAfiliados.ObtenerAfiliados();
                if (listAfiliado.Any())
                    return new ApiResponse { Respuesta = ApiStatus.OK, Mensaje = "Lista de afiliados", ResponseParams = listAfiliado };
                else
                    return new ApiResponse { Respuesta = ApiStatus.OK, Mensaje = "Lista de afiliados vacia." };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Respuesta = ApiStatus.Error, Mensaje = $"Error al Listar los afiliados error: {ex.Message}." };

            }
        }

        [HttpPost]
        [Route("ListarAfiliados")]
        public ApiResponse ListarAfiliados()
        {
            try
            {
                DALCrudAfiliados dALCrudAfiliados = new DALCrudAfiliados(configuracion["ConexionSqlServer"]);
                List<Afiliado> listAfiliado = dALCrudAfiliados.ObtenerAfiliados();
                if (listAfiliado.Any())
                    return new ApiResponse { Respuesta = ApiStatus.OK, Mensaje = "Lista de afiliados", ResponseParams = listAfiliado };
                else
                    return new ApiResponse { Respuesta = ApiStatus.OK, Mensaje = "Lista de afiliados vacia." };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Respuesta = ApiStatus.Error, Mensaje = $"Error al Listar los afiliados error: {ex.Message}." };

            }
        }

        [HttpDelete]
        [Route("EliminarAfiliadoDelete")]
        public ApiResponse EliminarAfiliadoDelete([FromBody] int idAfiliado)
        {
            try
            {
                DALCrudAfiliados dALCrudAfiliados = new DALCrudAfiliados(configuracion["ConexionSqlServer"]);
                dALCrudAfiliados.EliminarAfiliados(idAfiliado);
                return new ApiResponse { Respuesta = ApiStatus.OK, Mensaje = "Afiliado eliminado correctamente." };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Respuesta = ApiStatus.Error, Mensaje = $"Error al eliminar afiliado  error: {ex.Message}." };

            }
        }

        [HttpPost]
        [Route("EliminarAfiliado")]
        public ApiResponse EliminarAfiliado([FromBody] int idAfiliado)
        {
            try
            {
                DALCrudAfiliados dALCrudAfiliados = new DALCrudAfiliados(configuracion["ConexionSqlServer"]);
                dALCrudAfiliados.EliminarAfiliados(idAfiliado);
                return new ApiResponse { Respuesta = ApiStatus.OK, Mensaje = "Afiliado eliminado correctamente." };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Respuesta = ApiStatus.Error, Mensaje = $"Error al eliminar afiliado  error: {ex.Message}." };

            }
        }
    }
}
