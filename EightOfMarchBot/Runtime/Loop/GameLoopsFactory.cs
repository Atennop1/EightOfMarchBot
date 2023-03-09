using EightOfMarchBot.Core;

namespace EightOfMarchBot.Loop;

public sealed class GameLoopsFactory
{
    private readonly ITelegram _telegram;

    public GameLoopsFactory(ITelegram telegram)
        => _telegram = telegram ?? throw new ArgumentNullException(nameof(telegram));

    public GameLoop Create()
    {
        var gameStart = new GameStart(_telegram);
        var gameEnd = new GameEnd(_telegram);

        var questions = new List<IQuestion>
        {
            new Question("Для получения первой загадки подойди к Лёше Шарипову и узнай у него ключевое слово", "великое разнообразие"),
            new Question("Следующую загадку можно получить у Гриши", "писатели"),
            new Question("Дальше подойди к Антону", "физика любви"),
            new Question("Следущая у Ратмира", "женская держава"),
            new Question("Одну из загадок можно взять у Лёши Горбачёва", "женщины Англии"),
            new Question("Опять обращайся к Ратмиру", "женские топонимы"),
            new Question("За завершающей загадкой подойди к Антону", "ключ к празднику")
        };

        var congratulationStrings = new[]
        {
            "Верно",
            "Верный ответ",
            "Так держать",
            "Хорошая работа"
        };

        var congratulations = new Congratulations(congratulationStrings);
        var remainingQuestionsPhraseFactory = new RemainingQuestionsPhrases();
            
        var questionsCycle = new QuestionsCycle(questions, congratulations, remainingQuestionsPhraseFactory, _telegram);
        return new GameLoop(questionsCycle, gameStart, gameEnd); 
    }
}