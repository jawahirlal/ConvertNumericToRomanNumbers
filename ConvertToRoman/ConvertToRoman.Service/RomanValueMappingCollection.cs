using System;
using System.Collections.Generic;

using System.Text;

namespace ConvertToRoman.Service
{
    public class RomanValueMappingCollection : IRomanValueMappingCollection
    {
        IDictionary<int,RomanValueMapping> keyValuePair;
        public RomanValueMappingCollection()
        {
            loadValueCollection();
        }
        private void loadValueCollection()
        {
            keyValuePair = new Dictionary<int,RomanValueMapping>();

            keyValuePair.Add(1, new RomanValueMapping { Multiple = 1, RomanValue = 'I', MidValue = 'V' });
            keyValuePair.Add(10, new RomanValueMapping { Multiple = 10, RomanValue = 'X', MidValue = 'L' });
            keyValuePair.Add(100, new RomanValueMapping { Multiple = 100, RomanValue = 'C', MidValue = 'D' });
            keyValuePair.Add(1000, new RomanValueMapping { Multiple = 1000, RomanValue = 'M' });

        }
        public IDictionary<int,RomanValueMapping> GetRomanValueMappingCollection()
        {
            return keyValuePair;
        }
    }
}
