﻿using System;

namespace ChessWithTDD
{
    public class Bishop : IPiece
    {
        private Colour _colour;

        public Bishop(Colour colour)
        {
            _colour = colour;
        }

        public Colour Colour
        {
            get
            {
                return _colour;
            }
        }

        public bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            throw new NotImplementedException();
        }
    }
}