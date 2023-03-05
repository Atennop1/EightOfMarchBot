namespace EightOfMarchBot.Loop
{
    public interface IQuestionsCycle
    {
        bool IsEnded { get; }
        
        void Start();
        void Continue(string answer);
    }
}