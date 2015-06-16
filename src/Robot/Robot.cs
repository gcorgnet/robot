using Robot.Enums;

namespace Robot
{
    public class Robot
    {
        private int? _x;
        private int? _y;
        private Direction _f;

        public int? X { get { return _x; } }

        public int? Y { get { return _y; } }

        public Direction F { get { return _f; } }

        public bool MoveTo(int x, int y, Direction f)
        {
            if (x >= 5 || y >= 5)
            {
                return false; //Ignore commands that would result in a fall
            }

            _x = x;
            _y = y;
            _f = f;

            return true;
        }
    }
}