using Telegram.Bot.Types;

namespace EightOfMarchBot.Core
{
    public interface IMessageSender
    {
        void SendMessage(ChatId chatId, string message);
        void SendPhoto(ChatId chatId, string photo, string text);
    }
}