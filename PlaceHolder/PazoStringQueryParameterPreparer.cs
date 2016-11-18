using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Centaline.Framework.Kernel.placeholder.Interface;

namespace Com.Centaline.Framework.Kernel.placeholder
{
    public class PazoStringQueryParameterPreparer: ParameterPreparer<String>
    {
        protected PlaceHolderScheme placeHolderScheme { get; set; }

        protected PlaceHolderStringParser placeHolderStringParser { get; set; }



   

        public PazoStringQueryParameterPreparer()
        {

        }

        public PazoStringQueryParameterPreparer(PlaceHolderScheme placeHolderScheme, PlaceHolderStringParser placeHolderStringParser)
        {
            this.placeHolderScheme = placeHolderScheme;
            this.placeHolderStringParser = placeHolderStringParser;
        }

       
           public String prepare(String query, IDictionary<String, Object> args)
        {
            if (null == args || args.Count() < 1)
            {
                return query;
            }
            placeHolderStringParser.getPlaceHolderEnsurer().AppendParamter<IDictionary<String, Object>>(args);
        return placeHolderStringParser.parse(query, placeHolderScheme);
    }

}
}
