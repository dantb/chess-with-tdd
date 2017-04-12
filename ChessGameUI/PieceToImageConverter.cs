using ChessWithTDD;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ChessGameUI
{
    public class PieceToImageConverter : IValueConverter
    {
        const string ImageFolder = @"C:\Programming\ChessWithTDD\ChessWithTDD\ChessGameUI\PieceImages\";
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
                string fileName = GetFileName(piece);
                return ImageFolder + fileName;
            }
                       
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Converted back";
        }

        private string GetFileName(IPiece piece)
        {
            Colour colour = piece.Colour;
            Colour playerColour = MainWindow.PlayerColour;
            if (piece is Bishop)
            {
                return (colour != playerColour ? BlackBishop : WhiteBishop) + PNGFileExtension;
            }
            else if (piece is Knight)
            {
                return (colour != playerColour ? BlackKnight : WhiteKnight) + PNGFileExtension;
            }
            else if (piece is Rook)
            {
                return (colour != playerColour ? BlackRook : WhiteRook) + PNGFileExtension;
            }
            else if (piece is Queen)
            {
                return (colour != playerColour ? BlackQueen : WhiteQueen) + PNGFileExtension;
            }
            else if (piece is King)
            {
                return (colour != playerColour ? BlackKing : WhiteKing) + PNGFileExtension;
            }
            else if (piece is WhitePawn || piece is BlackPawn)
            {
                return (colour != playerColour ? BlackPawn : WhitePawn) + PNGFileExtension;
            }
            throw new ArgumentException("The piece does not have a valid type.");
        }
    }
}
