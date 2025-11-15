using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.distriCholcaGiovanny.entities.models;

namespace app.distriCholcaGiovanny.dataAccess.repositories
{
    public interface IProductoRepository
    {
        Task<Producto> GetItem(int id);

        Task<Producto> CreateItem(Producto entity);

        Task<List<Producto>> GetItemLista();

        Task UpdateItem(Producto entity);

        Task DeleteItem(int id);
    }
}
