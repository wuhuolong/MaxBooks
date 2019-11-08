using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> :MonoBehaviour  where T : MonoSingleton<T>, new()
{

    private static T _ins = null;
    private static string Tag
    {
        get
        {
            return "MonoSingleton";
        }
    }
    public static T GetInstance()
    {
        GameObject obj = GameObject.Find(Tag);
        if (obj == null)
        {
            obj = new GameObject(Tag);
        }
        if (_ins == null)
        {
            _ins = obj.GetComponent<T>();
            if (_ins == null)
            {
                _ins = obj.AddComponent<T>();
            }
        }        
        return _ins;
    }
    public virtual void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
