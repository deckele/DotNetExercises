﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon;

namespace Backgammon
{
    public interface IPlayer
    {
        Dice Roll(CheckerColor currentPlayer, Random randomDieGen);
        Move ChooseMove(List<int> diceNumbersList, List<Move> legalMoves, CheckerColor currentPlayer, Game backgammon);
    }
}
