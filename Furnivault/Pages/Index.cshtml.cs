using Furnivault.Data.DTOs;
using Furnivault.Data.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly IItemRepository _itemRepository;
    public List<ItemDTO> Items { get; private set; }

    public IndexModel(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public void OnGet()
    {
        Items = _itemRepository.GetAllItems().ToList();
    }
}