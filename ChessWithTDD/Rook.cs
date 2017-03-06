﻿using System;

namespace ChessWithTDD
{
    internal class Rook : Piece
    {
        private Colour _colour;

        public Rook(Colour colour)
        {
            _colour = colour;
        }

        public override Colour Colour
        {
            get
            {
                return _colour;
            }
        }

        public override bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            throw new NotImplementedException();
        }
    }
}