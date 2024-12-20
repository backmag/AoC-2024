﻿namespace AoC_2024.Solutions.DayX
{
    // template class for new days
    public class SolverDayX : Solver
    {
        private readonly InputService _inputService;
        public SolverDayX(InputService inputService)
        {
            _inputService = inputService;
        }

        public override BigInteger SolvePartOne()
        {
            var input = GetInput();

            return 0;
        }

        public override BigInteger SolvePartTwo()
        {
            var input = GetInput();
            return 0;
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
