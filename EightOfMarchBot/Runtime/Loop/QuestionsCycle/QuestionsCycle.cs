using EightOfMarchBot.Core;
#pragma warning disable CS8618

namespace EightOfMarchBot.Loop
{
    public sealed class QuestionsCycle : IQuestionsCycle
    {
        public bool IsEnded { get; private set; }
        
        private readonly List<IQuestion> _questions;
        private readonly IMessageSender _messageSender;
        private readonly CongratulationsFactory _congratulationsFactory;
        private readonly RemainingQuestionsPhrases _remainingQuestionsPhrases;
        
        private IQuestion _currentQuestion;

        public QuestionsCycle(List<IQuestion> questions, CongratulationsFactory congratulationsFactory, RemainingQuestionsPhrases remainingQuestionsPhrases, IMessageSender messageSender)
        {
            _questions = questions ?? throw new ArgumentNullException(nameof(questions));
            _congratulationsFactory = congratulationsFactory ?? throw new ArgumentNullException(nameof(congratulationsFactory));
            _remainingQuestionsPhrases = remainingQuestionsPhrases ?? throw new ArgumentNullException(nameof(remainingQuestionsPhrases));
            _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
            _currentQuestion = _questions[0];
        }
        
        public void Start()
            => _messageSender.SendMessage($"{_remainingQuestionsPhrases.GetPhrase(_questions.Count)}\n{_currentQuestion.Text}");

        public void Continue(string answer)
        {
            if (!_currentQuestion.IsAnswerCorrect(answer))
            {
                _messageSender.SendMessage("Неверный ответ");
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
            _messageSender.SendMessage($"{_congratulationsFactory.Create()}! {remainingQuestionsPhrase}\n{_currentQuestion.Text}");
        }
    }
}