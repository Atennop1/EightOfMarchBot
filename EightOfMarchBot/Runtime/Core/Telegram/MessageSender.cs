using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;

#pragma warning disable CS8618

namespace EightOfMarchBot.Core
{
    public sealed class MessageSender : IMessageSender
    {
        private readonly BotClient _botClient;
        private string _currentChatId;

        public MessageSender(BotClient botClient)
            => _botClient = botClient ?? throw new ArgumentNullException(nameof(botClient));

        public void ChangeChat(string chatId)
            => _currentChatId = chatId ?? throw new ArgumentNullException(nameof(chatId));

        public void SendMessage(string message)
        {
            try { _botClient.SendMessage(new SendMessageArgs(_currentChatId, message)); }
            catch { /* Some client issues */ }
        }

        public void SendPhoto(string photo)
        {
            try { _botClient.SendPhoto(new SendPhotoArgs(_currentChatId, photo)); }
            catch { /* Some client issues */ }
        }
    }
}
