namespace ChessWithTDD.Tests.TestHelpers
{
    internal class AlgebraicNotationGeneratorTestParameters
    {
        internal static object[] PawnMoveAndCaptureGenerationTestCases =
        {
            //double move up
            new object[] { "a2-a4", new Move(1, 0, 3, 0), false },
            new object[] { "b2-b4", new Move(1, 1, 3, 1), false },
            new object[] { "c2-c4", new Move(1, 2, 3, 2), false },
            new object[] { "d2-d4", new Move(1, 3, 3, 3), false },
            new object[] { "e2-e4", new Move(1, 4, 3, 4), false },
            new object[] { "f2-f4", new Move(1, 5, 3, 5), false },
            new object[] { "g2-g4", new Move(1, 6, 3, 6), false },
            new object[] { "h2-h4", new Move(1, 7, 3, 7), false },

            //double move down
            new object[] { "a7-a5", new Move(6, 0, 4, 0), false },
            new object[] { "b7-b5", new Move(6, 1, 4, 1), false },
            new object[] { "c7-c5", new Move(6, 2, 4, 2), false },
            new object[] { "d7-d5", new Move(6, 3, 4, 3), false },
            new object[] { "e7-e5", new Move(6, 4, 4, 4), false },
            new object[] { "f7-f5", new Move(6, 5, 4, 5), false },
            new object[] { "g7-g5", new Move(6, 6, 4, 6), false },
            new object[] { "h7-h5", new Move(6, 7, 4, 7), false },

            //single move up
            new object[] { "a2-a3", new Move(1, 0, 2, 0), false },
            new object[] { "b2-b3", new Move(1, 1, 2, 1), false },
            new object[] { "c2-c3", new Move(1, 2, 2, 2), false },
            new object[] { "d2-d3", new Move(1, 3, 2, 3), false },
            new object[] { "e2-e3", new Move(1, 4, 2, 4), false },
            new object[] { "f2-f3", new Move(1, 5, 2, 5), false },
            new object[] { "g2-g3", new Move(1, 6, 2, 6), false },
            new object[] { "h2-h3", new Move(1, 7, 2, 7), false },

            //single move down
            new object[] { "a7-a6", new Move(6, 0, 5, 0), false },
            new object[] { "b7-b6", new Move(6, 1, 5, 1), false },
            new object[] { "c7-c6", new Move(6, 2, 5, 2), false },
            new object[] { "d7-d6", new Move(6, 3, 5, 3), false },
            new object[] { "e7-e6", new Move(6, 4, 5, 4), false },
            new object[] { "f7-f6", new Move(6, 5, 5, 5), false },
            new object[] { "g7-g6", new Move(6, 6, 5, 6), false },
            new object[] { "h7-h6", new Move(6, 7, 5, 7), false },

            //capture up
            new object[] { "a2xb3", new Move(1, 0, 2, 1), true },
            new object[] { "b2xc3", new Move(1, 1, 2, 2), true },
            new object[] { "c2xd3", new Move(1, 2, 2, 3), true },
            new object[] { "d2xe3", new Move(1, 3, 2, 4), true },
            new object[] { "e2xf3", new Move(1, 4, 2, 5), true },
            new object[] { "f2xg3", new Move(1, 5, 2, 6), true },
            new object[] { "g2xh3", new Move(1, 6, 2, 7), true },
            new object[] { "h2xg3", new Move(1, 7, 2, 6), true },
        };

        internal static object[] PawnMoveAndCaptureGenerationInvalidMoveTestCases =
        {
            new object[] { "", new Move(-1, 7, 5, 7), false },
            new object[] { "", new Move(6, -1, 5, 7), true },
            new object[] { "", new Move(6, 2, -1, 7), false},
            new object[] { "", new Move(6, 3, 5, -1), true },
            new object[] { "", new Move(8, 7, 5, 7), false },
            new object[] { "", new Move(6, 8, 5, 7), true },
            new object[] { "", new Move(6, 2, 8, 7), false},
            new object[] { "", new Move(6, 3, 5, 8), true },
        };

        internal static object[] PawnGenerationCheckAndMateTestCases =
        {
            new object[] { "a2-b3", new Move(1, 0, 2, 1), false, false },
            new object[] { "b2-c3", new Move(1, 1, 2, 2), false, false },
            new object[] { "c2-d3+", new Move(1, 2, 2, 3), true, false },
            new object[] { "d2-e3+", new Move(1, 3, 2, 4), true, false },
            new object[] { "e2-f3#", new Move(1, 4, 2, 5), true, true },
            new object[] { "f2-g3#", new Move(1, 5, 2, 6), true, true },
        };

        internal static object[] PawnGenerationCheckAndMateInvalidTestCases =
        {
            //empty string should be returned for invalid check/mate combination
            new object[] { "", new Move(1, 5, 2, 6), false, true },
            new object[] { "", new Move(6, 7, 5, 7), false, true },
        };

        ///// <summary>
        ///// Copied from pawn test cases, just there should be a character prepended. These all behave
        ///// the same except for the first character.
        ///// </summary>
        internal static object[] NonPawnMoveAndCaptureGenerationTestCases =
        {
            //king
            new object[] { "Ka2-a4", new Move(1, 0, 3, 0), false, new King(Colour.Invalid) },
            new object[] { "Kb2-b4", new Move(1, 1, 3, 1), false, new King(Colour.Invalid) },
            new object[] { "Kc2-c4", new Move(1, 2, 3, 2), false, new King(Colour.Invalid) },
            new object[] { "Kd2-d4", new Move(1, 3, 3, 3), false, new King(Colour.Invalid) },
            new object[] { "Ke2xe4", new Move(1, 4, 3, 4), true, new King(Colour.Invalid) },
            new object[] { "Kf2xf4", new Move(1, 5, 3, 5), true, new King(Colour.Invalid) },
            new object[] { "Kg2xg4", new Move(1, 6, 3, 6), true, new King(Colour.Invalid) },
            new object[] { "Kh2xh4", new Move(1, 7, 3, 7), true, new King(Colour.Invalid) },

            //queen
            new object[] { "Qa7-a5", new Move(6, 0, 4, 0), false, new Queen(Colour.Invalid) },
            new object[] { "Qb7-b5", new Move(6, 1, 4, 1), false, new Queen(Colour.Invalid) },
            new object[] { "Qc7-c5", new Move(6, 2, 4, 2), false, new Queen(Colour.Invalid) },
            new object[] { "Qd7-d5", new Move(6, 3, 4, 3), false, new Queen(Colour.Invalid) },
            new object[] { "Qe7xe5", new Move(6, 4, 4, 4), true, new Queen(Colour.Invalid) },
            new object[] { "Qf7xf5", new Move(6, 5, 4, 5), true, new Queen(Colour.Invalid) },
            new object[] { "Qg7xg5", new Move(6, 6, 4, 6), true, new Queen(Colour.Invalid) },
            new object[] { "Qh7xh5", new Move(6, 7, 4, 7), true, new Queen(Colour.Invalid) },

            //rook
            new object[] { "Ra2-a3", new Move(1, 0, 2, 0), false, new Rook(Colour.Invalid) },
            new object[] { "Rb2-b3", new Move(1, 1, 2, 1), false, new Rook(Colour.Invalid) },
            new object[] { "Rc2-c3", new Move(1, 2, 2, 2), false, new Rook(Colour.Invalid) },
            new object[] { "Rd2-d3", new Move(1, 3, 2, 3), false, new Rook(Colour.Invalid) },
            new object[] { "Re2xe3", new Move(1, 4, 2, 4), true, new Rook(Colour.Invalid) },
            new object[] { "Rf2xf3", new Move(1, 5, 2, 5), true, new Rook(Colour.Invalid) },
            new object[] { "Rg2xg3", new Move(1, 6, 2, 6), true, new Rook(Colour.Invalid) },
            new object[] { "Rh2xh3", new Move(1, 7, 2, 7), true, new Rook(Colour.Invalid) },

            //bishop
            new object[] { "Ba7-a6", new Move(6, 0, 5, 0), false, new Bishop(Colour.Invalid) },
            new object[] { "Bb7-b6", new Move(6, 1, 5, 1), false, new Bishop(Colour.Invalid) },
            new object[] { "Bc7-c6", new Move(6, 2, 5, 2), false, new Bishop(Colour.Invalid) },
            new object[] { "Bd7-d6", new Move(6, 3, 5, 3), false, new Bishop(Colour.Invalid) },
            new object[] { "Be7xe6", new Move(6, 4, 5, 4), true, new Bishop(Colour.Invalid) },
            new object[] { "Bf7xf6", new Move(6, 5, 5, 5), true, new Bishop(Colour.Invalid) },
            new object[] { "Bg7xg6", new Move(6, 6, 5, 6), true, new Bishop(Colour.Invalid) },
            new object[] { "Bh7xh6", new Move(6, 7, 5, 7), true, new Bishop(Colour.Invalid) },

            //knight
            new object[] { "Na2-b3", new Move(1, 0, 2, 1), false, new Knight(Colour.Invalid) },
            new object[] { "Nb2-c3", new Move(1, 1, 2, 2), false, new Knight(Colour.Invalid) },
            new object[] { "Nc2-d3", new Move(1, 2, 2, 3), false, new Knight(Colour.Invalid) },
            new object[] { "Nd2-e3", new Move(1, 3, 2, 4), false, new Knight(Colour.Invalid) },
            new object[] { "Ne2xf3", new Move(1, 4, 2, 5), true, new Knight(Colour.Invalid) },
            new object[] { "Nf2xg3", new Move(1, 5, 2, 6), true, new Knight(Colour.Invalid) },
            new object[] { "Ng2xh3", new Move(1, 6, 2, 7), true, new Knight(Colour.Invalid) },
            new object[] { "Nh2xg3", new Move(1, 7, 2, 6), true, new Knight(Colour.Invalid) },

            //special moves
            new object[] { "Qa2xb3+", new Move(1, 0, 2, 1), false, new King(Colour.Invalid) },
            new object[] { "Kb2xc3#", new Move(1, 1, 2, 2), false, new King(Colour.Invalid) },
            new object[] { "Ng7-g6+", new Move(6, 6, 5, 6), false, new King(Colour.Invalid) },
            new object[] { "Bh7-h6#", new Move(6, 7, 5, 7), false, new King(Colour.Invalid) },
        };


        internal static object[] NonPawnMoveAndCaptureGenerationInvalidMoveTestCases =
        {
            new object[] { "", new Move(-1, 7, 5, 7), false, new King(Colour.Invalid) },
            new object[] { "", new Move(6, -1, 5, 7), true, new King(Colour.Invalid) },
            new object[] { "", new Move(6, 2, -1, 7), false, new King(Colour.Invalid) },
            new object[] { "", new Move(6, 3, 5, -1), true, new King(Colour.Invalid) },
            new object[] { "", new Move(8, 7, 5, 7), false, new King(Colour.Invalid) },
            new object[] { "", new Move(6, 8, 5, 7), true, new King(Colour.Invalid) },
            new object[] { "", new Move(6, 2, 8, 7), false, new King(Colour.Invalid) },
            new object[] { "", new Move(6, 3, 5, 8), true, new King(Colour.Invalid) },
        };

        internal static object[] NonPawnGenerationCheckAndMateTestCases =
        {
            new object[] { "Ka2-b3", new Move(1, 0, 2, 1), false, false, new King(Colour.Invalid) },
            new object[] { "Qb2-c3", new Move(1, 1, 2, 2), false, false, new Queen(Colour.Invalid) },
            new object[] { "Rc2-d3+", new Move(1, 2, 2, 3), true, false, new Rook(Colour.Invalid) },
            new object[] { "Nd2-e3+", new Move(1, 3, 2, 4), true, false, new Knight(Colour.Invalid) },
            new object[] { "Be2-f3#", new Move(1, 4, 2, 5), true, true, new Bishop(Colour.Invalid) },
            new object[] { "Kf2-g3#", new Move(1, 5, 2, 6), true, true, new King(Colour.Invalid) },
        };

        internal static object[] NonPawnGenerationCheckAndMateInvalidTestCases =
        {
            //empty string should be returned for invalid check/mate combination
            new object[] { "", new Move(1, 5, 2, 6), false, true, new Queen(Colour.Invalid) },
            new object[] { "", new Move(6, 7, 5, 7), false, true, new Queen(Colour.Invalid) },
        };
    }
}