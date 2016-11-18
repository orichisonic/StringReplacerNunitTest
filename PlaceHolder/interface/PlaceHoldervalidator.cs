using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Centaline.Framework.Kernel.placeholder.Interface
{
    public interface PlaceHolderValidator
    {
        bool Validate<TPlaceHolderScheme>(TPlaceHolderScheme placeHolderStructure, string content) where TPlaceHolderScheme : PlaceHolderScheme;
    }
}
