using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Extensions
{
    public static int AddV2<T>(this List<T> list,T t1)
    {
        int index = -1;
        if (list.Contains(t1))
        {
            Debug.Log("添加失败，重复值");
        }
        else
        {
            index = list.Count;
            list.Add(t1);
        }
        return index;
    }

}
