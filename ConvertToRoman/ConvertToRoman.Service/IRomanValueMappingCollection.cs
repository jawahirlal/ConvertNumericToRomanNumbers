using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertToRoman.Service
{
    public interface IRomanValueMappingCollection
    {
        IDictionary<int,RomanValueMapping> GetRomanValueMappingCollection();
    }
}
