using System.Collections.Generic;
using System.IO;

namespace ChessWithTDD
{
    /// <summary>
    /// Saves the current position of a board to a specified file
    /// </summary>
    public class PositionSaver
    {
        /// <summary>
        /// Saves the current position of the board (i.e the sequence of moves that achieved it's position) to the file path specified
        /// </summary>
        /// <returns>True if the board's position was saved successfully, false otherwise.</returns>
        public bool SavePositionFromBoard(IBoard board, string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                    string[] lines = GetAlgebraicNotationMovesFromBoardReadyForFile(board);
                    File.WriteAllLines(filePath, lines);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private string[] GetAlgebraicNotationMovesFromBoardReadyForFile(IBoard board)
        {
            List<string> moves = new List<string>(board.OrderedMoveData.Count);
            AlgebraicNotationGenerator generator = new AlgebraicNotationGenerator();
            foreach (var move in board.OrderedMoveData)
            {
                string moveInNotation = generator.Convert(move);
                moves.Add(moveInNotation);
            }

            bool evenNumberOfMoves = moves.Count % 2 == 0;
            int nearestEven = evenNumberOfMoves ? moves.Count : moves.Count + 1;
            int linesNeeded = nearestEven / 2;
            string[] lines = new string[linesNeeded];
            for (int i = 0; i < linesNeeded - 1; i++)
            {
                string line = string.Concat(moves[i * 2], ",", moves[(i * 2) + 1]);
                lines[i] = line;
            }
            //final line
            string finalLine = evenNumberOfMoves
                ? string.Concat(moves[moves.Count - 2], ",", moves[moves.Count - 1])
                : moves[moves.Count - 1];
            lines[lines.Length - 1] = finalLine;
            return lines;
        }
    }
}
