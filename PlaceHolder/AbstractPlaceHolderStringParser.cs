using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Centaline.Framework.Kernel.placeholder.Interface;

namespace Com.Centaline.Framework.Kernel.placeholder
{
    public abstract class AbstractPlaceHolderStringParser:PlaceHolderStringParser 
    {
        public abstract PlaceHolderEnsurer getPlaceHolderEnsurer();

        public abstract PlaceHolderAnalyzer getPlaceHolderAnalyzer();

        public abstract PlaceHolderValidator getPlaceHolderValidator();

        public string parse<TPlaceHolderScheme>(string content, TPlaceHolderScheme placeHolderScheme) where TPlaceHolderScheme : PlaceHolderScheme
        {
            return getPlaceHolderAnalyzer()
                .analyse(content, placeHolderScheme, getPlaceHolderEnsurer(), getPlaceHolderValidator());


        }



    }
}
