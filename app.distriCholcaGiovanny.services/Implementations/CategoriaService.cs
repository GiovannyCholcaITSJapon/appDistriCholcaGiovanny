using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.distriCholcaGiovanny.common.DTOs;
using app.distriCholcaGiovanny.dataAccess.repositories;
using app.distriCholcaGiovanny.services.Interfaces;

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

    }
}
