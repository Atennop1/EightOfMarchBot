using EightOfMarchBot.Core;
#pragma warning disable CS8618

namespace EightOfMarchBot.Loop
{
    public sealed class QuestionsCycle : IQuestionsCycle
    {
        public bool IsEnded { get; private set; }
        
        private readonly List<IQuestion> _questions;
        private readonly ITelegram _telegram;
        private readonly Congratulations _congratulations;
        private readonly RemainingQuestionsPhrases _remainingQuestionsPhrases;
        
        private IQuestion _currentQuestion;

        public QuestionsCycle(List<IQuestion> questions, Congratulations congratulations, RemainingQuestionsPhrases remainingQuestionsPhrases, ITelegram telegram)
        {
            _questions = questions ?? throw new ArgumentNullException(nameof(questions));
            _congratulations = congratulations ?? throw new ArgumentNullException(nameof(congratulations));
            _remainingQuestionsPhrases = remainingQuestionsPhrases ?? throw new ArgumentNullException(nameof(remainingQuestionsPhrases));
            _telegram = telegram ?? throw new ArgumentNullException(nameof(telegram));
            _currentQuestion = _questions[0];
        }
        
        public void Start()
            => _telegram.SendMessage($"{_remainingQuestionsPhrases.GetPhrase(_questions.Count)}\n{_currentQuestion.Text}");

        public void Continue(string answer)
        {
            if (!_currentQuestion.IsAnswerCorrect(answer))
            {
                _telegram.SendMessage("Неверный ответ");
                return;
            }

            var nextQuestionIndex = _questions.IndexOf(_currentQuestion) + 1;
            
            if (nextQuestionIndex >= _questions.Count)
            {
                IsEnded = true;
                return;
            }
            
            _currentQuestion = _questions[nextQuestionIndex];
            var remainingQuestionsPhrase = _remainingQuestionsPhrases.GetPhrase(_questions.Count - _questions.IndexOf(_currentQuestion));
            _telegram.SendMessage($"{_congratulations.GetRandom()}! {remainingQuestionsPhrase}\n{_currentQuestion.Text}");
        }
    }
}