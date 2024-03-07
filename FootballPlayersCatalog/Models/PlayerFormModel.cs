using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballPlayersCatalog.Models
{
    /// <summary>
    /// Модель формы для игрока
    /// </summary>
    public class PlayerFormModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Выберите пол")]
        public string Gender { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Укажите дату рождения")]
        [Column(TypeName = "date")]
        [Range(typeof(DateTime), "1924-01-01", "2023-12-31", ErrorMessage = "Год рождения должен быть в диапазоне от 1924 до 2023")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Команда")]
        [Required(ErrorMessage = "Введите команду")]
        public string Team { get; set; }

        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Выберите страну")]
        public string Country { get; set; }
    }
}
