using EightOfMarchBot.Core;
#pragma warning disable CS8618

namespace EightOfMarchBot.Loop
{
    public sealed class QuestionsCycle : IQuestionsCycle
    {
        public bool IsEnded { get; private set; }
        
        private readonly List<IQuestion> _questions;
        private readonly IMessageSender _messageSender;
        
        private IQuestion _currentQuestion;

        public QuestionsCycle(List<IQuestion> questions, IMessageSender messageSender)
        {
            _questions = questions ?? throw new ArgumentNullException(nameof(questions));
            _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
            _currentQuestion = _questions[0];
        }

        public void Start()
            => _messageSender.SendMessage($"Осталось вопросов: {_questions.Count}\n{_currentQuestion.Text}");

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
            var remainingQuestionsCount = _questions.Count - _questions.IndexOf(_currentQuestion);
            _messageSender.SendMessage($"Правильно! Осталось вопросов: {remainingQuestionsCount}\n{_currentQuestion.Text}");
        }
    }
}