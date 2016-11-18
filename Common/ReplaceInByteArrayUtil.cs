using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ReplaceInByteArrayUtil
    {

        public static byte[]  ReplaceInByteArray(byte[] OriginalArray, byte[] Find,byte[] Replace)
        {
            byte[] ReturnValue = OriginalArray;

            if (System.Array.BinarySearch(ReturnValue, Find) > -1)
            {
                byte[] NewReturnValue;
                int lFoundPosition;
                int lCurrentPosition;
                int lCurrentOriginalPosition;
                while (FindInByteArray(ReturnValue, Find) > -1)
                {
                    NewReturnValue = new byte[ReturnValue.Length + Replace.Length -
                    Find.Length];
                    lFoundPosition = FindInByteArray(ReturnValue, Find);
                    lCurrentPosition = 0;
                    lCurrentOriginalPosition = 0;

                    for (int x = 0; x < lFoundPosition; x++)
                    {
                        NewReturnValue[x] = ReturnValue[x];
                        lCurrentPosition++;
                        lCurrentOriginalPosition++;
                    }

                    for (int y = 0; y < Replace.Length; y++)
                    {
                        NewReturnValue[lCurrentPosition] = Replace[y];
                        lCurrentPosition++;
                    }

                    lCurrentOriginalPosition = lCurrentOriginalPosition + Find.Length;

                    while (lCurrentPosition < NewReturnValue.Length)
                    {
                        NewReturnValue[lCurrentPosition] =
                        ReturnValue[lCurrentOriginalPosition];
                        lCurrentPosition++;
                        lCurrentOriginalPosition++;
                    }

                    ReturnValue = NewReturnValue;
                }

            }
            return ReturnValue;
        }

        private static int FindInByteArray(byte[] Haystack, byte[] Needle)
        {
            int lFoundPosition = -1;
            int lMayHaveFoundIt = -1;
            int lMiniCounter = 0;

            for (int lCounter = 0; lCounter < Haystack.Length; lCounter++)
            {
                if (Haystack[lCounter] == Needle[lMiniCounter])
                {
                    if (lMiniCounter == 0)
                        lMayHaveFoundIt = lCounter;
                    if (lMiniCounter == Needle.Length - 1)
                    {
                        return lMayHaveFoundIt;
                    }
                    lMiniCounter++;
                }
                else
                {
                    lMayHaveFoundIt = -1;
                    lMiniCounter = 0;
                }
            }

            return lFoundPosition;
        }
    }
}
