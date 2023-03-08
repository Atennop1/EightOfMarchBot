using EightOfMarchBot.Core;
using Telegram.BotAPI;
using Telegram.BotAPI.GettingUpdates;

namespace EightOfMarchBot.Loop;

public sealed class UpdatingCycle
{
    private readonly GameLoopsFactory _gameLoopsFactory;
    private readonly BotClient _client;
    private readonly IMessageSender _messageSender;

    private readonly Dictionary<long, GameLoop> _userLoops = new();

    public UpdatingCycle(GameLoopsFactory gameLoopsFactory, BotClient client, IMessageSender messageSender)
    {
        _gameLoopsFactory = gameLoopsFactory ?? throw new ArgumentNullException(nameof(gameLoopsFactory));
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public void Start()
    {
        var updates = _client.GetUpdates();

        while (true)
        {
            if (!updates.Any())
            {
                updates = _client.GetUpdates();
                continue;
            }
                
            foreach (var update in updates)
            {
                if (update.Message == null || update.Message.Text == null || update.Message.From == null)
                    continue;

                if (!_userLoops.ContainsKey(update.Message.From.Id))
                    _userLoops.Add(update.Message.From.Id, _gameLoopsFactory.Create());

                var currentUserLoop = _userLoops[update.Message.From.Id];
                _messageSender.ChangeChat(update.Message.Chat.Id.ToString());
            
                if (update.Message.Text == "/start")
                {
                    currentUserLoop.Start();
                    continue;
                }
            
                currentUserLoop.Continue(update.Message.Text);
            }

            var offset = updates.Last().UpdateId + 1;
            updates = _client.GetUpdates(offset, limit: 10, timeout: 60);
        }
    }
}