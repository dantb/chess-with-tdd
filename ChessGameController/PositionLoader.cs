using ChessWithTDD;
using System;
using System.IO;
using System.Windows;

namespace ChessGameController
{
    /// <summary>
    /// The position loader will load a position into a board from a text file
    /// </summary>
    public class PositionLoader
    {
        /// <summary>
        /// <para>Loads a position into the board by applying consecutive moves defined in a text file. The 
        /// format of the file should be as follows:</para> 
        /// 
        /// <para>a1-a3,a6-a5</para>
        /// <para>c1-c2,e6-e3</para>
        /// <para>Kb0-a2,f6-f4</para>
        /// 
        /// So that's comma separated moves for each turn, with each line representing a single turn.
        /// For full formatting details see <see cref="AlgebraicNotationParser"/>
        /// </summary>
        /// <param name="board">The board to apply moves to in order to load a position</param>
        /// <param name="file">File to load the moves to apply to the board</param>
        public bool LoadPositionIntoBoard(IBoard board, string file)
        {
            try
            {
                AlgebraicNotationParser parser = new AlgebraicNotationParser();

                if (File.Exists(file))
                {
                    var lines = File.ReadAllLines(file);
                    foreach (var line in lines)
                    {
                        string[] moves = line.Split(',');
                        IMove whiteMove = parser.Parse(moves[0]);
                        IMove blackMove = parser.Parse((moves[1]));
                        TryToApplyMove(board, moves, whiteMove);
                        TryToApplyMove(board, moves, blackMove);
                    }
                }
                else
                {
                    throw new PositionLoadingException("Could not find file to load the position from.");
                }
                return true;
            }
            catch (Exception e)
            {
                string message = "There was a problem loading the position. ";
                if (e is PositionLoadingException)
                {
                    message += e.Message;
                }
                MessageBox.Show(message);
                return false;
            }
        }

        private static void TryToApplyMove(IBoard board, string[] moves, IMove theMove)
        {
            if (theMove != null)
            {
                //parsed correctly
                ISquare whiteFrom = board.GetSquare(theMove.FromRow, theMove.FromCol);
                ISquare whiteTo = board.GetSquare(theMove.ToRow, theMove.ToCol);
                if (board.MoveIsValid(whiteFrom, whiteTo))
                {
                    board.Apply(whiteFrom, whiteTo);
                }
                else
                {
                    throw new PositionLoadingException($"The move from ({theMove.FromRow},{theMove.FromCol}) " +
                        $"to ({theMove.ToRow},{theMove.ToCol}) is invalid on this board.");
                }
            }
            else
            {
                throw new PositionLoadingException($"Failed to parse the move {moves[0]} correctly.");
            }
        }

        public class PositionLoadingException : Exception
        {
            public PositionLoadingException(string message) : base(message) { }
        }
    }
}
