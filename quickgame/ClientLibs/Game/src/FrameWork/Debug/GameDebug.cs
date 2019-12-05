using System;
using UnityEngine;
using System.Collections;


public class GameDebug
{

    public const string RED = "red";
    public const string GREEN = "green";
    public const string YELLOW = "yellow";

    public static void Log(string text)
    {
#if UNITY_EDITOR
        string text_final = string.Format("[Log] {0}", text);
        Debug.Log(text_final);
#endif
    }

    public static void LogRed(string text)
    {
        LogColor(text, RED);
    }

    public static void LogGreen(string text)
    {
        LogColor(text, GREEN);
    }

    public static void LogYellow(string text)
    {
        LogColor(text, YELLOW);
    }

    public static void LogColor(string text, string color)
    {
#if UNITY_EDITOR
        string text_final = string.Format("<color={0}>[Log] {1}</color>", color, text);
        Debug.Log(text_final);
#endif
    }

    public static void LogWarning(string text)
    {
#if UNITY_EDITOR
        string text_final = string.Format("[Warning!] {0}", text);
        Debug.LogWarning(text_final);
#endif
    }

    public static void LogError(string text)
    {
        string text_final = string.Format("{0} [Error!] {1}", DateTime.Now.ToLongTimeString(), text);
        Debug.LogError(text_final);
    }

    public static string ParseProtoPack(object pack)
    {
        if (pack == null)
        {
            return "";
        }

        var sb = new System.Text.StringBuilder();

        var type = pack.GetType();
        sb.AppendLine(type.Name);
        sb.AppendLine("{");
        foreach (var field in type.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
        {
            if (field.Name.Contains("extensionObject"))
                continue;
            
            var obj = field.GetValue(pack);
            if (field.FieldType.IsValueType)
                sb.AppendLine(string.Format("{0} : {1}", field.Name, obj.ToString()));
            else if (obj is IList && field.FieldType.IsGenericType)
            {
                var list = obj as IList;
                var elem_type = field.FieldType.GetGenericArguments()[0];
                sb.AppendLine(string.Format("{0} len={1} ", field.Name, list.Count));
                for (int i = 0; i < list.Count; ++i)
                {
                    if (elem_type.IsValueType)
                        sb.AppendLine(string.Format("[{0}] : {1}", i, list[i].ToString()));
                    else
                    {
                        sb.AppendLine(string.Format("[{0}] : ", i));
                        sb.AppendLine(ParseProtoPack(list[i]));
                    }
                }
            }
            else
                sb.AppendLine(ParseProtoPack(obj));
        }
        sb.AppendLine("}");

        return sb.ToString();
    }
}

