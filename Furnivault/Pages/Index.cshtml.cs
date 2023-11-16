using Furnivault.Data.DTOs;
using Furnivault.Data.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly IItemRepository _itemRepository; // todo: move to core layer
    public List<ItemDTO> Items { get; private set; }

    public IndexModel(IItemRepository itemRepository) // todo: move to core layer
    {
        _itemRepository = itemRepository;
    }

    public void OnGet()
    {
        Items = _itemRepository.GetAllItems().ToList();
    }
}