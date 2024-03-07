using Microsoft.AspNetCore.Mvc;
using FootballPlayersCatalog.Context;
using FootballPlayersCatalog.Models;

namespace FootballPlayersCatalog.Controllers
{
    /// <summary>
    /// Контроллер для управления списком игроков
    /// </summary>
    public class PlayersListController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly List<PlayerFormModel> _players;

        /// <summary>
        /// Конструктор контроллера PlayersListController
        /// </summary>
        /// <param name="dbContext">Контекст базы данных</param>
        public PlayersListController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _players = _dbContext.Players.ToList();
        }

        /// <summary>
        /// Возвращает представление с отображением списка игроков
        /// </summary>
        /// <returns>Представление с данными списка игроков</returns>
        public IActionResult Index()
        {
            return View(_players);
        }

        /// <summary>
        /// Обрабатывает POST запрос на редактирование данных игрока
        /// </summary>
        /// <param name="model">Модель данных игрока для редактирования</param>
        /// <returns>Редирект на страницу с отображением списка игроков</returns>
        [HttpPost]
        public IActionResult Edit(PlayerFormModel model)
        {
            if (ModelState.IsValid)
            {
                var existingPlayer = _dbContext.Players.Find(model.Id);

                if (existingPlayer != null && model.BirthDate.Year > 1924 && model.BirthDate.Year < 2024)
                {
                    existingPlayer.Name = model.Name;
                    existingPlayer.Surname = model.Surname;
                    existingPlayer.Gender = model.Gender;
                    existingPlayer.BirthDate = model.BirthDate;
                    existingPlayer.Team = model.Team;
                    existingPlayer.Country = model.Country;

                    _dbContext.SaveChanges();

                    return RedirectToAction("Index", "/PlayersList");
                }
            }

            return View("Index", _players);
        }
    }
}
