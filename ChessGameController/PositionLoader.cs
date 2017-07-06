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
        public void LoadPositionIntoBoard(IBoard board, string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    var lines = File.ReadAllLines(file);
                    foreach (var line in lines)
                    {
                        string[] moves = line.Split(',');
                        string whiteMove = moves[0];
                        string blackMove = moves[1];

                    }
                }
                else
                {
                    throw new PositionLoadingException("Could not find file to load the position from.");
                }
            }
            catch (Exception e)
            {
                string message = "There was a problem loading the position. ";
                if (e is PositionLoadingException)
                {
                    string.Concat(message, e.Message);
                }
                MessageBox.Show(message);
            }
        }

        public class PositionLoadingException : Exception
        {
            public PositionLoadingException(string message) : base(message) { }
        }
    }
}
