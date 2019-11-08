using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;

public static class ImgUtil
{
#if !UNITY_EDITOR && UNITY_IOS
    [DllImport("__Internal")]
    private static extern void _SavePhoto(string url);    
#endif

    private static Coroutine co;
    private static RectTransform ca;
    public static void TakePhoto(Image im, RectTransform rect)
    {
        if(rect != null)
        {
            ImgUtil.ca = rect;
        }
        if (co != null)
        {
            GameKernel.GetInstance().StopCoroutine(co);
        }
        co = GameKernel.GetInstance().StartCoroutine(TakephotoIE(im));
    }
    
    private static IEnumerator TakephotoIE(Image im)
    {
        float sheight, swidth;
        int capx = 0;
        int capy = 0;
        int capwidth = 0;
        int capheight = 0;
        //sheight = Screen.currentResolution.height; 
        //swidth = Screen.currentResolution.width;
        sheight = ca.rect.height;
        swidth = ca.rect.width;

        Vector3 v3 = Camera.main.WorldToScreenPoint(im.transform.position);
        //Debug.Log(v3);
        //Debug.Log(im.rectTransform.rect.position);
        //Debug.Log(im.rectTransform.rect.yMax);

        float rate = Mathf.Min(Screen.width / swidth, Screen.height / sheight);

        capwidth = (int)(im.rectTransform.rect.width * 1.0f / swidth * Screen.width);
        capheight = (int)(im.rectTransform.rect.height * 1.0f / sheight * Screen.height);
        //capwidth = (int)(im.rectTransform.rect.width * 1.0f * rate);
        //capheight = (int)(im.rectTransform.rect.height * 1.0f * rate);
        capx = (int)(v3.x - capwidth * im.rectTransform.pivot.x);
        capy = (int)(v3.y - capheight * im.rectTransform.pivot.y);
        //Debug.Log("capwidth" + capwidth);
        //Debug.Log("capheight" + capheight);
        //Debug.Log("capx" + capx);
        //Debug.Log("capy" + capy);
        //Debug.Log("sheight" + sheight);
        //Debug.Log("swidth" + swidth);
        //Debug.Log("Screen.width" + Screen.width);
        //Debug.Log("Screen.height" + Screen.height);

        if (capwidth + capx > Screen.width)
        {
            Debug.Log("1");
            capwidth = Screen.width - capx;
        }
        else if (capx < 0)
        {
            Debug.Log("2");
            capwidth = Screen.width + capx < 0 ? 0 : Screen.width + capx;
        }

        if (capheight + capy > Screen.height)
        {
            Debug.Log("3");
            capheight = Screen.height - capy;
        }
        else if (capy < 0)
        {
            Debug.Log("4");
            capheight = Screen.height + capy < 0 ? 0 : Screen.height + capy;
        }

        yield return new WaitForEndOfFrame();
        Texture2D t;

        t = new Texture2D(capwidth, capheight, TextureFormat.RGB24, false);//需要正确设置好图片保存格式

        t.ReadPixels(new Rect(capx, capy, capwidth, capheight), 0, 0, false);//按照设定区域读取像素；注意是以左下角为原点读取
        t.Compress(false);
        t.Apply();
        //二进制转换，保存到手机
        byte[] byt = t.EncodeToPNG();
        string filepath = XGamePath.SavePath("temp.png");// + "/" + "temp.png";
        if (File.Exists(filepath))
        {
            File.Delete(filepath);
        }
        FileStream fs = File.Create(filepath);
        fs.Write(byt, 0, byt.Length);
        fs.Close();
        fs.Dispose();
        co = null;
#if !UNITY_EDITOR && UNITY_IOS
        _SavePhoto(filepath);
#endif
    }
}