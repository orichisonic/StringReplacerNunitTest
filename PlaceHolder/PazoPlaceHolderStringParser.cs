using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Centaline.Framework.Kernel.placeholder.Interface;

namespace Com.Centaline.Framework.Kernel.placeholder
{
    public class PazoPlaceHolderStringParser:AbstractPlaceHolderStringParser
    {
        protected PlaceHolderEnsurer placeHolderEnsurer;
        protected PlaceHolderAnalyzer placeHolderAnalyzer;
        protected PlaceHolderValidator placeHolderValidator;

        public void setPlaceHolderEnsurer(PlaceHolderEnsurer placeHolderEnsurer)
        {
            this.placeHolderEnsurer = placeHolderEnsurer;
        }

        public void setPlaceHolderAnalyzer(PlaceHolderAnalyzer placeHolderAnalyzer)
        {
            this.placeHolderAnalyzer = placeHolderAnalyzer;
        }

        public void setPlaceHolderValidator(PlaceHolderValidator placeHolderValidator)
        {
            this.placeHolderValidator = placeHolderValidator;
        }

        public PazoPlaceHolderStringParser()
        {
        }

        public PazoPlaceHolderStringParser(PlaceHolderEnsurer placeHolderEnsurer,
            PlaceHolderAnalyzer placeHolderAnalyzer, PlaceHolderValidator placeHolderValidator)
        {
            this.placeHolderEnsurer = placeHolderEnsurer;
            this.placeHolderAnalyzer = placeHolderAnalyzer;
            this.placeHolderValidator = placeHolderValidator;
        }

      

        public override PlaceHolderEnsurer getPlaceHolderEnsurer()
        {
            return placeHolderEnsurer;
        }

        public override PlaceHolderAnalyzer getPlaceHolderAnalyzer()
        {
            return placeHolderAnalyzer;
        }

        public override PlaceHolderValidator getPlaceHolderValidator()
        {
            return placeHolderValidator;
        }



    }
}
