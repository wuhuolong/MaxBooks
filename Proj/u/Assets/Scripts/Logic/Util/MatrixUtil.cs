using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class MatrixUtil
{

    public static int[] MatrixTrans(int owidth, int oheight, int fwidth, int fheight, int[] array)
    {
        int flength = fwidth * fheight;
        int[] target = new int[flength];
        int minwidth = Mathf.Min(owidth, fwidth);
        int minheight = Mathf.Min(oheight, fheight);
        int length = minwidth * minheight;
        for (int i = 0, omark = 0, fmark = 0; i < length; i++, omark++, fmark++)
        {
            if (i != 0 && (i) % minwidth == 0)
            {
                omark += (owidth - minwidth);
                fmark += (fwidth - minwidth);
            }
            target[fmark] = array[omark];
        }
        return target;
    }

    public static T[] ArrayCopy<T>(T[] srcArray)
    {
        int length = srcArray.Length;
        T[] destArray = new T[length];
        Array.Copy(srcArray, destArray, length);
        return destArray;
    }

    public static string PrintIntArray(int[] intArray)
    {
        string x = "";
        foreach (int i in intArray)
        {
            x += i.ToString() + ",";
        }
        return x;
    }
}
