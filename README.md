# Convert Numeric To Roman Numbers

### This project contains the one of the many possible implementation of converting an integer to Roman number representation.

### For further reading on Roman numbers please visit: https://en.wikipedia.org/wiki/Roman_numerals


### To Start with I have defined the mapping for Roman numbers

'''

keyValuePair.Add(1, new RomanValueMapping { Multiple = 1, RomanValue = 'I', MidValue = 'V' });

keyValuePair.Add(10, new RomanValueMapping { Multiple = 10, RomanValue = 'X', MidValue = 'L' });

keyValuePair.Add(100, new RomanValueMapping { Multiple = 100, RomanValue = 'C', MidValue = 'D' });

keyValuePair.Add(1000, new RomanValueMapping { Multiple = 1000, RomanValue = 'M' });

'''

### Later I have used the private function GetRomanString()

_times - represents the times the character should be repeated

_current and _next - represent the mapping from above table e.g. Mutiple 1 and 10

_romanValues - is used to concatenate the value on either side e.g. 4 we have I and V as IV and 6 we have V and I using string.Format

Later I recursively use GetRomanString to iterate through the multiples.

'''

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

'''