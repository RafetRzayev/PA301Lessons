
namespace CSharpSyntaxsis
{
    internal struct Point
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public double ToOrigin()
        {
            return Math.Sqrt(_x * _x + _y * _y);
        }

        public double DistanceTo(Point point)
        {
            return Math.Sqrt((_x - point._x) * (_x - point._x) + (_y - point._y) * (_y - point._y));
        }
    }
}
