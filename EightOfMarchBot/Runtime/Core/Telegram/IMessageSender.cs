namespace EightOfMarchBot.Core
{
    public interface IMessageSender
    {
        void ChangeChat(string chatId);
        void SendMessage(string message);
        void SendPhoto(string photo);
    }
}