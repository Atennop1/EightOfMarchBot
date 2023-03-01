namespace EightOfMarchBot
{
    public interface IInput
    {
        bool IsActive { get; }
        string PlayerInput { get; }
    }
}