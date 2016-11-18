using Com.Centaline.Framework.Kernel.placeholder.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Centaline.Framework.Kernel.placeholder.Interface
{
    public interface PlaceHolderAnalyzer
    {
      
        String analyse<TPlaceHolderScheme>(String source, TPlaceHolderScheme placeHolderScheme, PlaceHolderEnsurer ensurer,
            PlaceHolderValidator placeHolderValidator) where TPlaceHolderScheme:PlaceHolderScheme;

    }
}
