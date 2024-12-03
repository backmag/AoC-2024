using System.Text.RegularExpressions;

namespace AoC_2024.Solutions.Day03
{
    public class SolverDay3 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay3(InputService inputService)
        {
            _inputService = inputService;
        }

        public override BigInteger SolvePartOne()
        {
            var input = GetInput();
            int sum = 0;
            var regexPattern = @"mul\(\d{1,3},\d{1,3}\)";
            foreach (var line in input)
            {
                var cleanInstructions = ExtractInstructions(line, regexPattern);
                sum += CalculateInstructions(cleanInstructions);

            }
            return sum;
        }

        public override BigInteger SolvePartTwo()
        {
            var input = GetInput();
            int sum = 0;
            var regexPattern = @"mul\(\d{1,3},\d{1,3}\)|do\(\)|don\'t\(\)";
            var doMultiply = true;
            foreach (var line in input)
            {
                var cleanInstructions = ExtractInstructions(line, regexPattern);
                var (newValue, newMultiply) = CalculateConditionalInstructions(cleanInstructions, doMultiply);
                doMultiply = newMultiply;
                sum += newValue;
            }
            return sum;
        }

        public List<string> ExtractInstructions(string instructions, string regexPattern)
        {
            var retList = new List<string>();
            var regex = new Regex(regexPattern);
            MatchCollection matches = regex.Matches(instructions);
            if (matches.Count > 0)
            {
                matches.Select(e => e.Value).ToList().ForEach(e => retList.Add(e));
            }
            return retList;
        }

        public int CalculateInstructions(List<string> instructions)
        {
            var regexPattern = @"\d+";
            var regex = new Regex(regexPattern);
            var retVal = 0;
            foreach (var instruction in instructions)
            {
                MatchCollection matches = regex.Matches(instruction);
                try
                {
                    retVal += matches.Select(e => int.Parse(e.Value)).Aggregate((n1, n2) => n1 * n2);
                }
                catch (Exception e)
                {
                    throw new Exception($"Could not parse instruction: {instruction}. Got exception: {e.StackTrace}");
                }
            }
            return retVal;
        }

        public Tuple<int, bool> CalculateConditionalInstructions(List<string> instructions, bool doMultiply)
        {
            var regexPattern = @"\d+";
            var regex = new Regex(regexPattern);
            var retVal = 0;
            foreach (var instruction in instructions)
            {
                if (instruction.Equals("do()"))
                {
                    doMultiply = true;
                }
                else if (instruction.Equals("don't()"))
                {
                    doMultiply = false;
                }
                else if (doMultiply)
                {
                    MatchCollection matches = regex.Matches(instruction);
                    try
                    {
                        retVal += matches.Select(e => int.Parse(e.Value)).Aggregate((n1, n2) => n1 * n2);
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Could not parse instruction: {instruction}. Got exception: {e.StackTrace}");
                    }
                }
            }
            return Tuple.Create(retVal, doMultiply);
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
