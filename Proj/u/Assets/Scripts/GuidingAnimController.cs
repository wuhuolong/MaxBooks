using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidingAnimController : MonoBehaviour
{
    public CircleShaderViewer shaderViewer;

    public void CheckIsOver()
    {
        Debug.Log("check");
        if (shaderViewer.curIndex < shaderViewer.maxIndex)
        {
            shaderViewer.Clear();
            Debug.Log("step" + shaderViewer.curIndex);
            shaderViewer.Init(shaderViewer.curID, shaderViewer.curIndex + 1);
        }
        else
        {
            Debug.Log("is over");
            shaderViewer.Clear();
            shaderViewer.Delete();
        }
    }
}
