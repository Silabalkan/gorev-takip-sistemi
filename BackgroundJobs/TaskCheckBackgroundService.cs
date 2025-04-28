using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using kullaniciGorevTakipSistemi.DataAccess;
using kullaniciGorevTakipSistemi.Entities;

namespace kullaniciGorevTakipSistemi.BackgroundJobs
{
    public class TaskCheckBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public TaskCheckBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var today = DateTime.UtcNow.Date;

                    var overdueTasks = await dbContext.Tasks
                        .Where(t => t.DueDate.Date <= today && !t.Status)
                        .Include(t => t.User)
                        .ToListAsync();

                    foreach (var task in overdueTasks)
                    {
                        // Aynı görev için daha önce bildirim oluşmuş mu kontrol et
                        bool notificationExists = await dbContext.Notifications
                            .AnyAsync(n => n.UserId == task.UserId && n.Message.Contains(task.Title) && !n.IsRead);

                        if (!notificationExists)
                        {
                            var notification = new Notification
                            {
                                UserId = task.UserId,
                                Message = $"Görev '{task.Title}' tamamlanmadı!",
                                IsRead = false
                            };

                            await dbContext.Notifications.AddAsync(notification);
                        }
                    }


                    await dbContext.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // 1 dakika arayla çalışıyor test için
            }
        }
    }
}
