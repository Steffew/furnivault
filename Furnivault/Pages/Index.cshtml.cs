using Microsoft.AspNetCore.Mvc.RazorPages;
using Furnivault.Core.Interfaces;
using Furnivault.Data.DTOs;
using Microsoft.AspNetCore.Http.Features;

public class IndexModel : PageModel
{
    private readonly IRepository<ItemDTO> _ItemRepository;
    private ItemCollection _ItemCollection;
    public List<ItemDTO> Items { get; private set; }

    public IndexModel(IRepository<ItemDTO> itemRepository)
    {
        _ItemRepository = itemRepository;
        _ItemCollection = new ItemCollection(_ItemRepository);
    }

    public void OnGet()
    {
        Items = _ItemCollection.GetAll();
    }
}