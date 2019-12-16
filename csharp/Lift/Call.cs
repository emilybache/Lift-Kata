using System.Data;

namespace Lift
{
    public enum Direction
    {
        Up, Down
    }
    public struct Call
    {
        public Direction Direction;
        public int Floor;

        public Call(int floor, Direction direction)
        {
            this.Direction = direction;
            this.Floor = floor;
        }
    }
}