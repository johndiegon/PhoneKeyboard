using ChessMovimentControl.Model;
using System.Text;

namespace ChessMovimentControl.Service
{
    public class SeriesNumber
    {
        private readonly StringBuilder _digits;
        private readonly ChessMoviment _chessMoviments;
        private readonly char[] _invalidFirstDigit;
        const int _seriesSize = 7;
        const int _firstSeriesSize = 3;
        private int _startingPointMovement = 1;

        public SeriesNumber()
        {
            _digits = new StringBuilder();
            _chessMoviments = new ChessMoviment();
            _invalidFirstDigit = new [] { '0', '1' };
        }

        private bool IsFirstNumber() => _digits.Length == 0;
        
        public bool IsFinished() => _digits.Length == _seriesSize;

        public void AddNumber(char digit)
        {
            if (this.IsFinished())
                return;

            if (!this.IsValidDigit(digit))
                return;
            
            if(this.IsFirstNumber())
            {
                _digits.Append(digit);   
                return;
            }
            
            var digits = new StringBuilder().Append(_digits.ToString());
            digits.Append(digit);

            if (_chessMoviments.IsMoviment(digits.ToString()[(_startingPointMovement - 1)..])
               && IsValidDigit(digit))
            {
                _digits.Append(digit);
                return;
            }

            if(_digits.Length > 0)
            {
                digits.Clear();
                digits.Append(_digits.ToString()[(_digits.Length - 1)..]);
                digits.Append(digit);

                if (_chessMoviments.IsMoviment(digits.ToString())
                   && IsValidDigit(digit))
                {
                    _startingPointMovement = _digits.Length - 1;
                    _digits.Append(digit);
                    return;
                }

            }
        }

        public string Get()
        {
            switch (_digits.Length)
            {
                case 0:
                    return "";
                case < _seriesSize:
                    return _digits.ToString();
                default:
                    return $"{_digits.ToString()[.._firstSeriesSize]}-{_digits.ToString()[_firstSeriesSize..]}";
            }
        }

        public void Clear() => _digits.Clear();

        private bool IsValidDigit(char digit)
        {
            try
            {
                if (!Char.IsNumber(digit))
                    return false;

                if (this.IsFirstNumber())
                    return !_invalidFirstDigit.Contains(digit);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
