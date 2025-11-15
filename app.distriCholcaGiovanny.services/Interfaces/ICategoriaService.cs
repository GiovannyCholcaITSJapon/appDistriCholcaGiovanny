using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.distriCholcaGiovanny.common.DTOs;

namespace app.distriCholcaGiovanny.services.Interfaces
{
    public interface ICategoriaService
    {
        Task<BaseResponse<CategoriaDto>> GetItem(int id);


        Task<BaseResponse<List<CategoriaDto>>> GetItemsList();


        Task<BaseResponse<CategoriaDto>> CrearItem(CategoriaDto param);


        Task<BaseResponse<CategoriaDto>> ActualizarItem(int id, CategoriaDto param);


        Task<BaseResponse<string>> EliminarItem(int id);

    }
}
