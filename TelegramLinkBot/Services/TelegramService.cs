using Telegram.Bot;

namespace TelegramLinkBot.Services;

public class TelegramService
{
    private readonly TelegramBotClient _botClient;
    private readonly IConfiguration _config;

    public TelegramService(IConfiguration config)
    {
        _config = config;
        _botClient = new TelegramBotClient(_config["TelegramBot:Token"]);
    }

    public async Task SendMessageAsync(string message, bool sendToChannel = false, bool sendToGroups = false)
    {
        var recipients = _config.GetSection("TelegramBot:UserIds").Get<long[]>();
        var groups = _config.GetSection("TelegramBot:GroupIds").Get<string[]>();
        var channels = _config.GetSection("TelegramBot:ChannelId").Get<string[]>();

        if (sendToChannel)
        {
            foreach (var channelId in channels)
            {
                await _botClient.SendTextMessageAsync(channelId, message);
            }
        }

        if (sendToGroups)
        {
            foreach (var groupId in groups)
            {
                await _botClient.SendTextMessageAsync(groupId, message);
            }
        }

        foreach (var userId in recipients)
        {
            await _botClient.SendTextMessageAsync(userId, message);
        }
    }
}
