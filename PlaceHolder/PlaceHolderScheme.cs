using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Centaline.Framework.Kernel.placeholder
{
    public class PlaceHolderScheme
    {
        protected String prefix { get; set; }
        protected String suffix { get; set; }
    

        public PlaceHolderScheme()
        {
        }

        public PlaceHolderScheme(String prefix, String suffix)
        {
            this.prefix = prefix;
            this.suffix = suffix;
        }

        public string getPrefix()
        {
            return prefix;
        }

        public PlaceHolderScheme setPrefix(String prefix)
        {
            this.prefix = prefix;
            return this;
        }

        public string getSuffix()
        {
            return suffix;

        }

        public PlaceHolderScheme setSuffix(String suffix)
        {
            this.suffix = suffix;
            return this;
        }

    }
}
