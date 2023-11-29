using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Furnivault.Core.Interfaces;
using Furnivault.Data.DTOs;

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
                Name = Item.Name,
                Identifier = Item.Identifier,
                Description = Item.Description,
            };

            _itemRepository.Add(itemDto);

            return RedirectToPage("./Index");
        }
    }
}