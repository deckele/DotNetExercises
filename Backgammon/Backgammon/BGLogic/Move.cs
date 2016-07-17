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

        public override string ToString()
        {
            switch (MoveInteraction)
            {
                case Logic.MoveInteraction.Eat:
                    return string.Format($"{PositionIndex, 4}  :  {PositionIndex + Distance, 2}");
                case Logic.MoveInteraction.JailEat:
                    return string.Format($"Jail  :  {PositionIndex + Distance, 2}");
                case Logic.MoveInteraction.JailMove:
                    return string.Format($"Jail --> {PositionIndex + Distance, 2}");
                case Logic.MoveInteraction.Out:
                    return string.Format($"{PositionIndex, 4} --> out");
                case Logic.MoveInteraction.Move:
                default:
                    return string.Format($"{PositionIndex, 4} --> {PositionIndex + Distance, 2}");
            }         

        }
    }
}