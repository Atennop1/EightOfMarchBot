namespace EightOfMarchBot.Core
{
    public sealed class Question : IQuestion
    {
        public string Text { get; }
        public string Answer { get; }
    
        public Question(string text, string answer)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Answer = answer ?? throw new ArgumentNullException(nameof(answer));
        }
    }
}