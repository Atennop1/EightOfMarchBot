namespace EightOfMarchBot.Core
{
    public sealed class Question : IQuestion
    {
        public string Text { get; }
        private readonly string _answer;
    
        public Question(string text, string answer)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            _answer = answer ?? throw new ArgumentNullException(nameof(answer));
        }

        public bool IsAnswerCorrect(string answer)
        {
            if (answer == null)
                throw new ArgumentNullException(nameof(answer));
            
            return _answer == answer;
        }
    }
}