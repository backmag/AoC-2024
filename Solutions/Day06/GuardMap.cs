
namespace AoC_2024.Solutions.Day06
{
    public class GuardMap
    {
        public HashSet<(int x, int y)> Obstacles;
        private HashSet<(int x, int y)> _startingObstacles;
        public HashSet<(int x, int y, Direction dir)> Visited = [];
        public (int x, int y) MapSize;
        public (int x, int y) Pos;
        public bool Exited = false;
        public Direction Dir;
        public Direction StartDir;
        public (int x, int y) StartPos;
        private static readonly Dictionary<Direction, (int dx, int dy, Direction newDir)> _directionDictionary = new()
        {
                { Direction.Up, (0, -1, Direction.Right) },
                { Direction.Left, (-1, 0, Direction.Up) },
                { Direction.Down, (0, 1, Direction.Left) },
                { Direction.Right, (1, 0, Direction.Down) },
         };

        public GuardMap(string[] input)
        {
            MapSize = (input[0].Length, input.Length);
            (Obstacles, Pos) = InitializeState(input);
            Dir = Direction.Up;
            StartPos = (Pos.x, Pos.y);
            StartDir = Direction.Up;
            _startingObstacles = new HashSet<(int x, int y)>(Obstacles);
        }

        public void ResetToStart()
        {
            Pos = StartPos;
            Dir = StartDir;
            Obstacles = new HashSet<(int x, int y)>(_startingObstacles);
            Visited = [];
        }

        private (HashSet<(int x, int y)>, (int x, int y)) InitializeState(string[] input)
        {
            HashSet<(int x, int y)> obs = [];
            (int, int) pos = (-1, -1);
            for (int row = 0; row < input.Length; row++)
            {
                for (int col = 0; col < input[0].Length; col++)
                {
                    if (input[row][col] == '#')
                    {
                        obs.Add((col, row));
                    }
                    else if (input[row][col] == '^')
                    {
                        pos = (col, row);
                    }
                }
            }
            if (pos == (-1, -1))
            {
                throw new Exception("Didn't find starting position");
            }
            return (obs, pos);
        }

        public void AddObstacle(int x, int y)
        {
            Obstacles.Add((x, y));
        }

        public void DoGuardWalk()
        {
            Exited = false;
            while (Pos.x >= 0 && Pos.x < MapSize.x && Pos.y >= 0 && Pos.y < MapSize.y)
            {
                if (Visited.Contains((Pos.x, Pos.y, Dir)))
                {
                    // been here before, so guard's in a loop
                    return;
                }
                Visited.Add((Pos.x, Pos.y, Dir));
                TakeStep();
            }
            Exited = true;
        }

        private void TakeStep()
        {
            var currentPosChange = _directionDictionary[Dir];
            (int newX, int newY, Direction newDir) = (Pos.x + currentPosChange.dx,
                Pos.y + currentPosChange.dy,
                currentPosChange.newDir);
            if (Obstacles.Contains((newX, newY)))
            {
                Dir = newDir;
            }
            else
            {
                Pos.x = newX;
                Pos.y = newY;
            }
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}

