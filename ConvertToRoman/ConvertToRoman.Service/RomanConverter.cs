using System.Collections.Generic;
using System.Linq;

namespace ConvertToRoman.Service
{
    public class RomanConverter : IRomanConverter
    {
        IDictionary<int, RomanValueMapping> _romanValueMapping;

        public RomanConverter(IRomanValueMappingCollection romanValueMappingCollection)
        {
            _romanValueMapping = romanValueMappingCollection.GetRomanValueMappingCollection();
        }

        public string Convert(int NumericValue)
        {
            return GetRomanString(NumericValue, 1, NumericValue % 10);
        }
        private string GetRomanString(int numericValue, int multiple, int remainder)
        {
            var _romanValues = "{0}";
            RomanValueMapping _next = null;
            var _nextMultiple = multiple * 10;
            var _current = _romanValueMapping[multiple];
            var _times = remainder;

            if (remainder == 4)
            {
                _times = 1;
                _romanValues += _current.MidValue.ToString();
            }
            else if (remainder >= 5 && remainder <= 8)
            {
                _times = remainder - 5;
                _romanValues = _current.MidValue.ToString() + _romanValues;
            }
            else if (remainder == 9)
            {
                _next = _romanValueMapping[_nextMultiple];
                _times = 1;
                _romanValues += _next.RomanValue.ToString();
            }

            _romanValues = string.Format(_romanValues, GetCharMultiples(_current.RomanValue, _times));

            if (numericValue >= _nextMultiple)
            {
                numericValue -= (remainder) * multiple;
                _romanValues = GetRomanString(numericValue, _nextMultiple, (numericValue % (_nextMultiple * 10)) / _nextMultiple) + _romanValues;
            }

            return _romanValues;
        }


        private string GetCharMultiples(char symbol, int times)
        {
            return new string(Enumerable.Repeat(symbol, times).ToArray());
        }

    }
}
