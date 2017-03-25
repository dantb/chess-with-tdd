namespace ChessWithTDD
{
    internal class Square : ISquare
    {
        public Square(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public bool HasEnPassantMark { get; set; }

        public bool ContainsPiece { get; set; }

        public IPiece Piece { get; set; }

        public int Col { get; set; }

        public int Row { get; set; }

        public void AddPiece(IPiece piece)
        {
            ContainsPiece = true;
            Piece = piece;
        }
    }
}
