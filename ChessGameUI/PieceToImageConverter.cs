using ChessWithTDD;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace ChessGameUI
{
    public class PieceToImageConverter : IValueConverter
    {
        const string ImageFolderRelativePath = @"/../../../ChessGameUI/PieceImages/";
        const string BlackRook = "BlackRook";
        const string BlackKnight = "BlackKnight";
        const string BlackBishop = "BlackBishop";
        const string BlackQueen = "BlackQueen";
        const string BlackKing = "BlackKing";
        const string BlackPawn = "BlackPawn";
        const string WhiteRook = "WhiteRook";
        const string WhiteKnight = "WhiteKnight";
        const string WhiteBishop = "WhiteBishop";
        const string WhiteQueen = "WhiteQueen";
        const string WhiteKing = "WhiteKing";
        const string WhitePawn = "WhitePawn";
        const string PNGFileExtension = ".png";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                IPiece piece = (IPiece) value;
                string fileName = GetFileName(piece) + PNGFileExtension;
                DirectoryInfo pieceImages = new DirectoryInfo(Directory.GetCurrentDirectory() + ImageFolderRelativePath);
                return pieceImages + fileName;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Chess board only uses one way data binding");
        }

        private string GetFileName(IPiece piece)
        {
            Colour pieceColour = piece.Colour;
            if (piece is Bishop)
            {
                return (pieceColour == Colour.Black ? BlackBishop : WhiteBishop);
            }
            else if (piece is Knight)
            {
                return (pieceColour == Colour.Black ? BlackKnight : WhiteKnight);
            }
            else if (piece is Rook)
            {
                return (pieceColour == Colour.Black ? BlackRook : WhiteRook);
            }
            else if (piece is Queen)
            {
                return (pieceColour == Colour.Black ? BlackQueen : WhiteQueen);
            }
            else if (piece is King)
            {
                return (pieceColour == Colour.Black ? BlackKing : WhiteKing);
            }
            else if (piece is WhitePawn || piece is BlackPawn)
            {
                return (pieceColour == Colour.Black ? BlackPawn : WhitePawn);
            }
            throw new ArgumentException("The piece does not have a valid type.");
        }
    }
}
