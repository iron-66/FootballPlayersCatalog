using FootballPlayersCatalog.Context;
using FootballPlayersCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FootballPlayersCatalog.Controllers
{
    public class AddPlayerController : Controller
    {
        private readonly ILogger<AddPlayerController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public AddPlayerController(ApplicationDbContext dbContext, ILogger<AddPlayerController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(PlayerFormModel addPlayerForm)
        {
            if (ModelState.IsValid)
            {
                addPlayerForm.BirthDate = addPlayerForm.BirthDate.Date;
                _dbContext.Players.Add(addPlayerForm);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "");
            }

            return View("Index", addPlayerForm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
