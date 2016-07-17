namespace Backgammon
{
    public struct Move
    {
        public Move(int positionIndex, int distance, Logic.MoveInteraction moveInteraction)
        {
            PositionIndex = positionIndex;
            Distance = distance;
            MoveInteraction = moveInteraction;
        }
        public int PositionIndex { get; private set; }
        public int Distance { get; private set; }
        public Logic.MoveInteraction MoveInteraction { get; private set; }
    }
}