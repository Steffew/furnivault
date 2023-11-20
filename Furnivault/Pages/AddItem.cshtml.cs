using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Furnivault.Core.Interfaces;
using Furnivault.Data.DTOs;

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