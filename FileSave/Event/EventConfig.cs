// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;

/// <summary> 事件系统配置 </summary>
[EditorBrowsable( EditorBrowsableState.Never )]
public sealed class EventConfig : NeroObject {

    // --- Field & Property ----------------------------------------------------------------------------------------------------------------------------------------------- //

    /// <summary> 指针输入类型 ( 根据运行平台自动设置默认值 ) </summary>
    public PointerInputType PointerInputType {
        get { return _PointerInputType; }
        set { NeroConfig.CheckRunning(); _PointerInputType = value; }
    }
    private PointerInputType _PointerInputType =
        ( Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer ) ? PointerInputType.Touch : PointerInputType.Mouse;

    /// <summary> Mesh 指针事件射线检测距离 ( 默认为无限距离 ) </summary>
    public float PointerEventRaycastDistanceForMesh {
        get { return _PointerEventRaycastDistanceForMesh; }
        set { NeroConfig.CheckRunning(); _PointerEventRaycastDistanceForMesh = value; }
    }
    private float _PointerEventRaycastDistanceForMesh = float.PositiveInfinity;

    // --- Public & Protected Function ------------------------------------------------------------------------------------------------------------------------------------ //

    // --- Internal Function ---------------------------------------------------------------------------------------------------------------------------------------------- //

    // 封闭构造函数
    internal EventConfig() { }

    // --- Private Function ----------------------------------------------------------------------------------------------------------------------------------------------- //

}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //