using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using Vaskebjørnen.Models;
using Vaskebjørnen.Repositories;

namespace Vaskebjørnen.Pages.Vaskebjørnen
{
    public class ResidentCreationModel : PageModel
    {
        [BindProperty]
        public Resident Res  { get; set; }


        private readonly IRepo<Resident> _residentRepo;

        public ResidentCreationModel(IRepo<Resident> repos)
        {
            _residentRepo = repos;
        }

        

        public void OnGet()
        {

        }

        public IActionResult OnPostCreate()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _residentRepo.Add(Res);
            }
            catch (Exception ex)
            {
                // Add the error message to the ModelState so it can be displayed to the user
                ModelState.AddModelError(string.Empty, "An error occurred while trying to add the resident. Please try again later.");

                // Return the same page with the error message
                return Page();
            }

            return RedirectToPage("/Vaskebjørnen/Beboerliste");
        }
    }
}
