using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Centaline.Framework.Kernel.placeholder.Interface;


namespace Com.Centaline.Framework.Kernel.placeholder
{
    public class PazoStringParameterValueFormatter : ParameterValueFormatter<String>
    {
        public String format(Object value)
        {
            String result = "";
            if (value is String || value is Guid){
                result = String.Format("{0}", value);
            } else{
                result = value.ToString();
            }
            return result;
        }
    }
}
