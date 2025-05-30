﻿namespace kullaniciGorevTakipSistemi.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; } = null!;
        public bool IsRead { get; set; } = false;

        public DateTime CreatedDate { get; set; } 

        // İlişkiler
        public User User { get; set; } = null!;
    }
}
