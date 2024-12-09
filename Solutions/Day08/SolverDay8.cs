using System.Data;

namespace AoC_2024.Solutions.Day08
{
    public class SolverDay8 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay8(InputService inputService)
        {
            _inputService = inputService;
        }

        public override BigInteger SolvePartOne()
        {
            var input = GetInput();
            IEnumerable<Antenna> antennas = ReadAntennas(input);
            (int maxX, int maxY) = (input[0].Length - 1, input.Length - 1);
            List<Antenna> antinodes = [];

            foreach (var frequency in antennas.Select(e => e.Frequency).Distinct())
            {
                var antennaGroup = antennas.Where(e => e.Frequency.Equals(frequency)).ToList();

                for (int i = 0; i < antennaGroup.Count; i++)
                {
                    for (int j = i; j < antennaGroup.Count; j++)
                    {
                        if (i != j)
                        {
                            antinodes.AddRange(antennaGroup[i].FindAntinodes(antennaGroup[j]));
                        }
                    }
                }
            }
            var uniqueLocations = antinodes
                .Select(e => (e.PosX, e.PosY))
                .Distinct()
                .Count();
            return uniqueLocations;
        }

        public override BigInteger SolvePartTwo()
        {
            var input = GetInput();
            IEnumerable<Antenna> antennas = ReadAntennas(input);
            (int maxX, int maxY) = (input[0].Length - 1, input.Length - 1);
            List<Antenna> antinodes = [];

            foreach (var frequency in antennas.Select(e => e.Frequency).Distinct())
            {
                var antennaGroup = antennas.Where(e => e.Frequency.Equals(frequency)).ToList();

                for (int i = 0; i < antennaGroup.Count; i++)
                {
                    for (int j = i; j < antennaGroup.Count; j++)
                    {
                        if (i != j)
                        {
                            antinodes.AddRange(antennaGroup[i].FindAntinodesWithHarmonics(antennaGroup[j]));
                        }
                    }
                }
            }
            var uniqueLocations = antinodes
                .Select(e => (e.PosX, e.PosY))
                .Distinct()
                .Count();
            return uniqueLocations;
        }

        public static IEnumerable<Antenna> ReadAntennas(string[] input)
        {
            var retList = new List<Antenna>();
            for (int row = 0; row < input.Length; row++)
            {
                for (int col = 0; col < input[0].Length; col++)
                {
                    if (input[row][col] != '.')
                    {
                        retList.Add(new Antenna(col, row, input[row][col], input[0].Length - 1, input.Length - 1));
                    }
                }
            }
            return retList;
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
