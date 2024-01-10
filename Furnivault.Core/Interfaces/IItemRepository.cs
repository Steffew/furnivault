using Furnivault.Core.Entities;

namespace Furnivault.Core.Interfaces
{
    public interface IItemRepository
    {
        Item GetById(int id);

        IEnumerable<Item> GetAll();

        void Add(Item item);

        void Update(Item item);

        void Delete(int id);
    }
}