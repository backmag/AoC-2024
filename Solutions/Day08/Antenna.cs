
namespace AoC_2024.Solutions.Day08
{
    public class Antenna
    {
        public int PosX;
        public int PosY;
        public int MaxX;
        public int MaxY;
        public char Frequency;

        public Antenna(int posX, int posY, char frequency, int maxX, int maxY)
        {
            PosX = posX;
            PosY = posY;
            Frequency = frequency;
            MaxX = maxX;
            MaxY = maxY;
        }

        public IEnumerable<Antenna> FindAntinodes(Antenna other)
        {
            List<Antenna> result = [];
            var dx = this.PosX - other.PosX;
            var dy = this.PosY - other.PosY;
            var newX = PosX + dx;
            var newY = PosY + dy;
            if (IsInGrid(newX, newY))
            {
                result.Add(new Antenna(newX, newY, Frequency, MaxX, MaxY));
            }
            newX = PosX - 2 * dx;
            newY = PosY - 2 * dy;
            if (IsInGrid(newX, newY))
            {
                result.Add(new Antenna(newX, newY, Frequency, MaxX, MaxY));
            }

            return result;
        }
        public IEnumerable<Antenna> FindAntinodesWithHarmonics(Antenna other)
        {
            List<Antenna> result = [];
            var dx = this.PosX - other.PosX;
            var dy = this.PosY - other.PosY;

            // go in first direction
            var newX = this.PosX;
            var newY = this.PosY;
            while (IsInGrid(newX, newY))
            {
                result.Add(new Antenna(newX, newY, Frequency, MaxX, MaxY));
                newX = newX + dx;
                newY = newY + dy;
            }

            // go in other direction
            newX = this.PosX - dx;
            newY = this.PosY - dy;
            while (IsInGrid(newX, newY))
            {
                result.Add(new Antenna(newX, newY, Frequency, MaxX, MaxY));
                newX = newX - dx;
                newY = newY - dy;
            }
            return result;
        }

        public bool IsInGrid(int x, int y)
        {
            return x >= 0 && x <= MaxX && y >= 0 && y <= MaxY;
        }
    }
}
