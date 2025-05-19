using System.ComponentModel.DataAnnotations;

namespace kullaniciGorevTakipSistemi.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim zorunludur.")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta formatı.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string PasswordHash { get; set; } = null!;

        public DateTime? SessionExpireDate { get; set; }

        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public List<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
