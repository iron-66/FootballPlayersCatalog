using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FootballPlayersCatalog.Context;
using FootballPlayersCatalog.Models;

namespace FootballPlayersCatalog.Controllers
{
    public class PlayersListController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PlayersListController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var players = _dbContext.Players.ToList();
            return View(players);
        }

        [HttpPost]
        public IActionResult Edit(PlayerFormModel model)
        {
            if (ModelState.IsValid)
            {
                var existingPlayer = _dbContext.Players.Find(model.Id);
                if (existingPlayer != null)
                {
                    existingPlayer.Name = model.Name;
                    existingPlayer.Surname = model.Surname;
                    existingPlayer.Gender = model.Gender;
                    existingPlayer.BirthDate = model.BirthDate;
                    existingPlayer.Team = model.Team;

                    _dbContext.SaveChanges();
                    return RedirectToAction("Index", "/PlayersList");
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}

