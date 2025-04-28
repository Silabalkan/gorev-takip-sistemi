namespace kullaniciGorevTakipSistemi.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; } // false: Devam Ediyor, true: Tamamlandı

        // İlişkiler
        public int UserId { get; set; }
        public User? User { get; set; }

    }
}
