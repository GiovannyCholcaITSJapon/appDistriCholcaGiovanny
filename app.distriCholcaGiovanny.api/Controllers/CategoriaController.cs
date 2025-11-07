using app.distriCholcaGiovanny.common.DTOs;
using app.distriCholcaGiovanny.services.Implementations;
using app.distriCholcaGiovanny.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.distriCholcaGiovanny.api.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {

        private readonly ICategoriaService _categoriaService;


        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }


        [HttpGet]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hola Mundo -- categoria");
        }


        /* [HttpPost("insertarCategoria")]
         public async Task<IActionResult> InsertarCategoria([FromBody] CategoriaDto param)
         {
             _categoriaService.GetItem()

         }*/

        /**
         * API PARA OBTENER UNA CATEGORIA POR ID
         * */
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerCategoria(int id)
        {
            var response = await _categoriaService.GetItem(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }



    }
}
