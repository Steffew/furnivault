using Furnivault.Core.Entities;
using Furnivault.Core.Interfaces;

public class ItemService
{
    private readonly IRepository<Item> _itemRepository;

    public IEnumerable<Item> GetAll()
    {
        return _itemRepository.GetAll();
    }

    public ItemService(IRepository<Item> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public Item GetById(int itemId)
    {
        return _itemRepository.GetById(itemId);
    }

    public Item Add(string name, string identifier, string description)
    {
        var item = new Item(name, identifier, description);
        _itemRepository.Add(item);
        return item;
    }

    public void Update(int itemId, string name, string identifier, string description)
    {
        var item = GetById(itemId);
        if (item == null)
        {
            throw new KeyNotFoundException("Item is null!");
        }

        item.Update(name, identifier, description);
        _itemRepository.Update(item);
    }

    public void Update(Item item)
    {
        _itemRepository.Update(item);
    }

    public void Delete(int itemId)
    {
        _itemRepository.Delete(itemId);
    }

    public void ToggleItemFavoriteStatus(int itemId)
    {
        var item = _itemRepository.GetById(itemId);
        if (item == null)
        {
            throw new KeyNotFoundException("Item is null!");
        }

        item.ToggleFavorite();
        _itemRepository.Update(item);
    }
}