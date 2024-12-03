using System.Runtime.ExceptionServices;

namespace AoC_2024.Solutions.Day02
{
    public class SolverDay2 : Solver
    {
        private readonly InputService _inputService;

        public SolverDay2(InputService inputService)
        {
            _inputService = inputService;

        }
        public override BigInteger SolvePartOne()
        {
            var lines = GetInput();
            int counter = 0;
            foreach (var line in lines)
            {
                var list = line.Split(" ").Select(e => int.Parse(e)).ToList();
                if (EvaluateList(list))
                {
                    counter++;
                }
            }
            return (BigInteger)counter;
        }

        public override BigInteger SolvePartTwo()
        {
            var lines = GetInput();
            int counter = 0;
            foreach (var line in lines)
            {
                var list = line.Split(" ").Select(e => int.Parse(e)).ToList();
                if (EvaluateList(list))
                {
                    counter++;
                }
                else if (EvaluateWithDampener(list))
                {
                    counter++;
                }
            }
            return (BigInteger)counter;
        }
        private string[] GetInput()
        {
            return _inputService.GetInput();
        }

        private bool EvaluateList(List<int> list)
        {
            var prev = list[0];
            var decreasing = prev > list[1];
            foreach (var value in list.Skip(1))
            {
                if (Math.Abs(prev - value) == 0 || Math.Abs(prev - value) > 3)
                {
                    // Too big difference, not valid
                    return false;
                }
                if ((decreasing && prev < value) || (!decreasing && prev > value))
                {
                    // not all values are decreasing/increasing
                    return false;
                }
                prev = value;
            }
            return true;
        }
        private bool EvaluateWithDampener(List<int> list)
        {
            // brute force, try dropping every element once and check if it's valid
            for (int idx = 0; idx < list.Count; idx++)
            {
                if (EvaluateList(list.Where((item, index) => index != idx).ToList()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
