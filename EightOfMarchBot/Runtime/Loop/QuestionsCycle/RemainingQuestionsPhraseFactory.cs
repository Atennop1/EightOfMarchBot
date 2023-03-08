namespace EightOfMarchBot.Loop;

public sealed class RemainingQuestionsPhraseFactory
{
    public string Create(int currentQuestionIndex, int questionsCount)
    {
        var remainingQuestionsCount = questionsCount - currentQuestionIndex;

        return remainingQuestionsCount switch
        {
            > 2 => $"Осталось загадок: {remainingQuestionsCount}.",
            2 => "Последние 2.",
            1 => "Финишная черта!",
            _ => string.Empty
        };
    }
}