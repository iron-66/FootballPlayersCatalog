using Microsoft.EntityFrameworkCore;
using FootballPlayersCatalog.Models;

namespace FootballPlayersCatalog.Context
{
    /// <summary>
    /// Контекст базы данных приложения для работы с таблицей игроков
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Конструктор объектов контекста базы данных
        /// </summary>
        /// <param name="options">Параметры подключения к базе данных</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /// <summary>
        /// Получает или устанавливает набор данных для работы с таблицей игроков
        /// </summary>
        public DbSet<PlayerFormModel> Players { get; set; }
    }
}
