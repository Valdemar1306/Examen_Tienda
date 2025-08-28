using itssip_general.Dto;
using itssip_general.Logic;
using itssip_general.Logic.Legal;
using itssip_general_API.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace itssip_general_API.Controllers.LegalControl
{
    /// <summary>
    /// Controladora para las operaciones de login.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : BaseController
    {
        /// <summary>
        /// Instancia a la lógica de login.
        /// </summary>
        private readonly TiendaLogic TiendaLogic;

        public TiendaController(IOptions<AppSettingsDto> appSettingsModel) : base(appSettingsModel)
        {
            this.TiendaLogic = LogicFactory.Instance.GetNewTiendaLogic(this.appSettingsDto);
        }

        
        [HttpGet("getTiendas")]
        public IActionResult GetTiendas()
        {
            return Ok(this.TiendaLogic.GetTiendas());
        }

        [HttpGet("getTiendaById/{id}")]
        public IActionResult GetTiendaById(int id)
        {
            return Ok(this.TiendaLogic.GetTiendaById(id));
        }

        [HttpPost("addTienda")]
        public IActionResult AddTienda([FromBody] TiendaDto tienda)
        {
            return Ok(this.TiendaLogic.AddTienda(tienda));
        }

        [HttpPut("updateTienda/{id}")]
        public IActionResult UpdateTienda(int id, [FromBody] TiendaDto tienda)
        {
            return Ok(this.TiendaLogic.UpdateTienda(id, tienda));
        }

        [HttpDelete("deleteTienda/{id}")]
        public IActionResult DeleteTienda(int id)
        {
            return Ok(this.TiendaLogic.DeleteTienda(id));
        }
    }
}
