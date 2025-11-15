using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.distriCholcaGiovanny.common.DTOs;
using app.distriCholcaGiovanny.dataAccess.repositories;
using app.distriCholcaGiovanny.entities.models;
using app.distriCholcaGiovanny.services.Interfaces;
using Azure;
using Azure.Core;

namespace app.distriCholcaGiovanny.services.Implementations
{

    public class CategoriaService : ICategoriaService
    {

        private readonly ICategoriaRepository _repository;


        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }


        public async Task<BaseResponse<CategoriaDto>> GetItem(int id)
        {
            var response = new BaseResponse<CategoriaDto>();
            try
            {
                var categoria = await _repository.GetItem(id);
                if (categoria == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new CategoriaDto
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion
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

        public async Task<BaseResponse<CategoriaDto>> CrearItem(CategoriaDto param) {

            var respuesta = new BaseResponse<CategoriaDto>();
            try
            {
                Categoria categoria = new();
                categoria.Nombre = param.Nombre;
                categoria.Descripcion = param.Descripcion;
                categoria.Estado = true;
                categoria.Fecha = DateTime.Now;

                categoria = await _repository.CreateItem(categoria);

                /*var categoriaDto = new CategoriaDto();
                categoriaDto.Id = categoria.Id;
                categoriaDto.Nombre = categoria.Nombre;
                categoriaDto.Descripcion = categoria.Descripcion;
                respuesta.Result = categoriaDto;*/

                respuesta.Result = new CategoriaDto
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion
                };

                respuesta.Success = true;
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.ErrorMessage = ex.Message;

            }

            return respuesta;



        }

        public async Task<BaseResponse<List<CategoriaDto>>> GetItemsList()
        {
            var response = new BaseResponse<List<CategoriaDto>>();
            try
            {
                var result = await _repository.GetItemLista();

                response.Result = result.Select(p => new CategoriaDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion
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

        public async Task<BaseResponse<CategoriaDto>> ActualizarItem(int id, CategoriaDto param)
        {
            var response = new BaseResponse<CategoriaDto>();
            try
            {
                Categoria categoria = new();
                categoria.Id = id;
                categoria.Nombre = param.Nombre;
                categoria.Descripcion = param.Descripcion;
                categoria.Fecha = DateTime.Now;
                categoria.Estado = true;

                await _repository.UpdateItem(categoria);

                response.Result = new CategoriaDto
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion,
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
