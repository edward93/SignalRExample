using PushAPI.DAL.GenericEntity;

namespace PushAPI.ServiceLayer.Services
{
    public interface IGenericService<T> : IEntityService<T> where T : Entity
    {
    }
}