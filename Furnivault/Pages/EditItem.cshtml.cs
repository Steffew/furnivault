using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Furnivault.Core.Interfaces;
using Furnivault.Data.DTOs;

namespace Furnivault.Pages
{
    public class EditItemViewModel
    {
        public string ItemIdentifier { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }

    public class EditItemModel : PageModel
    {
        private readonly IRepository<ItemDTO> _itemRepository;

        [BindProperty]
        public ItemDTO Item { get; set; }

        public EditItemModel(IRepository<ItemDTO> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void OnGet(int id)
        {
            Item = _itemRepository.GetById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _itemRepository.Update(Item);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostDelete(int id)
        {
            _itemRepository.Delete(id);
            return RedirectToPage("Index");
        }
    }
}