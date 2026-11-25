using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace voiceSpend.Services;

public class TelegramBotWorker : BackgroundService
{
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<TelegramBotWorker> _logger;

    public TelegramBotWorker(ITelegramBotClient botClient, ILogger<TelegramBotWorker> logger)
    {
        _botClient = botClient;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var me = await _botClient.GetMe(stoppingToken);
        _logger.LogInformation("Bot iniciado correctamente: @{Username}", me.Username);

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = [UpdateType.Message]
        };

        // StartReceiving corre en background escuchando updates
        _botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            errorHandler: HandleErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: stoppingToken
        );

        // Mantiene el worker vivo mientras la app esté corriendo
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

    private async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message || string.IsNullOrWhiteSpace(message.Text))
            return;

        _logger.LogInformation("Mensaje recibido de {ChatId}: {Text}", message.Chat.Id, message.Text);

        await bot.SendMessage(
            chatId: message.Chat.Id,
            text: "hola",
            cancellationToken: cancellationToken
        );
    }

    private Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Error en Telegram Bot");
        return Task.CompletedTask;
    }
}