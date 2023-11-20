﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Furnivault.Core.Interfaces;
using Furnivault.Data.DTOs;

public class IndexModel : PageModel
{
    private readonly IRepository<ItemDTO> _itemRepository; // todo: move to core layer
    public List<ItemDTO> Items { get; private set; }

    public IndexModel(IRepository<ItemDTO> itemRepository) // todo: move to core layer
    {
        _itemRepository = itemRepository;
    }

    public void OnGet()
    {
        Items = _itemRepository.GetAll().ToList();
    }
}