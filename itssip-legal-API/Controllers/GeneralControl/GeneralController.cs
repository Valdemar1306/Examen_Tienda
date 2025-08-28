using itssip_general.Dto;
using itssip_general.Logic;
using itssip_general.Logic.Legal;
using itssip_general_API.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace itssip_general_API.Controllers.LegalControl
{
    /// <summary>
    /// Controladora para las operaciones de login.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : BaseController
    {
        /// <summary>
        /// Instancia a la lógica de login.
        /// </summary>
        private readonly GeneralLogic GeneralLogic;

        public GeneralController(IOptions<AppSettingsDto> appSettingsModel) : base(appSettingsModel)
        {
            this.GeneralLogic = LogicFactory.Instance.GetNewGeneralLogic(this.appSettingsDto);
        }

        [HttpGet(Name = "Get")]
        public IEnumerable<string> Get()
        {

            return new string[] { "GeneralController", DateTime.Now.Year.ToString() };
        }

        [HttpGet("getClientes")]
        public IActionResult GetClientes()
        {
            return Ok(this.GeneralLogic.GetClientes());
        }

        [HttpGet("getClienteById/{id}")]
        public IActionResult GetClienteById(int id)
        {
            return Ok(this.GeneralLogic.GetClienteById(id));
        }

        [HttpPost("addCliente")]
        public IActionResult AddCliente([FromBody] ClienteDto cliente)
        {
            return Ok(this.GeneralLogic.AddCliente(cliente));
        }

        [HttpPut("updateCliente/{id}")]
        public IActionResult UpdateCliente( int id, [FromBody] ClienteDto cliente)
        {
            return Ok(this.GeneralLogic.UpdateCliente(id, cliente));
        }

        [HttpDelete("deleteCliente/{id}")]
        public IActionResult DeleteCliente(int id)
        {
            return Ok(this.GeneralLogic.DeleteCliente(id));
        }

        [HttpPost("buyCarrito")]
        public IActionResult BuyCarrito([FromBody] List<CarritoItemDto> lstCarrito)
        {
            return Ok(this.GeneralLogic.BuyCarrito(lstCarrito));
        }
    }
}
