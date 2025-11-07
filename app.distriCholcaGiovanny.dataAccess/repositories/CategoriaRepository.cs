using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.distriCholcaGiovanny.dataAccess.context;
using app.distriCholcaGiovanny.entities.models;

namespace app.distriCholcaGiovanny.dataAccess.repositories
{
    public class CategoriaRepository : CrudGenericService<Categoria>,  ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Categoria> CreateItem(Categoria entity)
        {

            return await InsertEntity(entity);

        }

        public Task DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Categoria> GetItem(int id)
        {
          return await SelectEntity(id);
        }

        public Task<List<Categoria>> GetItemLista()
        {
            throw new NotImplementedException();
        }

        public Task UpdateItem(Categoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
