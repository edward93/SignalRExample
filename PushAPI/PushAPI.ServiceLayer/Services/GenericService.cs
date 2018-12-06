using PushAPI.DAL.GenericEntity;
using PushAPI.ServiceLayer.Repositories;

namespace PushAPI.ServiceLayer.Services
{
    public class GenericService<T> : EntityService<T>, IGenericService<T> where T : Entity
    {
        public GenericService(IEntityRepository<T> entityRepository) : base(entityRepository)
        {
        }
    }
}