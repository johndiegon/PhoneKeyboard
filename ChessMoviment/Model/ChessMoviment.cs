using ChessMovimentControl.Enum;

namespace ChessMovimentControl.Model
{
    public readonly struct ChessMoviment
    {
        private readonly List<ChessPieceMoviment> _chessPieceMoviments;

        public ChessMoviment()
        {
            _chessPieceMoviments = new List<ChessPieceMoviment>();
            _chessPieceMoviments.Add(new ChessPieceMoviment(ChessPieces.Pawn, new List<string> { "41" , "52","63", "14", "25", "36" }));
            _chessPieceMoviments.Add(new ChessPieceMoviment(ChessPieces.Knight, new List<string> { "6541", "1478", "0256" }));
            _chessPieceMoviments.Add(new ChessPieceMoviment(ChessPieces.Bishop, new List<string> { "01", "357", "48", "26" }));
            _chessPieceMoviments.Add(new ChessPieceMoviment(ChessPieces.Rook, new List<string> { "8520", "789", "963" }));
            _chessPieceMoviments.Add(new ChessPieceMoviment(ChessPieces.Queen, new List<string> { "0258", "159", "654", "03", "95" }));
            _chessPieceMoviments.Add(new ChessPieceMoviment(ChessPieces.King, new List<string> { "54", "15", "89", "42", "02" }));

        }

        public bool IsMoviment(string moviment)
        {
            return _chessPieceMoviments.Any(x => x.Moviments.Any( m => m.StartsWith(moviment)));
        }
    }
}
