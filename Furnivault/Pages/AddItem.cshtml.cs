using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Furnivault.Data.DTOs;
using Furnivault.Data.Repositories;
using Furnivault.Core.Interfaces;

namespace Furnivault.Pages
{
    public class AddItemViewModel
    {
        public string ItemIdentifier { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }

    public class AddItemModel : PageModel
    {
        private readonly IRepository<ItemDTO> _itemRepository;

        [BindProperty]
        public AddItemViewModel Item { get; set; }

        public AddItemModel(IRepository<ItemDTO> itemRepository)
        {
            _itemRepository = itemRepository;
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

            var itemDto = new ItemDTO
            {
                Name = Item.ItemName,
                Identifier = Item.ItemIdentifier,
                Description = Item.ItemDescription,
            };

            _itemRepository.Add(itemDto);

            return RedirectToPage("./Index");
        }
    }
}