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


        /**
      * API PARA INSERTAR UNA CATEGORIA
      * */
        [HttpPost("insertarCategoria")]
        public async Task<IActionResult> PostCategories([FromBody] CategoriaDto request)
        {
            var response = await _categoriaService.CrearItem(request);
            return Ok(response);
        }

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

        /**
       * API PARA OBTENER TODAS LAS CATEGORIAS
       * */
        [HttpPost("obtenerCategorias")]
        public async Task<IActionResult> ObtenerCategorias()
        {
            var result = await _categoriaService.GetItemsList();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }



        /**
         * API PARA ACTUALIZAR UNA CATEGORIA POR ID
         * */
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> ActualizarCategories(int id, [FromBody] CategoriaDto param)
        {
            var result = await _categoriaService.ActualizarItem(id, param);
            return Ok(result);
        }


        /**
         * API PARA ELIMINAR UNA CATEGORIA POR ID
         * */
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> EliminarCategories(int id)
        {
            var result = await _categoriaService.EliminarItem(id);
            return Ok(result);
        }



    }
}
