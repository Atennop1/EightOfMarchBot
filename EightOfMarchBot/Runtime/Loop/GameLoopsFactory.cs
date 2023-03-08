using EightOfMarchBot.Core;

namespace EightOfMarchBot.Loop;

public sealed class GameLoopsFactory
{
    private readonly IMessageSender _messageSender;

    public GameLoopsFactory(IMessageSender messageSender)
        => _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));

    public GameLoop Create()
    {
        var gameStart = new GameStart(_messageSender);
        var gameEnd = new GameEnd(_messageSender);

        var questions = new List<IQuestion>
        {
            new Question("Для получения первой загадки подойди к Ратмиру и узнай у него ключевое слово", "женская держава"),
            new Question("Следующую загадку можно получить у Гриши", "писатели"),
            new Question("Следующая загадка у Лёши Шарипова", "великое разнообразие"),
            new Question("Дальше у Антона", "физика любви"),
            new Question("Одну из них можно взять у Лёши Горбачёва", "женщины Англии"),
            new Question("Снова подойди к Ратмиру", "женские топонимы"),
            new Question("За завершающей загадкой обращайся к Антону", "ключ к празднику")
        };

        var congratulations = new[]
        {
            "Верно",
            "Верный ответ",
            "Так держать",
            "Хорошая работа"
        };

        var congratulationsFactory = new CongratulationsFactory(congratulations);
        var remainingQuestionsPhraseFactory = new RemainingQuestionsPhrase();
            
        var questionsCycle = new QuestionsCycle(questions, congratulationsFactory, remainingQuestionsPhraseFactory, _messageSender);
        return new GameLoop(questionsCycle, gameStart, gameEnd); 
    }
}