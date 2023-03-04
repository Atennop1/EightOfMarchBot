namespace EightOfMarchBot.Core
{
    public interface IQuestion
    {
        string Text { get; }
        bool IsAnswerCorrect(string answer);
    }
}