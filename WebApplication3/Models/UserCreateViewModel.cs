using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "Требуется указать имя!")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Требуется указать фамилию!")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
    }
}
