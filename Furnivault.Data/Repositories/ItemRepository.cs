using Furnivault.Data.DTOs;

namespace Furnivault.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly string _connectionString;

        public ItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ItemDTO GetItemById(int itemId)
        {
        }

        public IEnumerable<ItemDTO> GetAllItems()
        {
        }

        public void AddItem(ItemDTO item)
        {
        }

        public void UpdateItem(ItemDTO item)
        {
        }

        public void DeleteItem(int itemId)
        {
        }
    }
}
