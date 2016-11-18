using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Centaline.Framework.Kernel.placeholder
{
    public class PlaceHolderObject
    {
        protected String name;
        protected String content;

        public String getName(String name)
        {
           return name;
        }

        public PlaceHolderObject setName(String name)
        {
            this.name = name;
            return this;
        }

        public String getContent()
        {
            return content;
        }

        public PlaceHolderObject setContent(String content)
        {
            this.content = content;
            return this;
        }
    }
}
