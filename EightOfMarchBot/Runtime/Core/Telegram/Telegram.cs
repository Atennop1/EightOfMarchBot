using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;

#pragma warning disable CS8618

namespace EightOfMarchBot.Core
{
    public sealed class Telegram : ITelegram
    {
        private readonly BotClient _botClient;
        private string _currentChatId;

        public Telegram(BotClient botClient)
            => _botClient = botClient ?? throw new ArgumentNullException(nameof(botClient));

        public void ChangeChat(string chatId)
            => _currentChatId = chatId ?? throw new ArgumentNullException(nameof(chatId));

        public void SendMessage(string message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            
            try { _botClient.SendMessage(new SendMessageArgs(_currentChatId, message)); }
            catch { /* Some client issues */ }
        }

        public void SendPhoto(string photoLink, string message)
        {
            if (photoLink == null)
                throw new ArgumentNullException(nameof(photoLink));
            
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            
            try
            {
                var sendPhotoArgs = new SendPhotoArgs(_currentChatId, photoLink);
                sendPhotoArgs.Caption = message;
                _botClient.SendPhoto(sendPhotoArgs);
            }
            catch { /* Some client issues */ }
        }
    }
}
