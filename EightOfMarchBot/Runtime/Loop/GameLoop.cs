namespace EightOfMarchBot.Loop
{
    public sealed class GameLoop
    {
        private readonly IQuestionsCycle _questionsCycle;
        private readonly IGameStart _gameStart;
        private readonly IGameEnd _gameEnd;

        public GameLoop(IQuestionsCycle questionsCycle, IGameStart gameStart, IGameEnd gameEnd)
        {
            _questionsCycle = questionsCycle ?? throw new ArgumentNullException(nameof(questionsCycle));
            _gameStart = gameStart ?? throw new ArgumentNullException(nameof(gameStart));
            _gameEnd = gameEnd ?? throw new ArgumentNullException(nameof(gameEnd));
        }

        public void Start()
        {
            _gameStart.Activate();
            _questionsCycle.Start();
        }

        public void Continue(string text)
        {
            if (_questionsCycle.IsEnded)
                return;
            
            _questionsCycle.Continue(text);

            if (_questionsCycle.IsEnded)
                _gameEnd.Activate();
        }
    }
}