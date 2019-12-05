using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class HttpRequest : MonoBehaviour
{
	public delegate void POSTCB(string url,Dictionary<string, string> data,string error,string reply,System.Object userData);

	public delegate void GETCB(string url,string error,string reply,System.Object userData);

    public static HttpRequest Instance;

    public HttpRequest()
	{
	}
	
	public void GET(string url, GETCB cb)
	{
		GET(url, cb, null);
	}
	
	public void GET(string url, GETCB cb, System.Object userData)
	{
        //Debug.Log("---url" + url);
		StartCoroutine(_GET(url, cb, userData));
	}

    public void POST(string url, Dictionary<string, string> data, POSTCB cb)
	{
		POST(url, data, cb, null);
	}
	
	public void POST(string url, Dictionary<string, string> data, POSTCB cb, System.Object userData)
	{
		StartCoroutine(_POST(url, data, null, cb, userData));
	}

    public void POST(string url, Dictionary<string, string> data, Dictionary<string, KeyValuePair<string, byte[]>> stream, POSTCB cb, System.Object userData)
    {
        StartCoroutine(_POST(url, data, stream, cb, userData));
    }

    /// <summary>
    /// 开放给Lua端调用的Post接口
    /// </summary>
    /// <param name="url">URL</param>
    /// <param name="values">值表</param>
    /// <param name="files">文件表，会以二进制的形式向服务端请求(通过WWWForm.AddBinaryData的形式)</param>
    /// <param name="cb">回调</param>
    public void POST(string url, XLua.LuaTable values, XLua.LuaTable files, POSTCB cb)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        IDictionaryEnumerator de = null;
        if (values != null)
        {
            //de = values.GetEnumerator();
            //while (de.MoveNext())
            //{
            //    data.Add(de.Key as string, de.Value as string);
            //}
            foreach (string key in values.GetKeys<string>())
            {
                data.Add(key, values.Get<string>(key));
            }
        }

        Dictionary<string, KeyValuePair<string, byte[]>> stream = new Dictionary<string, KeyValuePair<string, byte[]>>();
        if (files!=null)
        {
            //de = files.GetEnumerator();
            //while (de.MoveNext())
            //{
            //    string field = de.Key as string;
            //    string path = de.Value as string;
            //    if (string.IsNullOrEmpty(path) || !File.Exists(path))
            //    {
            //        GameDebug.LogWarning(string.Format("Unexpect path:{0}", path));
            //        continue;
            //    }
            //    byte[] bytes = File.ReadAllBytes(path);
            //    stream.Add(field, new KeyValuePair<string, byte[]>(Path.GetFileName(path), bytes));
            //}
            foreach (string field in files.GetKeys<string>())
            {
                string path = values.Get<string>(field);
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                {
                    GameDebug.LogWarning(string.Format("Unexpect path:{0}", path));
                    continue;
                }
                byte[] bytes = File.ReadAllBytes(path);
                stream.Add(field, new KeyValuePair<string, byte[]>(Path.GetFileName(path), bytes));
            }
        }
        
        POST(url, data, stream, cb, null);
    }

    IEnumerator _GET(string url, GETCB cb, System.Object userData)
	{
        //GameDebug.Log("HttpRequest Get, url: " + url);

		WWW www = new WWW(url);
		yield return www;

        if (string.IsNullOrEmpty(www.error) == false)
        {
            //GameDebug.LogError("HttpRequest Get URL " + url + " error! " + www.error);
            if (cb != null)
            {
                cb(url, www.error, "", userData);
            }
        }
        else
        {
            //GameDebug.Log("HttpRequest Get callback, url: " + url + ", reply: " + www.text);
            if (cb != null)
            {
                cb(url, www.error, www.text, userData);
            }
        }
    }

    public IEnumerator CoGET(string url, GETCB cb, System.Object userData)
    {
        //GameDebug.Log("HttpRequest Get, url: " + url);

        WWW www = new WWW(url);
        yield return www;

        if (string.IsNullOrEmpty(www.error) == false)
        {
            //GameDebug.LogError("HttpRequest Get URL " + url + " error! " + www.error);
            if (cb != null)
            {
                cb(url, www.error, "", userData);
            }
        }
        else
        {
            //GameDebug.Log("HttpRequest Get callback, url: " + url + ", reply: " + www.text);
            if (cb != null)
            {
                cb(url, www.error, www.text, userData);
            }
        }
    }

    IEnumerator _POST(string url, Dictionary<string, string> data, Dictionary<string, KeyValuePair<string, byte[]>> streams, POSTCB cb, System.Object userData)
	{
        //GameDebug.Log("HttpRequest Post, url: " + url + ", data: " + data);

        WWWForm form = new WWWForm();
		foreach (KeyValuePair<string, string> pair in data)
		{
            //GameDebug.Log(string.Format("{0}:{1}", pair.Key, pair.Value));
			form.AddField(pair.Key, pair.Value);
		}
        if (form.data.Length == 0)
            form.AddField("a", "a");

        foreach (KeyValuePair<string, KeyValuePair<string, byte[]>> pair in streams)
        {
            //GameDebug.Log(string.Format("{0}:{1}:{2}", pair.Key, pair.Value.Value.Length, pair.Value.Key));
            form.AddBinaryData(pair.Key, pair.Value.Value, pair.Value.Key);
        }

        WWW www = new WWW(url, form);
		yield return www;

        if (string.IsNullOrEmpty(www.error) == false)
        {
            //GameDebug.LogError("HttpRequest Post URL " + url + " error! " + www.error);
            if (cb != null)
            {
                cb(url, data, www.error, "", userData);
            }
        }
        else
        {
            //GameDebug.Log("HttpRequest Get callback, url: " + url + ", reply: " + www.text);
            if (cb != null)
            {
                cb(url, data, www.error, www.text, userData);
            }
        }
    }

    //TODO WWW.EscapeURL
    public static string UrlEncode(string str)
    {
        string str2 = "0123456789abcdef";
        int length = str.Length;
        StringBuilder builder = new StringBuilder(length * 2);
        int num3 = -1;
        byte[] utf8Value = new byte[3];
        while (++num3 < length)
        {
            char ch = str[num3];
            int num2 = ch;
            if ((((0x41 > num2) || (num2 > 90)) &&
                 ((0x61 > num2) || (num2 > 0x7a))) &&
                ((0x30 > num2) || (num2 > 0x39)))
            {
                switch (ch)
                {
                    case '@':
                    case '*':
                    case '_':
                    case '+':
                    case '-':
                    case '.':
                    case '/':
                        goto Label_0125;
                }

                if (num2 < 0x100)
                {
                    builder.Append('%');
                    builder.Append(str2[num2 / 0x10]);
                    ch = str2[num2 % 0x10];
                }
                else
                {
                    Encoding.UTF8.GetBytes(str, num3, 1, utf8Value, 0);
                    builder.Append('%');
                    int num4 = utf8Value[0];
                    builder.Append(str2[num4 / 0x10]);
                    builder.Append(str2[num4 % 0x10]);
                    builder.Append('%');
                    num4 = utf8Value[1];
                    builder.Append(str2[num4 / 0x10]);
                    builder.Append(str2[num4 % 0x10]);
                    builder.Append('%');
                    num4 = utf8Value[2];
                    builder.Append(str2[num4 / 0x10]);
                    ch = str2[num4 % 0x10];

                }
            }
        Label_0125:
            builder.Append(ch);
        }
        return builder.ToString();
    }
}

