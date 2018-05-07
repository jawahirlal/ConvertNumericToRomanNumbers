using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertToRoman.Service
{
    public interface IRomanConverter
    {
        string Convert(int NumericValue);
    }
}
