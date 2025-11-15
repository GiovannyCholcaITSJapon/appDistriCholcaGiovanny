using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.distriCholcaGiovanny.common.DTOs;

namespace app.distriCholcaGiovanny.services.Interfaces
{
    public interface IProductoService
    {
        Task<BaseResponse<ProductoDto>> GetItem(int id);


        Task<BaseResponse<List<ProductoDto>>> GetItemsList();


        Task<BaseResponse<ProductoDto>> CrearItem(ProductoDto param);


        Task<BaseResponse<ProductoDto>> ActualizarItem(int id, ProductoDto param);


        Task<BaseResponse<string>> EliminarItem(int id);
    }
}
