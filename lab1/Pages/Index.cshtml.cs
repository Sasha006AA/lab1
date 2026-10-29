using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab1;

namespace lab1.Pages
{
    public class IndexModel : PageModel
    {
        public Office Computer { get; set; }

        public IndexModel(Office office)
        {
            Computer = office;
        }

        public void OnGet()
        {
        }
    }
}