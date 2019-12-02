// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class PointerStatusData {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 指针 ID
        internal int PointerID { get; set; }

        // 是否按下
        internal bool IsDown { get; set; }

        // 当前帧的坐标
        internal int NowX { get; set; }
        internal int NowY { get; set; }

        // 上一帧的坐标
        internal int PrevX { get; set; }
        internal int PrevY { get; set; }

        // --- PointerEventHandlerForMesh --- //

        // 当前帧的焦点对象
        internal GameObject NowFocus { get; set; } = null;

        // 上一帧的焦点对象
        internal GameObject PrevFocus { get; set; } = null;

        // 当前帧的碰撞列表
        internal RaycastHit[] NowHits { get; set; } = new RaycastHit[0];

        // 上一帧的碰撞列表
        internal RaycastHit[] PrevHits { get; set; } = new RaycastHit[0];

        // 上一帧的按下对象
        internal List<GameObject> PrevDownObjects { get; set; } = new List<GameObject>( 128 );

        // 上一帧的按下对象被按下时的焦点状态
        internal List<bool> PrevDownObjectsFocusStatus { get; set; } = new List<bool>( 128 );

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //