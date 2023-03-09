namespace EightOfMarchBot.Core
{
    public interface ITelegram
    {
        void ChangeChat(string chatId);
        void SendMessage(string message);
        void SendPhoto(string photoLink, string message);
    }
}