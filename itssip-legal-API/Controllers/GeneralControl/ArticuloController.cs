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
    public class ArticuloController : BaseController
    {
        /// <summary>
        /// Instancia a la lógica de login.
        /// </summary>
        private readonly ArticuloLogic ArticuloLogic;

        public ArticuloController(IOptions<AppSettingsDto> appSettingsModel) : base(appSettingsModel)
        {
            this.ArticuloLogic = LogicFactory.Instance.GetNewArticuloLogic(this.appSettingsDto);
        }

        
        [HttpGet("getArticulos")]
        public IActionResult GetArticulos()
        {
            return Ok(this.ArticuloLogic.GetArticulos());
        }

        [HttpGet("getArticuloById/{id}")]
        public IActionResult GetArticuloById(int id)
        {
            return Ok(this.ArticuloLogic.GetArticuloById(id));
        }

        [HttpPost("addArticulo")]
        public IActionResult AddArticulo([FromForm] ArticuloDto articulo, IFormFile? imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                var uploadsPath = Path.Combine(appSettingsDto.PathFiles, "imagenes");
                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }

                var filePath = Path.Combine(uploadsPath, imagen.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imagen.CopyTo(stream);
                }

                articulo.UrlImagen = "/imagenes/" + imagen.FileName;
            }

            // Aquí llamarías a tu lógica para guardar en DB
            return Ok(this.ArticuloLogic.AddArticulo(articulo));
        }

        [HttpPut("updateArticulo/{id}")]
        public IActionResult UpdateArticulo(int id, [FromForm] ArticuloDto articulo, IFormFile? imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                var uploadsPath = Path.Combine(appSettingsDto.PathFiles, "imagenes");
                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }

                var filePath = Path.Combine(uploadsPath, imagen.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imagen.CopyTo(stream);
                }

                articulo.UrlImagen = "/imagenes/" + imagen.FileName;
            }

            // Aquí actualizas en DB
            articulo.IdArticulo = id;
            return Ok(this.ArticuloLogic.UpdateArticulo(id, articulo));
        }

        [HttpDelete("deleteArticulo/{id}")]
        public IActionResult DeleteArticulo(int id)
        {
            return Ok(this.ArticuloLogic.DeleteArticulo(id));
        }

        [HttpGet("getImagen")]
        public IActionResult GetImagen([FromQuery] string fileName)
        {
            try
            {
                var filePath = appSettingsDto.PathFiles + fileName;

                if (!System.IO.File.Exists(filePath))
                    return NotFound("La imagen no existe");

                var image = System.IO.File.OpenRead(filePath);
                var extension = Path.GetExtension(filePath).ToLowerInvariant();

                string contentType = extension switch
                {
                    ".jpg" or ".jpeg" => "image/jpeg",
                    ".png" => "image/png",
                    ".gif" => "image/gif",
                    _ => "application/octet-stream"
                };

                return File(image, contentType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
