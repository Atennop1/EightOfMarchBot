namespace EightOfMarchBot.Loop
{
    public sealed class Congratulations
    {
        private readonly string[] _congratulations;
        private readonly Random _random = new();
        
        private string _lastGeneratedCongratulation;
        
        public Congratulations(string[] congratulations)
            => _congratulations = congratulations ?? throw new ArgumentNullException(nameof(congratulations));

        public string GetRandom()
        {
            var generatedCongratulation = _congratulations[_random.Next(0, _congratulations.Length)];

            while (_lastGeneratedCongratulation == generatedCongratulation)
            {
                generatedCongratulation = _congratulations[_random.Next(0, _congratulations.Length)];
            }

            _lastGeneratedCongratulation = generatedCongratulation;
            return generatedCongratulation;
        }
    }
}