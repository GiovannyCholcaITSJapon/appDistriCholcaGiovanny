using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.distriCholcaGiovanny.common.DTOs;
using app.distriCholcaGiovanny.dataAccess.repositories;
using app.distriCholcaGiovanny.entities.models;
using app.distriCholcaGiovanny.services.EventMQ;
using app.distriCholcaGiovanny.services.Interfaces;
using Azure;
using Azure.Core;

namespace app.distriCholcaGiovanny.services.Implementations
{
    public class ProductoService : IProductoService
    {

        private readonly IProductoRepository _repository;
        private readonly IRabbitMQService _rabbitMQService;


        public ProductoService(IProductoRepository repository, IRabbitMQService rabbitMQService)
        {
            _repository = repository;
            _rabbitMQService = rabbitMQService;
        }


        public async Task<BaseResponse<ProductoDto>> GetItem(int id)
        {
            var response = new BaseResponse<ProductoDto>();
            try
            {
                var producto = await _repository.GetItem(id);
                if (producto == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }


                response.Result = new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    CategoriaId = producto.Id,
                    PrecioUnitario = producto.PrecioUnitario
                };
                response.Success = true;


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;

        }

        public async Task<BaseResponse<ProductoDto>> CrearItem(ProductoDto param)
        {

            var respuesta = new BaseResponse<ProductoDto>();
            try
            {
                Producto producto = new();
                producto.Nombre = param.Nombre;
                producto.Descripcion = param.Descripcion;
                producto.CategoriaId = param.CategoriaId;
                producto.PrecioUnitario = param.PrecioUnitario;
                producto.Estado = true;
                producto.Fecha = DateTime.Now;

                producto = await _repository.CreateItem(producto);

                //paso de entidad a un ProductoDTO
                respuesta.Result = new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    PrecioUnitario = producto.PrecioUnitario,
                    CategoriaId = producto.CategoriaId
                };
                respuesta.Success = true;

                await _rabbitMQService.PublishMessage(respuesta.Result, "ProductoMensaje");

            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.ErrorMessage = ex.Message;

            }

            return respuesta;
        }

        public async Task<BaseResponse<List<ProductoDto>>> GetItemsList()
        {
            var response = new BaseResponse<List<ProductoDto>>();
            try
            {
                var result = await _repository.GetItemLista();
                response.Result = result.Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    PrecioUnitario = p.PrecioUnitario,
                    CategoriaId = p.CategoriaId
                }).ToList();

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<ProductoDto>> ActualizarItem(int id, ProductoDto param)
        {
            var response = new BaseResponse<ProductoDto>();
            try
            {
                Producto producto = new();
                producto.Id = id;
                producto.Nombre = param.Nombre;
                producto.Descripcion = param.Descripcion;
                producto.CategoriaId = param.CategoriaId;
                producto.PrecioUnitario = param.PrecioUnitario;
                producto.Fecha = DateTime.Now;
                producto.Estado = true;

                await _repository.UpdateItem(producto);

                response.Result = new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    PrecioUnitario = producto.PrecioUnitario,
                    CategoriaId = producto.CategoriaId
                };
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }


        public async Task<BaseResponse<string>> EliminarItem(int id)
        {
            var response = new BaseResponse<string>();
            try
            {
                await _repository.DeleteItem(id);

                response.Result = "OK";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

    }
}
