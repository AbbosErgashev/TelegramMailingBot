using Microsoft.AspNetCore.Mvc;
using TelegramLinkBot.Models;
using TelegramLinkBot.Services;

namespace TelegramLinkBot.Controllers;

[Route("api/mailing")]
[ApiController]
public class MailingController : ControllerBase
{
    private readonly TelegramService _telegramService;

    public MailingController(TelegramService telegramService)
    {
        _telegramService = telegramService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] MailingModel request)
    {
        await _telegramService.SendMessageAsync(request.Message, request.SendToChannel, request.SendToGroups);
        return Ok(new { message = "Xabar jo‘natildi!" });
    }
}
