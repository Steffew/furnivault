using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        [BindProperty]
        public AddItemViewModel Item { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {

        }
    }
}
