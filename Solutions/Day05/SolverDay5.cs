namespace AoC_2024.Solutions.Day05
{
    public class SolverDay5 : Solver
    {
        private readonly InputService _inputService;
        private readonly Dictionary<string, List<int>> _listCache = [];
        private readonly Dictionary<string, bool> _boolCache = [];
        public SolverDay5(InputService inputService)
        {
            _inputService = inputService;
        }

        public override BigInteger SolvePartOne()
        {
            var input = GetInput();
            var (orderingRules, updates) = ParseInput(input);
            var retVal = 0;
            var nbrValidUpdates = 0;

            foreach (var update in updates)
            {
                // extract only relevant rules
                var relevantRules = orderingRules.Where(r => update.Any(u => u.Equals(r.Item1) || u.Equals(r.Item2)));
                if (IsValidUpdate(update, relevantRules))
                {
                    int midIdx = (update.Count - 1) / 2;
                    retVal += update[midIdx];
                    nbrValidUpdates++;
                }
            }
            Console.WriteLine($"Found {nbrValidUpdates}. There are {updates.Count - nbrValidUpdates} invalid rows.");
            return retVal;
        }

        public override BigInteger SolvePartTwo()
        {
            var input = GetInput();
            var (orderingRules, updates) = ParseInput(input);
            var retVal = 0;
            int nbrFixes = 0;

            foreach (var update in updates)
            {
                // extract only relevant rules
                var relevantRules = orderingRules.Where(r => update.Any(u => u.Equals(r.Item1) || u.Equals(r.Item2)));
                if (!IsValidUpdate(update, relevantRules))
                {
                    Console.WriteLine($"Fix nbr {nbrFixes}");
                    var newUpdate = FixUpdateList(update, relevantRules);
                    int midIdx = (newUpdate.Count - 1) / 2;
                    retVal += newUpdate[midIdx];
                    nbrFixes++;
                }
            }
            return retVal;
        }

        public bool IsValidUpdate(List<int> update, IEnumerable<Tuple<int, int>> rules)
        {
            string cacheKey = GetHashKey(update, rules);
            if (_boolCache.TryGetValue(cacheKey, out var value))
            {
                return value;
            }
            for (int i = 0; i < update.Count; i++)
            {
                for (int j = i + 1; j < update.Count; j++)
                {
                    var firstPage = update[i];
                    var secondPage = update[j];
                    if (rules.Where(r => r.Item1 == secondPage && r.Item2 == firstPage).Any())
                    {
                        _boolCache.Add(cacheKey, false);
                        return false;
                    }
                }
            }
            _boolCache.Add(cacheKey, true);
            return true;
        }
        public string GetHashKey(List<int> update, IEnumerable<Tuple<int, int>> rules)
        {
            return String.Join(",", update) + "|" + String.Join(",", rules);
        }

        public List<int> FixUpdateList(List<int> update, IEnumerable<Tuple<int, int>> rules)
        {
            // worked without caching, but took ~4 min
            string cacheKey = GetHashKey(update, rules);
            if (_listCache.TryGetValue(cacheKey, out var value))
            {
                return value;
            }
            List<int> retList = [];

            for (int i = 0; i < update.Count; i++)
            {
                for (int j = i + 1; j < update.Count; j++)
                {
                    var firstPage = update[i];
                    var secondPage = update[j];
                    if (rules.Where(r => r.Item1 == secondPage && r.Item2 == firstPage).Any())
                    {
                        // switch places of the failing pages
                        var newUpdate = new List<int>(update);
                        newUpdate[i] = update[j];
                        newUpdate[j] = update[i];
                        if (IsValidUpdate(newUpdate, rules))
                        {
                            _listCache.Add(cacheKey, newUpdate);
                            return newUpdate;
                        }
                        return FixUpdateList(newUpdate, rules);
                    }
                }
            }
            return retList;
        }

        public Tuple<List<Tuple<int, int>>, List<List<int>>> ParseInput(string[] input)
        {
            var orderings = new List<Tuple<int, int>>();
            int idx = 0;
            while (input[idx] != "")
            {
                var orderList = input[idx].Split('|').Select(e => int.Parse(e)).ToList();
                orderings.Add(Tuple.Create(orderList[0], orderList[1]));
                idx++;
            }
            idx++;
            var updates = new List<List<int>>();
            while (idx < input.Length)
            {
                updates.Add(input[idx].Split(",").Select(e => int.Parse(e)).ToList());
                idx++;
            }
            return Tuple.Create(orderings, updates);
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
