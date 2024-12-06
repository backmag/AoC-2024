using AoC_2024.Solutions.Day06;

namespace AoC_2024.Solutions.Day6
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne()
        {
            var input = InputService.SplitToArray(@"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...");
            var expected = 41;

            SolverDay6 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMapCreation()
        {
            var input = InputService.SplitToArray(@"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...");
            var expectedDirection = Direction.Up;
            var expectedNbrObstacles = 8;

            GuardMap guardMap = new(input);
            var actualDirection = guardMap.Dir;
            var actualNbrObstacles = guardMap.Obstacles.Count();

            Assert.Equal(expectedDirection, actualDirection);
            Assert.Equal(expectedNbrObstacles, actualNbrObstacles);
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = InputService.SplitToArray(@"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...");

            var expected = 6;

            SolverDay6 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
