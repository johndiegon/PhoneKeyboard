using ChessMovimentControl.Enum;

namespace ChessMovimentControl.Model
{
    public class ChessPieceMoviment
    {
        public ChessPieceMoviment(ChessPieces chessPieces, List<string> moviments)
        {
            ChessPieces = chessPieces;
            Moviments = moviments;
        }

        public ChessPieces ChessPieces { get; set; }
        public List<string> Moviments { get; set; }
    }
}
