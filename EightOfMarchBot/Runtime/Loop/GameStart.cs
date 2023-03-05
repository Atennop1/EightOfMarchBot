using EightOfMarchBot.Core;

namespace EightOfMarchBot.Loop
{
    public sealed class GameStart : IGameStart
    {
        private const string HelloMessage = "Привет! Квест начался";
        private readonly IMessageSender _messageSender;

        public GameStart(IMessageSender messageSender)
            => _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));

        public void Activate()
            => _messageSender.SendMessage(HelloMessage);
    }
}