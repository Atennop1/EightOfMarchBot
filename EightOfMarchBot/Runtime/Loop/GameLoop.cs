namespace EightOfMarchBot.Loop;

public sealed class GameLoop : IGameLoop
{
    private readonly List<IGameLoopObject> _gameLoopObjects;
    private const int UpdatesPerSeconds = 10;

    public GameLoop()
        => _gameLoopObjects = new List<IGameLoopObject>();

    public GameLoop(List<IGameLoopObject> gameLoopObjects)
        => _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));

    public void Add(IGameLoopObject gameLoopObject)
    {
        if (gameLoopObject == null)
            throw new ArgumentNullException(nameof(gameLoopObject));
        
        _gameLoopObjects.Add(gameLoopObject);
    }

    public async void Activate()
    {
        var deltaTime = 1f / UpdatesPerSeconds;
        var workingThread = new Thread(() =>
        {
            while (true)
            {
                _gameLoopObjects.ForEach(gameLoopObject => gameLoopObject.Update(deltaTime));
                Thread.Sleep((int)(deltaTime * 1000));
            }
        });
        
        workingThread.Start();
    }
}