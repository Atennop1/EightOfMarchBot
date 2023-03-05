using Telegram.Bot.Types;

namespace EightOfMarchBot.Core
{
    public interface IMessageSender
    {
        void ChangeChat(ChatId chatId);
        void SendMessage(string message);
        void SendPhoto(string photo, string text);
    }
}