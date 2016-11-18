using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Centaline.Framework.Kernel.placeholder.Interface;

using Com.Centaline.Framework.Kernel.placeholder;

namespace Com.Centaline.Framework.Kernel.placeholder
{
    public class PazoParameterPreparerPlaceHolderEnsurer: AbstractPlaceHolderEnsurer
    {
        protected ParameterValueFormatter<String> parameterValueFormatter { get; set; }


        protected IDictionary<String, Object> parameters { set; get; }
    

      
        public PazoParameterPreparerPlaceHolderEnsurer()
        {

        }

        public PazoParameterPreparerPlaceHolderEnsurer(ParameterValueFormatter<String> parameterValueFormatter)
        {
            this.parameterValueFormatter = parameterValueFormatter;
        }

      
     


        public override void AppendParamter<TParameter>(TParameter parameter)
        {

            if (parameter is IDictionary<String, Object>)
            {
                parameters = (IDictionary<String, Object>)parameter;
            }
        }

        public override TPlaceHolderObject Ensure<TPlaceHolderObject>(String placeHolderContent)
        {
            TPlaceHolderObject placeHolderObject = base.Ensure<TPlaceHolderObject>(placeHolderContent);

            if (null != parameters && parameters.Count > 0)
            {

                foreach (string key in parameters.Keys)

                {
                    if (placeHolderContent.Equals(key, StringComparison.CurrentCultureIgnoreCase))
                    {
                        placeHolderObject.setContent(parameterValueFormatter.format(parameters[key]));
                        break;
                    }

                }
            }


            return placeHolderObject;
        }
    }
}
