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
        public int PositionIndex { get; }
        public int Distance { get; }
        public Logic.MoveInteraction MoveInteraction { get; }

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

        public override bool Equals(object obj)
        {
            Move move = (Move) obj;
            if (this.PositionIndex.Equals(move.PositionIndex) && this.Distance.Equals(move.Distance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.PositionIndex ^ this.Distance;
        }
    }
}