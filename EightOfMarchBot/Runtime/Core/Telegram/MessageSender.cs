using Telegram.Bot;
using Telegram.Bot.Types;

namespace EightOfMarchBot.Core
{
    public sealed class MessageSender : IMessageSender
    {
        private readonly ITelegramBotClient _botClient;

        public MessageSender(ITelegramBotClient botClient)
            => _botClient = botClient ?? throw new ArgumentNullException(nameof(botClient));

        public async void SendMessage(ChatId chatId, string message)
        {
            try { await _botClient.SendTextMessageAsync(chatId, message); }
            catch { /* Some client issues */ }
        }

        public async void SendPhoto(ChatId chatId, string photo, string text)
        {
            try { await _botClient.SendPhotoAsync(chatId, photo, text); }
            catch { /* Some client issues */ }
        }
    }
}
