using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.distriCholcaGiovanny.entities.models;

namespace app.distriCholcaGiovanny.dataAccess.repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> GetItem(int id);

        Task<Categoria> CreateItem(Categoria entity);

        Task<List<Categoria>> GetItemLista();

        Task UpdateItem(Categoria entity);

        Task DeleteItem(int id);
    }
}
