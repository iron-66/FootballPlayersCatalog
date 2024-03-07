using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballPlayersCatalog.Models
{
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
        public DateTime BirthDate { get; set; }

        [Display(Name = "Команда")]
        [Required(ErrorMessage = "Введите команду")]
        public string Team { get; set; }

        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Выберите страну")]
        public string Country { get; set; }
    }
}
