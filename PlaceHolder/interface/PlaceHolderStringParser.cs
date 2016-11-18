using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Centaline.Framework.Kernel.placeholder.Interface
{
    public interface PlaceHolderStringParser
    {
        PlaceHolderEnsurer getPlaceHolderEnsurer();

        PlaceHolderAnalyzer getPlaceHolderAnalyzer();

        PlaceHolderValidator getPlaceHolderValidator();

        string parse<TPlaceHolderScheme>(string content, TPlaceHolderScheme placeHolderScheme)
            where TPlaceHolderScheme : PlaceHolderScheme;


    }
}
