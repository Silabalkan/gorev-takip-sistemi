using System.ComponentModel.DataAnnotations;

namespace kullaniciGorevTakipSistemi.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur.")]
        [MaxLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public string Title { get; set; } = null!;

        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur.")]
        public DateTime DueDate { get; set; }

        public bool Status { get; set; }

        // İlişkiler
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
