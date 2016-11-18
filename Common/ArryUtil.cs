using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ArryUtil
    {

    

        public static byte[] arrayReplace(byte[] org, byte[] search, byte[] replace, int startIndex)
        {
            //byte[] result = null;
            int index = indexOf(org, search, startIndex);
            if (index != -1)
            {
                int newLength = org.Length + replace.Length - search.Length;
                byte[] newByte = new byte[newLength];
                Buffer.BlockCopy(org, 0, newByte, 0, index);
                Buffer.BlockCopy(replace, 0, newByte, index, replace.Length);
                Buffer.BlockCopy(org, index + search.Length, newByte, index + replace.Length,
                    org.Length - index - search.Length);
                int newStart = index + replace.Length;
                //String newstr=new String(newByte,"GBK");
                //System.out.println(newstr);
                if ((newByte.Length - newStart) > replace.Length)
                {
                    return arrayReplace(newByte, search, replace, newStart);
                }
                return newByte;
            }
            else
            {
                return org;
            }

            //return result;
        }

        /// <summary>  
        /// 查找指定数组的起始索引
        /// </summary>  
        /// <param name="org">org of type byte[] 原数组</param>  
        /// <param name="search">search of type byte[] 要查找的数组</param>   
        /// <returns>int 返回索引 </returns>    
        public static int indexOf(byte[] org, byte[] search)
        {

            return indexOf(org, search, 0);

        }

        /// <summary>  
        /// 查找指定数组的起始索引
        /// </summary>  
        /// <param name="org">org of type byte[] 原数组</param>  
        /// <param name="search">search of type byte[] 要查找的数组</param>
        /// <param name="startIndex">startIndex 起始索引</param>
        /// <returns>int 返回索引 </returns>    
        public static int indexOf(byte[] org, byte[] search, int startIndex)
        {

            KMPMatcher kmpMatcher = new KMPMatcher();

            kmpMatcher.computeFailure4Byte(search);

            return kmpMatcher.indexOf(org, startIndex);

            //return com.alibaba.common.lang.ArrayUtil.indexOf(org, search);

        }

    
        /// <summary>  
        /// 从指定数组的copy一个子数组并返回
        /// </summary>  
        /// <param name="org">org of type byte[] 原数组</param>  
        /// <param name="to">to 合并一个byte[]</param>
        /// <returns>合并的数据 </returns>    
        public static byte[] append(byte[] org, byte[] to)
        {

            byte[] newByte = new byte[org.Length + to.Length];

            Buffer.BlockCopy(org, 0, newByte, 0, org.Length);

            Buffer.BlockCopy(to, 0, newByte, org.Length, to.Length);

            return newByte;

        }


        /// <summary>  
        /// 从指定数组的copy一个子数组并返回
        /// </summary>  
        /// <param name="org">org of type byte[] 原数组</param>  
        /// <param name="to">to 合并一个byte</param>
        /// <returns>合并的数据 </returns>    
        public static byte[] append(byte[] org, byte to)
        {

            byte[] newByte = new byte[org.Length + 1];

            Buffer.BlockCopy(org, 0, newByte, 0, org.Length);

            newByte[org.Length] = to;

            return newByte;

        }

        /// <summary>  
        /// 从指定数组的copy一个子数组并返回
        /// </summary>  
        /// <param name="org">org of type byte[] 原数组</param>  
        /// <param name="from">from 起始点</param>
        /// <param name="append">append 要合并的数据</param>
        public static void append(byte[] org, int from, byte[] append)
        {

            Buffer.BlockCopy(append, 0, org, from, append.Length);

        }
     
        /// <summary>  
        /// 从指定数组的copy一个子数组并返回
        /// </summary>  
        /// <param name="org">original of type byte[] 原数组</param>  
        /// <param name="from">from 起始点</param>
        /// <param name="to">to 结束点</param>
        /// <returns>返回copy的数组 </returns>    
        public static byte[] copyOfRange(byte[] original, int from, int to)
        {

            int newLength = to - from;

            if (newLength < 0)

                throw new Exception(from + " >" + to);

            byte[] copy = new byte[newLength];

            Buffer.BlockCopy(original, from, copy, 0,

                    Math.Min(original.Length - from, newLength));

            return copy;

        }





        public static byte[] char2byte(String encode, char[] chars)
        {
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(encode);
            string s = new string(chars);
            return encoding.GetBytes(s);
         }
      
        /// <summary>  
        /// 查找指定数组的最后一次出现起始索引
        /// </summary>  
        /// <param name="org">org of type byte[] 原数组</param>  
        /// <param name="search"> search of type byte[] 要查找的数组</param>
        /// <returns>int 返回索引 </returns>   
        public static int lastIndexOf(byte[] org, byte[] search)
        {

            return lastIndexOf(org, search, 0);

        }


        /// <summary>  
        /// 查找指定数组的最后一次出现起始索引
        /// </summary>  
        /// <param name="org">org of type byte[] 原数组</param>  
        /// <param name="search"> search of type byte[] 要查找的数组</param>
        /// <param name="fromIndex"> fromIndex 起始索引</param>
        /// <returns>int 返回索引 </returns>   
        public static int lastIndexOf(byte[] org, byte[] search, int fromIndex)
        {

            KMPMatcher kmpMatcher = new KMPMatcher();

            kmpMatcher.computeFailure4Byte(search);

            return kmpMatcher.lastIndexOf(org, fromIndex);

        }

    }


    /// <summary>  
    /// KMP算法类
    /// </summary>

    public  class KMPMatcher
    {

        private  int[] failure;

        private  int matchPoint;

        private  byte[] bytePattern;
  
        /// <summary>  
        /// Method indexOf
        /// </summary>  
        /// <param name="text">text of type byte[]</param>  
        /// <param name="startIndex">startIndex of type int</param>
        /// <returns>return int </returns>    
        public int indexOf(byte[] text, int startIndex)
        {

            int j = 0;

            if (text.Length == 0 || startIndex > text.Length) return -1;



            for (int i = startIndex; i < text.Length; i++)
            {

                while (j > 0 && bytePattern[j] != text[i])
                {

                    j = failure[j - 1];

                }

                if (bytePattern[j] == text[i])
                {

                    j++;

                }

                if (j == bytePattern.Length)
                {

                    matchPoint = i - bytePattern.Length + 1;

                    return matchPoint;

                }

            }

            return -1;

        }



    
        /// <summary>  
        /// 找到末尾后重头开始找
        /// </summary>  
        /// <param name="text">text of type byte[]</param>  
        /// <param name="startIndex">startIndex of type int</param>
        /// <returns>return int </returns>    
        public int lastIndexOf(byte[] text, int startIndex)
        {

            matchPoint = -1;

            int j = 0;

            if (text.Length == 0 || startIndex > text.Length) return -1;

            int end = text.Length;

            for (int i = startIndex; i < end; i++)
            {

                while (j > 0 && bytePattern[j] != text[i])
                {

                    j = failure[j - 1];

                }

                if (bytePattern[j] == text[i])
                {

                    j++;

                }

                if (j == bytePattern.Length)
                {

                    matchPoint = i - bytePattern.Length + 1;

                    if ((text.Length - i) > bytePattern.Length)
                    {

                        j = 0;

                        continue;

                    }

                    return matchPoint;

                }

                //如果从中间某个位置找，找到末尾没找到后，再重头开始找

                if (startIndex != 0 && i + 1 == end)
                {

                    end = startIndex;

                    i = -1;

                    startIndex = 0;

                }

            }

            return matchPoint;

        }

        /// <summary>  
        /// 找到末尾后不会重头开始找
        /// </summary>  
        /// <param name="text">text of type byte[]</param>  
        /// <param name="startIndex">startIndex of type int</param>
        /// <returns>return int </returns>  
        public int lastIndexOfWithNoLoop(byte[] text, int startIndex)
        {

            matchPoint = -1;

            int j = 0;

            if (text.Length == 0 || startIndex > text.Length) return -1;



            for (int i = startIndex; i < text.Length; i++)
            {

                while (j > 0 && bytePattern[j] != text[i])
                {

                    j = failure[j - 1];

                }

                if (bytePattern[j] == text[i])
                {

                    j++;

                }

                if (j == bytePattern.Length)
                {

                    matchPoint = i - bytePattern.Length + 1;

                    if ((text.Length - i) > bytePattern.Length)
                    {

                        j = 0;

                        continue;

                    }

                    return matchPoint;

                }

            }

            return matchPoint;

        }



       
        /// <summary>  
        /// Method computeFailure4Byte
        /// </summary>  
        /// <param name="patternStr">patternStr of type byte[]</param>  
        public void computeFailure4Byte(byte[] patternStr)
        {

            bytePattern = patternStr;

            int j = 0;

            int len = bytePattern.Length;

            failure = new int[len];

            for (int i = 1; i < len; i++)
            {

                while (j > 0 && bytePattern[j] != bytePattern[i])
                {

                    j = failure[j - 1];

                }

                if (bytePattern[j] == bytePattern[i])
                {

                    j++;

                }

                failure[i] = j;

            }

        }

    }




}
