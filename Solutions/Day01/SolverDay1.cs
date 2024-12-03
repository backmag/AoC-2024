namespace AoC_2024.Solutions.Day01
{
    public class SolverDay1 : Solver
    {
        private readonly InputService _inputService;

        public SolverDay1(InputService inputService)
        {
            _inputService = inputService;
        }
        public override BigInteger SolvePartOne()
        {
            var lines = GetInput();
            return BigInteger.Zero;
        }

        public override BigInteger SolvePartTwo()
        {
            var lines = GetInput();
            return BigInteger.Zero;
        }
        private string[] GetInput()
        {
            return _inputService.GetInput();
        }

    }
}
