using Furnivault.Core.Entities;

namespace Furnivault.Core.Interfaces
{
    public interface IItemRepository
    {
        Item GetById(int id);

        IEnumerable<Item> GetAll();

        void Add(Item entity);

        void Update(Item entity);

        void Delete(int id);
    }
}