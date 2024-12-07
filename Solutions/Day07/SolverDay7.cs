namespace AoC_2024.Solutions.Day07
{
    public class SolverDay7 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay7(InputService inputService)
        {
            _inputService = inputService;
        }

        public override BigInteger SolvePartOne()
        {
            var input = GetInput();
            (var testValues, var equations) = ParseInput(input);
            BigInteger retVal = 0;

            foreach (var (testValue, equation) in testValues.Zip(equations, (a, b) => (a, b)))
            {
                if (ValidEquation(equation.Skip(1), equation.First(), testValue))
                {
                    retVal += testValue;
                }
            }
            return retVal;
        }

        public override BigInteger SolvePartTwo()
        {
            var input = GetInput();
            (var testValues, var equations) = ParseInput(input);
            BigInteger retVal = 0;

            foreach (var (testValue, equation) in testValues.Zip(equations, (a, b) => (a, b)))
            {
                if (ValidEquationConcatenate(equation.Skip(1), equation.First(), testValue))
                {
                    retVal += testValue;
                }
            }
            return retVal;
        }

        public bool ValidEquation(IEnumerable<int> equation, BigInteger currentValue, BigInteger testValue)
        {
            if (equation.Count() == 1)
            {
                return testValue == currentValue * equation.First() || testValue == currentValue + equation.First();
            }
            if (ValidEquation(equation.Skip(1), currentValue + equation.First(), testValue))
            {
                return true;
            }
            if (ValidEquation(equation.Skip(1), currentValue * equation.First(), testValue))
            {
                return true;
            }
            return false;
        }

        public bool ValidEquationConcatenate(IEnumerable<int> equation, BigInteger currentValue, BigInteger testValue)
        {
            if (equation.Count() == 1)
            {
                return testValue == currentValue * equation.First() ||
                    testValue == currentValue + equation.First() ||
                    testValue == ConcatenateValue(currentValue, equation.First());
            }
            if (ValidEquationConcatenate(equation.Skip(1), currentValue + equation.First(), testValue))
            {
                return true;
            }
            if (ValidEquationConcatenate(equation.Skip(1), currentValue * equation.First(), testValue))
            {
                return true;
            }
            if (ValidEquationConcatenate(equation.Skip(1), ConcatenateValue(currentValue, equation.First()), testValue))
            {
                return true;
            }
            return false;
        }

        public static BigInteger ConcatenateValue(BigInteger first, BigInteger second)
        {
            return first * (BigInteger)Math.Pow(10, second.ToString().Length) + second;
        }

        public (IEnumerable<BigInteger>, IEnumerable<IEnumerable<int>>) ParseInput(string[] input)
        {
            List<BigInteger> testValues = [];
            List<IEnumerable<int>> equations = [];
            foreach (var line in input)
            {
                var splittedLine = line.Split(":").Select(e => e.Trim()).ToList();
                testValues.Add(BigInteger.Parse(splittedLine.First()));
                equations.Add(splittedLine[1].Split(" ").Select(e => int.Parse(e)));
            }
            return (testValues, equations);
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
