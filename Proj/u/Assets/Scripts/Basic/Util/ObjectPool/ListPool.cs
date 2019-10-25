using System;
using System.Collections.Generic;
using UnityEngine;

public interface IDispose
{
    void Dispose();
}
/// <summary>
/// ∂‘œÛ≥ÿ¿‡
/// </summary>
/// <typeparam name="T"></typeparam>
public static class ListPool<T> where T : IDispose
{
    // Object pool to avoid allocations.
    private static readonly ObjectPool<List<T>> s_ListPool = new ObjectPool<List<T>>(null, Clear);
    static void Clear(List<T> l) {
        l.Clear();
        //foreach (T t in l)
        //{
        //    t.Dispose();
        //}
    }

    public static List<T> Get()
    {
        return s_ListPool.Get();
    }

    public static void Release(List<T> toRelease)
    {
        int size = System.Runtime.InteropServices.Marshal.SizeOf(s_ListPool);
        Debug.Log(size);
        s_ListPool.Release(toRelease);
    }
}
