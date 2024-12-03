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
            string[] lines = GetInput();
            (List<int> l1, List<int> l2) = ParseLists(lines);

            l1.Sort();
            l2.Sort();

            int result = l1.Zip(l2, (nbr1, nbr2) => Math.Abs(nbr1 - nbr2)).Sum();
            return (BigInteger)result;
        }

        public override BigInteger SolvePartTwo()
        {
            string[] lines = GetInput();
            (List<int> l1, List<int> l2) = ParseLists(lines);

            int result = l1.Select(nbr1 => l2.Count(nbr2 => nbr1 == nbr2) * nbr1).Sum();
            return (BigInteger)result;
        }

        public Tuple<List<int>, List<int>> ParseLists(string[] lines)
        {
            List<int> l1 = [];
            List<int> l2 = [];
            foreach (var line in lines)
            {
                var numbers = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (numbers.Length != 2)
                {
                    throw new Exception($"Couldn't parse input: {line}");
                }
                if (int.TryParse(numbers.First(), out int first)
                    && int.TryParse(numbers.Last(), out int last))
                {
                    l1.Add(first);
                    l2.Add(last);
                }
            }
            return Tuple.Create(l1, l2);
        }

        private string[] GetInput()
        {
            return _inputService.GetInput();
        }

    }
}
