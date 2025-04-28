namespace kullaniciGorevTakipSistemi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime? SessionExpireDate { get; set; }

        // İlişkiler
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public List<Notification> Notifications { get; set; } = new List<Notification>();
    }
}

