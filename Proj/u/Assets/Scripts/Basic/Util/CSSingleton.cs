using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSSingleton<T> where T:CSSingleton<T> ,new()
{
    private static T _ins = null;
    public static T GetInstance()
    {
        if (_ins == null)
        {
            _ins = new T();
        }
        return _ins;
    }
}
