namespace Backgammon
{
    public struct Move
    {
        public Move(int positionIndex, int distance)
        {
            PositionIndex = positionIndex;
            Distance = distance;
        }
        public int PositionIndex { get; private set; }
        public int Distance { get; private set; }
    }
}