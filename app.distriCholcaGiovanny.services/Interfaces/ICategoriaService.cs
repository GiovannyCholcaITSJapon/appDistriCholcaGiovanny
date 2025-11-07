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


       /* Task<> GetItemsList();


        Task<> CrearItem(CategoriaDto param);


        Task<> ActualizarItem(int id, CategoriaDto param);


        Task<> EliminarItem(int id);*/

    }
}
