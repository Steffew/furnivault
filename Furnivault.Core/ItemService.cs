﻿using Furnivault.Core.Entities;
using Furnivault.Core.Interfaces;

public class ItemService
{
    private readonly IRepository<Item> _itemRepository;

    public ItemService(IRepository<Item> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public Item Add(string name, string identifier, string description)
    {
        var item = new Item(name, identifier, description);
        _itemRepository.Add(item);
        return item;
    }

    public void Update(int itemId, string name, string identifier, string description)
    {
        var item = _itemRepository.GetById(itemId);
        if (item == null)
        {
            throw new KeyNotFoundException("Item is null!");
        }

        item.Update(name, identifier, description);
        _itemRepository.Update(item);
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