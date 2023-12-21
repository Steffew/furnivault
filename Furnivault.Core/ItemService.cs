﻿using Furnivault.Core.Entities;
using Furnivault.Core.Interfaces;

public class ItemService
{
    //todo: refactor or delete this
    private IRepository<Item> _itemRepository;

    public List<Item> Items { get; private set; }

    public ItemService(IRepository<Item> repository)
    {
        _itemRepository = repository;
    }

    public List<Item> GetAll()
    {
        return Items = _itemRepository.GetAll().ToList();
    }
}