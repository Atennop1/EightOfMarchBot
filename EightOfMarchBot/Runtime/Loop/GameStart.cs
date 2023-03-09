﻿using EightOfMarchBot.Core;

namespace EightOfMarchBot.Loop
{
    public sealed class GameStart : IGameStart
    {
        private const string HelloMessage = "Привет! Квест начался! Твоя задача - отгадать 7 загадок от твоих одноклассников и прислать мне ключевое слово от каждой. Это ключевое слово тебе даст сам мальчик, чью загадку ты отгадаешь";
        private readonly ITelegram _telegram;

        public GameStart(ITelegram telegram)
            => _telegram = telegram ?? throw new ArgumentNullException(nameof(telegram));

        public void Activate()
            => _telegram.SendMessage(HelloMessage);
    }
}