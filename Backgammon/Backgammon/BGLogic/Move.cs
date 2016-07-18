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

            //A very specific condition whereby a Move is equal to another Move if starting position is the same, 
            //and resulting position is out (but move distance could be different).
            if (this.PositionIndex.Equals(move.PositionIndex) && this.MoveInteraction.Equals(move.MoveInteraction) &&
                this.MoveInteraction == Logic.MoveInteraction.Out)
            {
                return true;
            }
            else if (this.PositionIndex.Equals(move.PositionIndex) && this.Distance.Equals(move.Distance))
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