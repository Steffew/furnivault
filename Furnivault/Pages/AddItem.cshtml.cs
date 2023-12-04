using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Furnivault.Core.Interfaces;
using Furnivault.Core.Entities;

namespace Furnivault.Pages
{
    public class AddItemViewModel
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class AddItemModel : PageModel
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly ItemService _itemService;

        [BindProperty]
        public AddItemViewModel Item { get; set; }

        public AddItemModel(IRepository<Item> repo)
        {
            _itemRepository = repo;
            _itemService = new ItemService(repo)
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newItem = _itemService.Add(Item.Name, Item.Identifier, Item.Description);

            return RedirectToPage("./Index");
        }
    }
}