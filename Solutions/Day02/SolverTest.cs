namespace AoC_2024.Solutions.Day02
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne()
        {
            var input = new string[]
            {
"7 6 4 2 1",
"1 2 7 8 9",
"9 7 6 2 1",
"1 3 2 4 5",
"8 6 4 4 1",
"1 3 6 7 9",
            };
            var expected = 2;

            SolverDay2 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = new string[]
            {
"7 6 4 2 1",
"1 2 7 8 9",
"9 7 6 2 1",
"1 3 2 4 5",
"8 6 4 4 1",
"1 3 6 7 9",
            };
            var expected = 4;

            SolverDay2 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}