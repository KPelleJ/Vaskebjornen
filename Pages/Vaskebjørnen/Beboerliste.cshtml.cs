using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vaskebjørnen.Models;
using Vaskebjørnen.Repositories;

namespace Vaskebjørnen.Pages.Vaskebjørnen
{
    public class BeboerlisteModel : PageModel
    {
        private readonly IRepo<Resident> _residentRepo;
        public List<Resident> Residents { get; private set; }

        // The repository is injected via the constructor
        public BeboerlisteModel(IRepo<Resident> residentRepo)
        {
            _residentRepo = residentRepo;
        }
        public void OnGet()
        {
            Residents = _residentRepo.GetAll(); // Fetch the list of residents
        }
    }
}
