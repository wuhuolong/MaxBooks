using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

using xc;

[RequireComponent(typeof(RawImage))]
public class WWWLoadImage : MonoBehaviour
{
    private string path = "";
    private uint maxSaveTime = 7 * 24 * 60; // 分钟(7天)

    void Awake()
    {
        // 检查文件是否过期
        if (string.IsNullOrEmpty(path))
        {
            CheckCacheDirectory();
        }

        DirectoryInfo dirInfo = new DirectoryInfo(path);
        FileInfo[] fileInfoArray = dirInfo.GetFiles("*.png");

        DateTime dtNow = DateTime.Now;

        foreach (FileInfo v in fileInfoArray)
        {
            TimeSpan ts = dtNow.Subtract(v.LastWriteTime);
            if (ts.TotalMinutes > maxSaveTime)
            {
                v.Delete();
            }
        }
    }

    void OnDisable()
    {
    }

    void CheckCacheDirectory()
    {
        IBridge bridge = DBOSManager.getDBOSManager().getBridge();
        path = bridge.getGameResPath() + "/ImageCache/";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    string GetFileName(string path)
    {
        return path.Substring(path.LastIndexOf("/") + 1, (path.LastIndexOf(".") - path.LastIndexOf("/") - 1));
    }

    /// <summary>
    /// 加载图片 
    /// </summary>
    /// <param name="url"> 图片url地址 </param>
    /// <param name="bInitHide"> 图片初始状态是否隐藏 </param>

    public void LoadImage(string url, bool bInitHide = false)
    {
        if (string.IsNullOrEmpty(url))
        {
            GameDebug.LogError("image path is null or empty");
            return;
        }

        if (bInitHide)
            gameObject.SetActive(false);

        if (string.IsNullOrEmpty(path))
        {
            CheckCacheDirectory();                
        }

        var rawImage = GetComponent<RawImage>();
        string curTexturnName = "";
        if (rawImage.texture != null)
            curTexturnName = rawImage.texture.name;

        // 已使用的资源名和需要下载的是否一样
        string fileName = GetFileName(url);
        if (string.IsNullOrEmpty(fileName))
        {
            GameDebug.LogError("url.fileName is null or empty");
            return;
        }

        if (fileName.Equals(curTexturnName))
        {
            if (bInitHide)
                gameObject.SetActive(true);

            return;
        }

        var localPath = path + fileName + ".png";
        if (File.Exists(localPath))
        {
            // 本地存在，直接下载
            MainGame.GetGlobalMono().StartCoroutine(LoadLocalImage(localPath, bInitHide));
        }
        else
        {
            MainGame.GetGlobalMono().StartCoroutine(DownloadImage(url, localPath, bInitHide));
        }
    }

    IEnumerator LoadLocalImage(string localPath, bool bInitHide)
    {
        string filePath = "file:///" + localPath;

        WWW www = new WWW(filePath);
        yield return www;

        string textureName = GetFileName(localPath);
        if (!SetImage(www, textureName, bInitHide))
            yield break;
    }

    IEnumerator DownloadImage(string url, string savePath, bool bInitHide)
    {
        WWW www = new WWW(url);
        yield return www;

        Texture2D texture2D = www.texture;
        if (texture2D == null)
            yield break;

        //保存至缓存路径  
        byte[] pngData = texture2D.EncodeToPNG();
        File.WriteAllBytes(savePath, pngData);

        string textureName = GetFileName(savePath);
        if (!SetImage(www, textureName, bInitHide))
            yield break;
    }

    bool SetImage(WWW www, string textureName, bool bInitHide)
    {
        Texture2D texture2D = www.texture;
        if (texture2D == null)
            return false;

        // 销毁旧的资源
        int width = texture2D.width;
        int height = texture2D.height;
        DestroyImmediate(texture2D, true);

        // 重新创建RBGA16的贴图, 并禁用mipmap
        TextureFormat texture_format = TextureFormat.ARGB4444;

#if UNITY_ANDROID || UNITY_IPHONE
        texture_format = TextureFormat.RGBA4444;
#endif

        Texture2D newTexture2D = new Texture2D(width, height, texture_format, false);
        newTexture2D.LoadImage(www.bytes);
        if (newTexture2D == null)
            return false;

        newTexture2D.name = textureName;

        var rawImage = GetComponent<RawImage>();
        if (rawImage == null)
            return false;

        rawImage.texture = newTexture2D;

        if (bInitHide && gameObject != null)
            gameObject.SetActive(true);

        return true;
    }
}