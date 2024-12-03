namespace AoC_2024.Solutions.Day01
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne()
        {
            var input = new string[]
            {
"3   4",
"4   3",
"2   5",
"1   3",
"3   9",
"3   3",
            };
            var expected = 11;

            SolverDay1 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = new string[]
            {
"3   4",
"4   3",
"2   5",
"1   3",
"3   9",
"3   3",
            };
            var expected = 31;

            SolverDay1 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}