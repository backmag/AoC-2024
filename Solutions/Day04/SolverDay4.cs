using System.Data;
using System.Runtime.ExceptionServices;

namespace AoC_2024.Solutions.Day04
{
    public class SolverDay4 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay4(InputService inputService)
        {
            _inputService = inputService;
        }

        public override BigInteger SolvePartOne()
        {
            var input = GetInput();
            int nbrOccurences = 0;

            for (int row = 0; row < input[0].Length; row++)
            {
                for (int col = 0; col < input.Length; col++)
                {
                    if (input[row][col].Equals('X'))
                    {
                        nbrOccurences += DoWordSearch(input, row, col);
                    }
                }
            }
            return nbrOccurences;
        }

        public override BigInteger SolvePartTwo()
        {
            var input = GetInput();
            int nbrOccurences = 0;

            for (int row = 0; row < input[0].Length; row++)
            {
                for (int col = 0; col < input.Length; col++)
                {
                    if ("MS".Contains(input[row][col]))
                    {
                        nbrOccurences += DoCrossSearch(input, row, col);
                    }
                }
            }
            return nbrOccurences;
        }

        public int DoCrossSearch(string[] words, int row, int col)
        {
            int maxRowLength = words.Length;
            int maxColLength = words[0].Length;
            int crossSize = 3;

            if (row + crossSize - 1 >= maxRowLength || col + crossSize - 1 >= maxColLength)
            {
                return 0;
            }
            string upLeftDownRight = ExpandWord(words, row, col, 1, 1, crossSize);
            string downLeftUpRight = ExpandWord(words, row + 2, col, -1, 1, crossSize);
            if ((upLeftDownRight.Equals("SAM") || upLeftDownRight.Equals("MAS"))
                && (downLeftUpRight.Equals("SAM") || downLeftUpRight.Equals("MAS")))
            {
                return 1;
            }
            return 0;
        }


        public int DoWordSearch(string[] words, int row, int col)
        {
            string soughtWord = "XMAS";
            int maxRowLength = words.Length;
            int maxColLength = words[0].Length;
            int wordLength = soughtWord.Length;
            var directions = new[]
            {
                (0,1),   // check to right
                (-1,1),  // check diagonally up right
                (-1,0),  // check straight up,
                (-1,-1), // check diagonally up left
                (0,-1),  // check to left
                (1,-1),  // check diagonally down left
                (1,0),   // check straight down
                (1,1),   // check diagonally down right
            };
            int retVal = 0;

            foreach (var (rowDirection, colDirection) in directions)
            {
                int endRow = row + rowDirection * (wordLength - 1);
                int endCol = col + colDirection * (wordLength - 1);
                if (endRow >= 0 && endRow < maxRowLength && endCol >= 0 && endCol < maxColLength)
                {
                    if (ExpandWord(words, row, col, rowDirection, colDirection, wordLength).Equals(soughtWord))
                    {
                        retVal++;
                    }
                }
            }
            return retVal;
        }

        public string ExpandWord(string[] words, int row, int col, int rowIncrement, int colIncrement, int wordLength)
        {
            return string.Concat(Enumerable.Range(0, wordLength).Select(i => words[row + i * rowIncrement][col + i * colIncrement]));
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
