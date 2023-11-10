using Furnivault.Data.DTOs;

namespace Furnivault.Data.Repositories
{
    public interface IItemRepository
    {
        ItemDTO GetItemById(int itemId);
        IEnumerable<ItemDTO> GetAllItems();
        void AddItem(ItemDTO item);
        void UpdateItem(ItemDTO item);
        void DeleteItem(int itemId);
    }
}