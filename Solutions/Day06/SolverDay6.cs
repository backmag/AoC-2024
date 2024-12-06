namespace AoC_2024.Solutions.Day06
{
    public class SolverDay6 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay6(InputService inputService)
        {
            _inputService = inputService;
        }

        public override BigInteger SolvePartOne()
        {
            var input = GetInput();
            GuardMap guardMap = new(input);
            guardMap.DoGuardWalk();
            var visitedTiles = guardMap.Visited.Select(e => (e.x, e.y)).Distinct().Count();
            return visitedTiles;
        }

        public override BigInteger SolvePartTwo()
        {
            var input = GetInput();
            GuardMap guardMap = new(input);
            guardMap.DoGuardWalk();
            var obstacleCandidates = guardMap.Visited.
                Where(e => !(e.x, e.y).Equals((guardMap.StartPos.x, guardMap.StartPos.y))).
                Select(e => (e.x, e.y)).Distinct();
            guardMap.ResetToStart();

            var validCandidates = 0;
            foreach (var candidate in obstacleCandidates)
            {
                guardMap.AddObstacle(candidate.x, candidate.y);
                guardMap.DoGuardWalk();
                if (!guardMap.Exited)
                {
                    // guard is in a loop, successful obstacle
                    validCandidates++;
                }
                guardMap.ResetToStart();
            }
            return validCandidates;
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
