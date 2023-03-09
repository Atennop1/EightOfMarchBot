﻿using EightOfMarchBot.Core;

namespace EightOfMarchBot.Loop
{
    public sealed class GameEnd : IGameEnd
    {
        private const string CongratulationsMessage = "Молодец! Квест завершен. Здесь должна была быть наша общая фотка, но мы не успели её сделать. Держи эту";
        private const string CongratulationsImageLink = "https://ibb.co/vY9zwqs";
        private readonly ITelegram _telegram;

        public GameEnd(ITelegram telegram)
            => _telegram = telegram ?? throw new ArgumentNullException(nameof(telegram));

        public void Activate()
            => _telegram.SendPhoto(CongratulationsImageLink, CongratulationsMessage);
    }
}