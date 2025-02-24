using TelegramLinkBot.Services;

namespace TelegramLinkBot.Background;

public class BackgroundMailing : BackgroundService
{
    private readonly TelegramService _telegramService;
    private readonly ILogger<BackgroundMailing> _logger;

    public BackgroundMailing(TelegramService telegramService, ILogger<BackgroundMailing> logger)
    {
        _telegramService = telegramService;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Avtomatik rasilka ishlamoqda...");
            await _telegramService.SendMessageAsync("Bu avtomatik yuborilgan xabar!", false, true);
            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }
    }
}
