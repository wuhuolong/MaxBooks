using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLevel
{
    public abstract void OnEnter(params object[] argv);
    public abstract void OnExit(params object[] argv);
    public abstract void OnClickQuit_UIEnd(params object[] argv);


}
