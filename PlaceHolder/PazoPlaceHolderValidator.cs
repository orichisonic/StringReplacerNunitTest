using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Centaline.Framework.Kernel.placeholder.Interface;

namespace Com.Centaline.Framework.Kernel.placeholder
{
    public class PazoPlaceHolderValidator : PlaceHolderValidator
    {
        public bool Validate<TPlaceHolderScheme>(TPlaceHolderScheme placeHolderStructure, string content) where TPlaceHolderScheme:PlaceHolderScheme
        {
            return true;
        }

    }


    }

