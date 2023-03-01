namespace EightOfMarchBot.Loop
{
    public interface IGameLoop
    {
        void Add(IGameLoopObject gameLoopObject);
        void Activate();
    }
}