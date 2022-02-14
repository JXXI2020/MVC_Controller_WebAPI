using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using WebServiceEmployee.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebServiceEmployee.Business;
using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace WebServiceEmployee.Controllers
{

    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IEmployeeBL _bussines;

        public EmployeeAPIController(IEmployeeBL reglaBusiness)
        {
            _bussines = reglaBusiness;
        }


        /// <summary>
        /// Get Employee 
        /// </summary>
        /// <param name="id">Identificador de la regla.</param>
        /// <returns>Regla.</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="204">Operación finalizada exitosamente pero no se encontró contenido a devolver.</response>
        /// <response code="400">Problemas en la solicitud.</response>
        /// <response code="500">Problema de comunicación interno.</response>
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Employee>>> GetById(string id)
        {
            try
            {
                List<Employee> reglaDto = await _bussines.GetByIdAsync(id);
                return reglaDto == null ? StatusCode(StatusCodes.Status204NoContent, new List<string> { "No encontrado" }) : Ok(reglaDto);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new List<string> { "Error 400", ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new List<string> { "Error 500", ex.Message });
            }
        }

        /// <summary>
        /// Get Employee 
        /// </summary>
        /// 
        /// <returns>Regla.</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="204">Operación finalizada exitosamente pero no se encontró contenido a devolver.</response>
        /// <response code="400">Problemas en la solicitud.</response>
        /// <response code="500">Problema de comunicación interno.</response>
        [Microsoft.AspNetCore.Mvc.HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            try
            {
                List<Employee> reglaDto = await _bussines.Get();
                return reglaDto == null ? StatusCode(StatusCodes.Status204NoContent, new List<string> { "No encontrado" }) : Ok(reglaDto);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new List<string> { "Error 400", ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new List<string> { "Error 500", ex.Message });
            }
        }


    }
}
