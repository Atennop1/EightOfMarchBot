using Telegram.Bot;
using Telegram.Bot.Types;
#pragma warning disable CS8618

namespace EightOfMarchBot.Core
{
    public sealed class MessageSender : IMessageSender
    {
        private readonly ITelegramBotClient _botClient;
        private ChatId _currentChatId;

        public MessageSender(ITelegramBotClient botClient)
            => _botClient = botClient ?? throw new ArgumentNullException(nameof(botClient));

        public void ChangeChat(ChatId chatId)
            => _currentChatId = chatId ?? throw new ArgumentNullException(nameof(chatId));

        public async void SendMessage(string message)
        {
            try { await _botClient.SendTextMessageAsync(_currentChatId, message); }
            catch { /* Some client issues */ }
        }

        public async void SendPhoto(string photo, string text)
        {
            try { await _botClient.SendPhotoAsync(_currentChatId, photo, text); }
            catch { /* Some client issues */ }
        }
    }
}
