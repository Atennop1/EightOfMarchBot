namespace EightOfMarchBot.Loop;

public sealed class RemainingQuestionsPhrases
{
    public string GetPhrase(int remainingQuestionsCount)
    {
        return remainingQuestionsCount switch
        {
            > 2 => $"Осталось загадок: {remainingQuestionsCount}.",
            2 => "Последние 2.",
            1 => "Финишная черта!",
            _ => string.Empty
        };
    }
}