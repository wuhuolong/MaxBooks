// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using NF.Core.Event.Handler;

/// <summary> 事件管理 </summary>
[EditorBrowsable( EditorBrowsableState.Never )]
public sealed class EventManager : NeroObject {

    // --- Field & Property ----------------------------------------------------------------------------------------------------------------------------------------------- //

    /// <summary> 启用或禁用全部键盘按键侦听 </summary>
    public bool EnableAllKeyboardListener { get; set; } = true;

    /// <summary> 启用或禁用全部 UI 指针事件侦听 </summary>
    public bool EnableAllPointerListenerForUI { get; set; } = true;

    /// <summary> 启用或禁用全部 Mesh 指针事件侦听 </summary>
    public bool EnableAllPointerListenerForMesh { get; set; } = true;

    /// <summary> 启用或禁用全部 Screen 指针事件侦听 </summary>
    public bool EnableAllPointerListenerForScreen { get; set; } = true;

    // --- Public & Protected Function ------------------------------------------------------------------------------------------------------------------------------------ //

    /// <summary> 添加自定义事件侦听 </summary>
    /// <param name="customEventType">自定义事件类型 ( 自动忽略英文大小写和空格 ) </param>
    /// <param name="listener">自定义事件侦听函数 ( Params - 事件附带数据 ) </param>
    /// <param name="autoRemove">设置是否自动移除侦听，为 true 时，触发一次事件后自动移除侦听，默认为 false</param>
    /// <param name="priority">设置侦听函数执行优先级，数值越高优先级越高。同数值情况下，先添加的侦听函数优先级更高，默认为 0 </param>
    public void AddCustomEventListener( string customEventType , Action<object> listener , bool autoRemove = false , int priority = 0 )
        => CustomEventHandler.AddListener( customEventType , listener , autoRemove , priority );

    /// <summary> 移除自定义事件侦听 </summary>
    /// <param name="customEventType">自定义事件类型 ( 自动忽略英文大小写和空格 ) </param>
    /// <param name="listener">自定义事件侦听函数 ( Params - 自定义事件类型，事件附带数据 ) </param>
    public void RemoveCustomEventListener( string customEventType , Action<object> listener )
        => CustomEventHandler.RemoveListener( customEventType , listener );

    /// <summary> 派发自定义事件 </summary>
    /// <param name="customEventType">自定义事件类型 ( 自动忽略英文大小写和空格 ) </param>
    /// <param name="data">事件附带数据，此数据将作为参数传入事件侦听函数，默认为 null</param>
    public void DispatchCustomEvent( string customEventType , object data = null )
        => CustomEventHandler.DispatchEvent( customEventType , data );

    /// <summary> 添加帧循环事件侦听 </summary>
    /// <param name="listener">帧循环事件侦听函数</param>
    /// <param name="priority">设置侦听函数执行优先级，数值越高优先级越高。同数值情况下，先添加的侦听函数优先级更高，默认为 0 </param>
    public void AddFrameLoopListener( Action listener , int priority = 0 )
        => FrameLoopEventHandler.AddListener( listener , priority );

    /// <summary> 移除帧循环事件侦听 </summary>
    /// <param name="listener">帧循环事件侦听函数</param>
    public void RemoveFrameLoopListener( Action listener )
        => FrameLoopEventHandler.RemoveListener( listener );

    /// <summary> 添加时间间隔事件侦听</summary>
    /// <param name="listener">时间间隔事件侦听函数</param>
    /// <param name="interval">设置触发间隔 ( 单位：秒 ) </param>
    /// <param name="times">设置事件可触发的总次数，默认为 0 时为不限次数</param>
    public void AddIntervalListener( Action listener , double interval , int times = 0 )
        => IntervalEventHandler.AddListener( listener , interval , times );

    /// <summary> 移除时间间隔事件侦听 </summary>
    /// <param name="listener">时间间隔事件侦听函数</param>
    public void RemoveIntervalListener( Action listener )
        => IntervalEventHandler.RemoveListener( listener );

    /// <summary> 添加键盘按键事件侦听 </summary>
    /// <param name="keyCode">侦听的按键键值</param>
    /// <param name="listener">键盘按键事件侦听函数 ( Params - 侦听按键键值，按键事件类型 ) </param>
    /// <param name="priority">设置侦听函数执行优先级，数值越高优先级越高。同数值情况下，先添加的侦听函数优先级更高，默认为 0 </param>
    public void AddKeyboardListener( KeyCode keyCode , Action<KeyCode , KeyboardEventType> listener , int priority = 0 )
        => KeyboardEventHandler.AddListener( keyCode , listener , priority );

    /// <summary> 移除键盘按键事件侦听 </summary>
    /// <param name="keyCode">侦听的按键键值</param>
    /// <param name="listener">键盘按键事件侦听函数 ( Params - 侦听按键键值，按键事件类型 ) </param>
    public void RemoveKeyboardListener( KeyCode keyCode , Action<KeyCode , KeyboardEventType> listener )
        => KeyboardEventHandler.RemoveListener( keyCode , listener );

    /// <summary> 添加指针交互事件侦听 ( UI ) </summary>
    /// <param name="target">侦听对象 ( UGUI GameObject ) </param>
    /// <param name="listener">指针交互事件侦听函数 ( Params - 侦听对象，指针交互数据 ) </param>
    /// <param name="priority">设置侦听函数执行优先级，数值越高优先级越高。同数值情况下，先添加的侦听函数优先级更高，默认为 0 </param>
    public void AddPointerListenerForUI( GameObject target , Action<GameObject , PointerData> listener , int priority = 0 )
        => PointerEventHandlerForUI.AddListener( target , listener , priority );

    /// <summary> 移除指针交互事件侦听 ( UI ) </summary>
    /// <param name="target">侦听对象 ( UGUI GameObject ) </param>
    /// <param name="listener">指针交互事件侦听函数 ( Params - 侦听对象，指针交互数据 ) </param>
    public void RemovePointerListenerForUI( GameObject target , Action<GameObject , PointerData> listener )
        => PointerEventHandlerForUI.RemoveListener( target , listener );

    /// <summary> 添加指针交互事件侦听 ( Mesh ) </summary>
    /// <param name="target">侦听对象 ( Mesh GameObject ) </param>
    /// <param name="listener">指针交互事件侦听函数 ( Params - 侦听对象，指针交互数据，射线碰撞数据 ) </param>
    /// <param name="ignoreOcclusion">设置是否忽略遮挡。为 false 时，被其他 3D 对象遮挡的侦听对象将不会触发事件，默认为 false </param>
    /// <param name="priority">设置侦听函数执行优先级，数值越高优先级越高。同数值情况下，先添加的侦听函数优先级更高，默认为 0 </param>
    public void AddPointerListenerForMesh( GameObject target , Action<GameObject , PointerData , RaycastHit> listener , bool ignoreOcclusion = false , int priority = 0 )
        => PointerEventHandlerForMesh.AddListener( target , listener , ignoreOcclusion , priority );

    /// <summary> 移除指针交互事件侦听 ( Mesh ) </summary>
    /// <param name="target">侦听对象 ( Mesh GameObject ) </param>
    /// <param name="listener">指针交互事件侦听函数 ( Params - 侦听对象，指针交互数据，射线碰撞数据 ) </param>
    public void RemovePointerListenerForMesh( GameObject target , Action<GameObject , PointerData , RaycastHit> listener )
        => PointerEventHandlerForMesh.RemoveListener( target , listener );

    /// <summary> 添加指针交互事件侦听 ( Screen )</summary>
    /// <param name="listener">指针交互事件侦听函数 ( Params - 指针事件数据 ) </param>
    /// <param name="priority">设置侦听函数执行优先级，数值越高优先级越高。同数值情况下，先添加的侦听函数优先级更高，默认为 0 </param>
    public void AddPointerListenerForScreen( Action<PointerData> listener , int priority = 0 )
        => PointerEventHandlerForScreen.AddListener( listener , priority );

    /// <summary> 移除指针交互事件侦听 ( Screen ) </summary>
    /// <param name="listener">指针交互事件侦听函数 ( Params - 指针事件数据 ) </param>
    public void RemovePointerListenerForScreen( Action<PointerData> listener )
        => PointerEventHandlerForScreen.RemoveListener( listener );

    /// <summary> 添加碰撞事件侦听 ( Mesh ) </summary>
    /// <param name="target">侦听对象 ( Mesh GameObject ) </param>
    /// <param name="listener">碰撞事件侦听函数 ( Params - 侦听对象，碰撞事件类型，碰撞数据 ) </param>
    /// <param name="priority">设置侦听函数执行优先级，数值越高优先级越高。同数值情况下，先添加的侦听函数优先级更高，默认为 0 </param>
    public void AddCollisionListenerForMesh( GameObject target , Action<GameObject , CollisionEventType , Collision> listener , int priority = 0 )
        => CollisionEventHandler.AddListener( target , listener , priority );

    /// <summary> 移除碰撞事件侦听 ( Mesh ) </summary>
    /// <param name="target">侦听对象 ( Mesh GameObject ) </param>
    /// <param name="listener">碰撞事件侦听函数 ( Params - 侦听对象，碰撞事件类型，碰撞数据 ) </param>
    public void RemoveCollisionListenerForMesh( GameObject target , Action<GameObject , CollisionEventType , Collision> listener )
        => CollisionEventHandler.RemoveListener( target , listener );

    /// <summary> 添加触发器事件侦听 ( Mesh ) </summary>
    /// <param name="target">侦听对象 ( Mesh GameObject ) </param>
    /// <param name="listener">触发器事件侦听函数 ( Params - 侦听对象，触发器事件类型，触发触发器的对象 ) </param>
    /// <param name="priority">设置侦听函数执行优先级，数值越高优先级越高。同数值情况下，先添加的侦听函数优先级更高，默认为 0 </param>
    public void AddTriggerListenerForMesh( GameObject target , Action<GameObject , TriggerEventType , GameObject> listener , int priority = 0 )
        => TriggerEventHandler.AddListener( target , listener , priority );

    /// <summary> 移除触发器事件侦听 ( Mesh ) </summary>
    /// <param name="target">侦听对象 ( Mesh GameObject ) </param>
    /// <param name="listener">触发器事件侦听函数 ( Params - 侦听对象，触发器事件类型，触发触发器的对象 ) </param>
    public void RemoveTriggerListenerForMesh( GameObject target , Action<GameObject , TriggerEventType , GameObject> listener )
        => TriggerEventHandler.RemoveListener( target , listener );

    /// <summary> 添加屏幕缩放事件侦听 </summary>
    /// <param name="listener">屏幕缩放事件侦听函数 ( Params - 当前屏幕宽度，当前屏幕高度 ) </param>
    /// <param name="priority">设置侦听函数执行优先级，数值越高优先级越高。同数值情况下，先添加的侦听函数优先级更高，默认为 0 </param>
    public void AddScreenResizeListener( Action<int , int> listener , int priority = 0 )
        => ScreenResizeEventHandler.AddListener( listener , priority );

    /// <summary> 移除屏幕缩放事件侦听 </summary>
    /// <param name="listener">屏幕缩放事件侦听函数 ( Params - 当前屏幕宽度，当前屏幕高度 ) </param>
    public void RemoveScreenResizeListener( Action<int , int> listener )
        => ScreenResizeEventHandler.RemoveListener( listener );

    /// <summary> 添加程序焦点事件侦听 </summary>
    /// <param name="listener">程序焦点事件侦听函数 ( Params - 程序焦点状态 ) </param>
    /// <param name="priority">设置侦听函数执行优先级，数值越高优先级越高。同数值情况下，先添加的侦听函数优先级更高，默认为 0 </param>
    public void AddFocusListener( Action<bool> listener , int priority = 0 )
        => FocusEventHandler.AddListener( listener , priority );

    /// <summary> 移除程序焦点事件侦听 </summary>
    /// <param name="listener">程序焦点事件侦听函数 ( Params - 程序焦点状态 ) </param>
    public void RemoveFocusListener( Action<bool> listener )
       => FocusEventHandler.RemoveListener( listener );

    /// <summary> 添加代码追踪事件侦听 </summary>
    /// <param name="listener">代码追踪事件侦听函数 ( Params - 代码追踪数据 ) </param>
    /// <param name="priority">设置侦听函数执行优先级，数值越高优先级越高。同数值情况下，先添加的侦听函数优先级更高，默认为 0 </param>
    public void AddTraceListener( Action<TraceData> listener , int priority = 0 )
        => TraceEventHandler.AddListener( listener , priority );

    /// <summary> 移除代码追踪事件侦听 </summary>
    /// <param name="listener">代码追踪事件侦听函数 ( Params - 代码追踪数据 ) </param>
    public void RemoveTraceListener( Action<TraceData> listener )
        => TraceEventHandler.RemoveListener( listener );

    // --- Internal Function ---------------------------------------------------------------------------------------------------------------------------------------------- //

    // 封闭构造函数
    internal EventManager() { }

    // 主线程循环
    internal static void MainThreadUpdate() {
        FocusEventHandler.MainThreadUpdate();
        ScreenResizeEventHandler.MainThreadUpdate();
        CollisionEventHandler.MainThreadUpdate();
        TriggerEventHandler.MainThreadUpdate();
        PointerEventHandlerForScreen.MainThreadUpdate();
        PointerEventHandlerForUI.MainThreadUpdate();
        PointerEventHandlerForMesh.MainThreadUpdate();
        KeyboardEventHandler.MainThreadUpdate();
        FrameLoopEventHandler.MainThreadUpdate();
        IntervalEventHandler.MainThreadUpdate();
        CustomEventHandler.MainThreadUpdate();
        TraceEventHandler.MainThreadUpdate();
    }

    // --- Private Function ----------------------------------------------------------------------------------------------------------------------------------------------- //

}


// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //