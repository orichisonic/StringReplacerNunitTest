using System;
using System.Collections.Generic;

namespace Com.Centaline.Framework.Kernel.placeholder.Interface
{
    public interface PlaceHolderEnsurer
    {
        void AppendParamter<TParameter>(TParameter parameter);

        TPlaceHolderObject Ensure<TPlaceHolderObject>(string placeHolderContent) where TPlaceHolderObject:PlaceHolderObject;

        void Ensure(IList<char> source, string placeHolderContent);

  
    }

  
}
