namespace AoC_2024.Solutions.Day05
{
    public class SolverDay5 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay5(InputService inputService)
        {
            _inputService = inputService;
        }

        public override BigInteger SolvePartOne()
        {
            var input = GetInput();
            var (orderingRules, updates) = ParseInput(input);
            var retVal = 0;

            foreach (var update in updates)
            {
                if (IsValidUpdate(update, orderingRules))
                {
                    int midIdx = (update.Count - 1) / 2;
                    retVal += update[midIdx];
                }
            }
            return retVal;
        }

        public override BigInteger SolvePartTwo()
        {
            var input = GetInput();
            var (orderingRules, updates) = ParseInput(input);
            var retVal = 0;

            foreach (var update in updates)
            {
                if (!IsValidUpdate(update, orderingRules))
                {
                    var newUpdate = FixUpdateList(update, orderingRules);
                    int midIdx = (newUpdate.Count - 1) / 2;
                    retVal += newUpdate[midIdx];
                }
            }
            return retVal;
        }

        public bool IsValidUpdate(List<int> updates, HashSet<(int first, int second)> rules)
        {
            for (int firstIdx = 0; firstIdx < updates.Count; firstIdx++)
            {
                for (int secondIdx = firstIdx + 1; secondIdx < updates.Count; secondIdx++)
                {
                    if (rules.Contains((updates[secondIdx], updates[firstIdx])))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public List<int> FixUpdateList(List<int> update, IEnumerable<(int first, int second)> rules)
        {
            HashSet<int> pagesToPlace = new(update);
            List<int> newList = [];

            while (pagesToPlace.Count > 0)
            {
                foreach (var page in pagesToPlace)
                {
                    if (!rules.Where(e => pagesToPlace.Contains(e.first) && e.second == page).Any())
                    {
                        newList.Add(page);
                        pagesToPlace.Remove(page);
                        break;
                    }
                }
            }
            return newList;
        }

        public (HashSet<(int first, int second)>, List<List<int>>) ParseInput(string[] input)
        {
            var orderRules = new HashSet<(int first, int second)>();
            int idx = 0;
            // read orderings
            while (input[idx] != "")
            {
                var orderList = input[idx].Split('|').Select(e => int.Parse(e)).ToList();
                orderRules.Add((first: orderList[0], second: orderList[1]));
                idx++;
            }
            idx++;
            var updates = new List<List<int>>();

            // read update sequences
            while (idx < input.Length)
            {
                updates.Add(input[idx].Split(",").Select(e => int.Parse(e)).ToList());
                idx++;
            }
            return (orderRules, updates);
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
