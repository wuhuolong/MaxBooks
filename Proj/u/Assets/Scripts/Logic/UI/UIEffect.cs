using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEffect : UIWindows
{
    //public MeshRenderer mesh;
    //Material shadow;

    //private CanvasGroup black;
    //private RectTransform[] shadows;
    //public bool isShadowIn = false;
    //public bool isShadowOut = false;
    //private Vector3 shadowMax = new Vector3(400.0f, 400.0f, 400.0f);
    //private Vector3 shadowMin = new Vector3(2.5f, 2.5f, 2.5f);
    ////private float speedIn = 10.0f;
    ////private float speedOut = 3.5f;
    ////private string shadowType = "shadowType";
    //string progress = "Progress";
    //private int type;

    protected override void InitComp()
    {

    }

    protected override void InitData()
    {
        //shadow = mesh.materials[0];
    }
    
    void Update()
    {
        ////测试
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlayShadowAnim();
        //}

        //if (isShadowIn)
        //{
        //    if (shadow.GetFloat(progress) <= 0.5f)
        //    {
        //        shadow.SetFloat(progress, shadow.GetFloat(progress) + Mathf.Abs(shadow.GetFloat(progress) * 0.1f));
        //        if (Mathf.Abs(shadow.GetFloat(progress) - 0.5f) <= 0.1f)
        //        {
        //            shadow.SetFloat(progress, 0.5f);
        //            isShadowIn = false;
        //            Invoke("SetOut", 0.5f);
        //        }
        //    }
        //}
        //if (isShadowOut)
        //{
        //    if (shadow.GetFloat(progress) <= 0.5f)
        //    {
        //        shadow.SetFloat(progress, shadow.GetFloat(progress) * 0.9f);
        //        if (Mathf.Abs(shadow.GetFloat(progress) - 0.5f) <= 0.1f)
        //        {
        //            shadow.SetFloat(progress, 0.5f);
        //            isShadowIn = false;
        //            //Invoke("SetOut", 0.5f);
        //        }
        //    }
        //}
    }

    private void OnEnable()
    {
        
    }


    //public void PlayShadowAnim()
    //{
    //    type = Random.Range(0, 3);
    //    //black.alpha = 0.0f;
    //    //shadows[type].localScale = shadowMax;
    //    isShadowIn = true;
    //}

    //private void SetIn()
    //{
    //    //black.alpha = 0.0f;
    //    shadows[type].localScale = shadowMax;
    //    isShadowIn = true;
    //}

    //private void SetOut()
    //{
    //    Debug.Log("setout");
    //    isShadowOut = true;
    //    //black.alpha = 0.0f;
    //    shadows[type].localScale = shadowMin;

    //}
}
