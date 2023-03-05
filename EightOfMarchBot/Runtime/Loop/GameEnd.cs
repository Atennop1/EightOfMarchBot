using EightOfMarchBot.Core;

namespace EightOfMarchBot.Loop
{
    public sealed class GameEnd : IGameEnd
    {
        private const string CongratulationsMessage = "";
        private readonly IMessageSender _messageSender;

        public GameEnd(IMessageSender messageSender)
            => _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));

        public void Activate()
            => _messageSender.SendMessage(CongratulationsMessage);
    }
}