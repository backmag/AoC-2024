namespace AoC_2024.Solutions.Day04
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne()
        {
            var input = InputService.SplitToArray(@"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX");
            var expected = 18;

            SolverDay4 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestSingleRowEntries()
        {

            int col = 0;
            int row = 0;

            int[] expectedValues = [0, 1, 0, 1];
            string[][] inputs = [["XMA"], ["XMAS"], ["SMAX"], ["XMASX"]];
            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var expected = expectedValues[i];

                SolverDay4 solver = new(new InputService(""));

                var actual = solver.DoWordSearch(input, row, col);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void TestMultiRowEntries()
        {
            int col = 0;
            int row = 3;

            int[] expectedValues = [1];
            string[][] inputs = [
                ["AAAS",
                "AAAA",
                "AMAA",
                "XAAA"]];
            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var expected = expectedValues[i];

                SolverDay4 solver = new(new InputService(""));

                var actual = solver.DoWordSearch(input, row, col);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = InputService.SplitToArray(@"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX");

            var expected = 9;

            SolverDay4 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
