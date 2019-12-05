

using System;
using System.Collections.Generic;

public static class UtilType
{
    private static Dictionary<Type, string> cachedType = new Dictionary<Type, string>();

    private static Dictionary<Type, string> cachedLowerType = new Dictionary<Type, string>();

    public static string GetTypeName(Type type)
    {
        if (!cachedType.ContainsKey(type))
        {
            string name = type.Name;
            cachedType.Add(type, name);
            cachedLowerType.Add(type, name.ToLower());
        }

        return cachedType[type];
    }

    public static string GetTypeLowerName(Type type)
    {
        if (!cachedType.ContainsKey(type))
        {
            string name = type.Name;
            cachedType.Add(type, name);
            cachedLowerType.Add(type, name.ToLower());
        }

        return cachedLowerType[type];
    }


}
