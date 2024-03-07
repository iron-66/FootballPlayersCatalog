using FootballPlayersCatalog.Context;
using FootballPlayersCatalog.Models;
using FootballPlayersCatalog.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace FootballPlayersCatalog.Controllers
{
    /// <summary>
    /// Контроллер для добавления новых игроков
    /// </summary>
    public class AddPlayerController : Controller
    {
        private readonly ILogger<AddPlayerController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IHubContext<PlayerHub> _hubContext;

        /// <summary>
        /// Конструктор контроллера AddPlayerController
        /// </summary>
        /// <param name="dbContext">Контекст базы данных</param>
        /// <param name="logger">Логгер</param>
        /// <param name="hubContext">Контекст хаба SignalR</param>
        public AddPlayerController(ApplicationDbContext dbContext, ILogger<AddPlayerController> logger, IHubContext<PlayerHub> hubContext)
        {
            _dbContext = dbContext;
            _logger = logger;
            _hubContext = hubContext;
        }

        /// <summary>
        /// Возвращает представление для для отображения формы добавления игрока
        /// </summary>
        /// <returns>Представление для добавления нового игрока</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Обработка данных формы для добавления нового игрока
        /// </summary>
        /// <param name="addPlayerForm">Модель формы добавления игрока</param>
        /// <returns>Редирект на главную страницу или отображение ошибок заполнения формы</returns>
        [HttpPost]
        public IActionResult Check(PlayerFormModel addPlayerForm)
        {
            if (ModelState.IsValid)
            {
                addPlayerForm.BirthDate = addPlayerForm.BirthDate.Date;
                _dbContext.Players.Add(addPlayerForm);
                _dbContext.SaveChanges();
                _hubContext.Clients.All.SendAsync("ReceivePlayerUpdate", "Данные были обновлены");
                return RedirectToAction("Index", "");
            }

            return View("Index", addPlayerForm);
        }

        /// <summary>
        /// Возвращает представление для отображения ошибок заполнения формы
        /// </summary>
        /// <returns>Представление с информацией об ошибке</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
