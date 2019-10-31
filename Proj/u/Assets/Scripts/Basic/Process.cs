using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PreProcess
{
    public int Progress = 0;
    public int num;
    public abstract void Process();
    protected void Callback()
    {
        Progress += 1;
    }
}

