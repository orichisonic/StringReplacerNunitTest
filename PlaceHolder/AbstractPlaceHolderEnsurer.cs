using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Com.Centaline.Framework.Kernel.placeholder.Interface;


namespace Com.Centaline.Framework.Kernel.placeholder
{
    public abstract class AbstractPlaceHolderEnsurer : PlaceHolderEnsurer

    {
        
        public abstract void AppendParamter<TParameter>(TParameter parameter);

        public virtual TPlaceHolderObject Ensure<TPlaceHolderObject>(string placeHolderContent)
            where TPlaceHolderObject : PlaceHolderObject
        {
            return
                (TPlaceHolderObject) new PlaceHolderObject().setName(placeHolderContent).setContent(placeHolderContent);
        }

     

        public virtual void Ensure(IList<char> source, string placeHolderContent)
        {
            PlaceHolderObject placeHolderObject = Ensure<PlaceHolderObject>(placeHolderContent);
            if (null != placeHolderObject)
            {
                int searchIndex = 0;
                while (searchIndex < placeHolderObject.getContent().Length)
                {
                    source.Add(placeHolderObject.getContent().ToCharArray()[searchIndex++]);
                }
            }
        }

   

    }

}
