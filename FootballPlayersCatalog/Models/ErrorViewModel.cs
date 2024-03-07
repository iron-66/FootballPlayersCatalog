namespace FootballPlayersCatalog.Models
{
    /// <summary>
    /// Модель представления ошибки
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Получает или задает ID запроса, связанного с ошибкой
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Значение, указывающее, следует ли отображать ID запроса
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
