using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Centaline.Framework.Kernel.placeholder.Interface;
using ikvm.extensions;



namespace Com.Centaline.Framework.Kernel.placeholder
{
    public  class PazoPlaceHolderAnalyzer:PlaceHolderAnalyzer
    {
        public  string analyse<TPlaceHolderScheme>(string source, TPlaceHolderScheme placeHolderScheme,
            PlaceHolderEnsurer ensurer, PlaceHolderValidator placeHolderValidator) where TPlaceHolderScheme:PlaceHolderScheme
        {
            if (null == source || source.Length < 1)
            {
                return source;
            }
            char[] sourceChars = source.ToCharArray();
            StringBuilder placeHolderString = new StringBuilder();
            List<char> placeHolderStringChars = new List<char>();
            List<char> placeHolderContentChars = new List<char>();
            int searchIndex = 0;
            bool searchPrefix = true;
            bool searchSuffix = true;
            for (int index = 0; index < sourceChars.Length; index++)
            {
                searchPrefix = true;
                searchIndex = 0;
                if (placeHolderStringChars.Count() >= placeHolderScheme.getPrefix().Length)
                {
                    while (searchIndex < placeHolderScheme.getPrefix().Length)
                    {
                        if (placeHolderStringChars[placeHolderStringChars.Count - placeHolderScheme.getPrefix().Length + searchIndex] != placeHolderScheme.getPrefix().charAt(searchIndex))
                        {
                            searchPrefix = false;
                            break;
                        }
                        searchIndex++;
                    }
                    if (searchPrefix)
                    {
                        placeHolderContentChars.Add(sourceChars[index]);
                        searchSuffix = true;
                        searchIndex = 0;
                        if (placeHolderContentChars.Count() > placeHolderScheme.getSuffix().Length)
                        {
                            while (searchIndex < placeHolderScheme.getSuffix().Length)
                            {
                                if (placeHolderContentChars[placeHolderContentChars.Count - placeHolderScheme.getSuffix().Length + searchIndex] != placeHolderScheme.getSuffix().charAt(searchIndex))
                                {
                                    searchSuffix = false;
                                    break;
                                }
                                searchIndex++;
                            }
                            if (searchSuffix)
                            {
                                searchIndex = 0;
                                while (searchIndex++ < placeHolderScheme.getPrefix().Length)
                                {
                                    placeHolderStringChars.RemoveAt(placeHolderStringChars.Count - 1);
                                }
                                searchIndex = 0;
                                placeHolderString.Remove(0, placeHolderString.Length);
                                while (searchIndex < (placeHolderContentChars.Count - placeHolderScheme.getSuffix().Length))
                                {
                                    placeHolderString.Append(placeHolderContentChars[searchIndex++]);
                                }
                                if (!placeHolderValidator.Validate(placeHolderScheme, placeHolderString.ToString()))
                                {
                                    placeHolderContentChars.Clear();
                                    continue;
                                }
                                ensurer.Ensure(placeHolderStringChars, placeHolderString.ToString());
                                placeHolderContentChars.Clear();
                            }
                        }
                    }
                    else
                    {
                        placeHolderStringChars.Add(sourceChars[index]);
                    }
                }
                else
                {
                    placeHolderStringChars.Add(sourceChars[index]);
                }
            }
            searchIndex = 0;
            placeHolderString.Remove(0, placeHolderString.Length);
            while (searchIndex < placeHolderStringChars.Count)
            {
                placeHolderString.Append(placeHolderStringChars[searchIndex++]);
            }
            return placeHolderString.ToString();
        }
    }
}
