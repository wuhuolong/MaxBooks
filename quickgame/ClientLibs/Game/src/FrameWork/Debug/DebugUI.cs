using System.Collections.Generic;
using System.Text;
using UnityEngine;
using xc;
using xc.ui.ugui;

public class DebugUI : MonoBehaviour
{
    public bool DrawPing = false;
    public bool DrawActorCount = false;

    public bool DrawWindowName = false;
    public Color DrawWindowNameColor = Color.yellow;


    /// <summary>
    /// 是否显示触摸点的数量
    /// </summary>
    public bool DrawTouchCount = false;
    public float FPSUpdateWaitTime;

    public bool DrawSnapshotUI = false;

    private int std_h = 768;
    private int std_w = Screen.width * 768 / Screen.height;

    public struct Command
    {
        public string main;
        public List<string> paramArray;

        public void Add(string v)
        {
            if (paramArray == null)
                paramArray = new List<string>();
            paramArray.Add(v);
        }
    }

    public static Command NewCommand(string name)
    {
        Command c = new Command();
        c.main = name;
        return c;
    }

    public delegate bool ProcessCmdDelegate(Command cmd);

    public string NotifyMsg
    {
        set { mNotiyMsg = value; }
    }

    protected LinkedList<string> mLogList;
    protected string mNotiyMsg = "";
    protected List<string> mCmdHistory = new List<string>();
    protected int mCmdHistoryIdx = -1;
    private bool mProcHistoryCmd = false;

    //static protected string mLogList;
    protected string mCommand;

    protected List<ProcessCmdDelegate> mCmdProcesor;
    protected bool mShowConsole;
    protected int mLastFinger;
    protected Vector2 mBeginTouchPos;
    protected Vector2 mMovedTouch;
    protected float mTouchTime;
    protected int mTouchOPFrame;
    protected Vector2 mCurWorldPos;
    protected int mTouchScrolOffset = 0;
    protected bool mTouchEnd = false;
    protected int mLogBeginY = 0;

    public void SubscribeProcessCmd(ProcessCmdDelegate func)
    {
        mCmdProcesor.Add(func);
    }

    public void UnsubscribeProcessCmd(ProcessCmdDelegate func)
    {
        mCmdProcesor.Remove(func);
    }

    public void UnsubscribeAllProcessCmd()
    {
        mCmdProcesor.Clear();
    }

    public void PushLog(string log, LogType type = LogType.Log)
    {
        mLogList.AddLast(log);
        if (mLogList.Count > 1000)
            mLogList.RemoveFirst();
        //mLogList = mLogList+"\n"+log;
    }

    public void Clear()
    {
        mLogList.Clear();
        //mLogList = "";
    }

    private void Awake()
    {
        mCommand = "";
        mShowConsole = false;
        mLastFinger = -1;
        mTouchOPFrame = 0;
        mTouchTime = -1;

        if (FPSUpdateWaitTime == 0)
            FPSUpdateWaitTime = 0.5f;

        if (mLogList == null)
            mLogList = new LinkedList<string>();
        mCmdProcesor = new List<ProcessCmdDelegate>();
    }

    public void OnLog(string log, string stackTrace, LogType type)
    {
        PushLog(System.String.Format("[{0}] {1}", type.ToString(), log));
        if (type == LogType.Assert || type == LogType.Error || type == LogType.Exception)
        {
            PushLog("-------------------Call Stack:------------------");
            string[] lines = stackTrace.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string l in lines)
            {
                PushLog(l);
            }
            PushLog("------------------------------------------------");
        }
    }

    Rect result = new Rect();
    private Rect Scale(Rect rect)
    {
        result.x = Screen.width * rect.x / std_w;
        result.width = Screen.width * rect.width / std_w;
        result.y = Screen.height * rect.y / std_h;
        result.height = Mathf.Max(Screen.height * rect.height / std_h, 25);

        rect.x = result.x;
        rect.width = result.width;
        rect.y = result.y;
        rect.height = result.height;

        return rect;
    }

    private float GetHeightScale()
    {
        return Screen.height / std_h;
    }

    private float GetWidthScale()
    {
        return Screen.width / std_w;
    }

    object[] mLuaParam = { };
    Rect mLuaMemoryRect = new Rect(10, Screen.height - 40, 200, 20);
    Rect mSnapshotPointA = new Rect(10, Screen.height - 100, 120, 20);
    Rect mSnapshotPointB =  new Rect(10, Screen.height - 60, 120, 20);

    private void OnGUI()
    {
        // 输入历史
        if (mCmdHistory.Count > 0)
        {
            if (Event.current.type == EventType.KeyDown)
            {
                if (Event.current.keyCode == KeyCode.UpArrow)
                {
                    if (mCmdHistoryIdx < 0)
                        mCmdHistoryIdx = mCmdHistory.Count - 1;
                    else
                        --mCmdHistoryIdx;

                    mProcHistoryCmd = true;
                }
                else if (Event.current.keyCode == KeyCode.DownArrow)
                {
                    if (mCmdHistoryIdx < 0)
                        mCmdHistoryIdx = mCmdHistory.Count - 1;
                    else
                        ++mCmdHistoryIdx;

                    mProcHistoryCmd = true;
                }
            }

            if (mProcHistoryCmd)
            {
                mCmdHistoryIdx = Mathf.Clamp(mCmdHistoryIdx, 0, mCmdHistory.Count - 1);
                mCommand = mCmdHistory[mCmdHistoryIdx];
            }
        }

        if (DrawPing)
        {
            Rect rt = new Rect(Screen.width - 100, 50, 80, 22);
            int ms = (int)(xc.PingTime.GetInstance().DelayTime * 1000);
            string text = "Ping: " + ms.ToString() + " ms";

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.green;
            style.alignment = TextAnchor.MiddleRight;
            GUI.Label(rt, text, style);
        }

        if (DrawActorCount)
        {
            Rect rt = new Rect(Screen.width - 100, 90, 80, 22);
            uint actor_count = xc.CullManager.Instance.ActorNum;
            uint visible_count = xc.CullManager.Instance.VisibleActorNum;
            string text = string.Format("Player - Total Num: {0} Show Num: {1}/{2}", xc.ActorManager.Instance.PlayerSet.Count, visible_count, actor_count);

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.yellow;
            style.alignment = TextAnchor.MiddleRight;
            GUI.Label(rt, text, style);
        }

        if (DrawTouchCount)
        {
            Rect rt = new Rect(Screen.width - 100, 130, 80, 22);
            string text = string.Format("Touch Count: {0}", Input.touchCount);

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.yellow;
            style.alignment = TextAnchor.MiddleRight;
            GUI.Label(rt, text, style);
        }

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if (DrawWindowName)
        {
            Rect rt = new Rect(Screen.width - 300, 0, 300, Screen.height);
            var allWindows = UIManager.GetInstance().AllWindow;
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, UIBaseWindow> baseWindow in allWindows)
            {
                if (baseWindow.Value.IsShow == true)
                    sb.AppendLine(baseWindow.Key);
            }

            GUIStyle style = new GUIStyle();
            style.normal.textColor = DrawWindowNameColor;
            style.fontSize = 18;
            style.alignment = TextAnchor.UpperRight;
            GUI.Button(rt, "");
            GUI.Label(rt, sb.ToString(), style);
            
        }
#endif

        GUI.Label(mLuaMemoryRect, string.Format("Lua Memory: {0}Kb", LuaScriptMgr.Instance.Lua.Memroy));
        if (DrawSnapshotUI == true)
        {
            if (GUI.Button(Scale(mSnapshotPointA), "SnapshotPointA"))
            {
                var objs = LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "MemorySnapShotStart", mLuaParam);
            }

            if (GUI.Button(Scale(mSnapshotPointB), "SnapshotPointB"))
            {
                var objs = LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "MemorySnapShotEnd", mLuaParam);
            }
        }

        if (mNotiyMsg.Length > 0)
        {
            Rect rt = new Rect(20, 50, 200, 22);

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.green;
            style.alignment = TextAnchor.MiddleLeft;
            GUI.Label(rt, mNotiyMsg, style);
        }

        bool bEnterInput = false;
        bool bToggleConsole = false;

        if (mShowConsole)
        {
            int screenHeight = std_h;//Screen.height;
            int screenWidth = std_w;//Screen.width;
            int x = 10;
            int y = screenHeight - 75;
            int w = screenWidth - 20;
            int h = 25;

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.green;
            style.fontSize = (int)(style.fontSize * GetHeightScale());
            style.alignment = TextAnchor.MiddleLeft;

            string prevCmd = mCommand;
            Rect inputRect = Scale(new Rect(x, y + 25, w - 160, h));
            mCommand = GUI.TextField(inputRect, mCommand);
            if (mCommand.ToLower() != prevCmd.ToLower())
                mProcHistoryCmd = false;
            if (GUI.Button(Scale(new Rect(x + w - 160, y + 25, 80, h)), "Enter"))
                bEnterInput = true;
            if (GUI.Button(Scale(new Rect(x + w - 160 + 80, y + 25, 80, h)), "Close"))
                bToggleConsole = true;

            // 增加偏移，可触摸滚动
            y -= 4;
            int logStartY = y;
            if (mLogBeginY == 0)
                mLogBeginY = y;
            y = mLogBeginY;

            Color backgroundColorBackup = GUI.backgroundColor;
            Color colorBackup = GUI.color;

            if (mLogList.Count > 0)
            {
                LinkedListNode<string> node = mLogList.Last;
                for (; node != null && y >= -5; node = node.Previous)
                {
                    if (y < logStartY)
                    {
                        string content = node.Value;

                        Rect labelRect = Scale(new Rect(x, y, w, h));

                        GUI.Label(labelRect, content, style);
                    }

                    y -= 25;
                }
            }

            GUI.color = colorBackup;
            GUI.backgroundColor = backgroundColorBackup;

            // Process touch.
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    mBeginTouchPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    mTouchEnd = true;
                }
                else
                {
                    Vector2 deltaPos = touch.position - mBeginTouchPos;
                    mBeginTouchPos = touch.position;
                    mLogBeginY += -(int)deltaPos.y;
                }
            }
            else if (Input.touchCount == 0)
            {
                if (Input.GetMouseButton(0))
                {
                    Vector2 curPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                    if (mTouchEnd)
                    {
                        mBeginTouchPos = curPos;
                        mTouchEnd = false;
                    }

                    Vector2 deltaPos = curPos - mBeginTouchPos;
                    mBeginTouchPos = curPos;
                    mLogBeginY += -(int)deltaPos.y;
                }
                else
                {
                    mTouchEnd = true;
                }
            }
        }
        else
        {
            if (GUI.Button(Scale(new Rect(10, 120, 60, 35)), "<<"))
                bToggleConsole = true;
        }

        if (Event.current.type == EventType.KeyDown)
        {
            if (Event.current.character == '\n')
            {
                bEnterInput = true;
            }
            else if (Event.current.keyCode == KeyCode.Tab)
            {
                bToggleConsole = true;
            }
        }
        if (IsCombinationKey(EventModifiers.Shift, KeyCode.P, EventType.KeyUp))
        {
            DrawWindowName = !DrawWindowName;

        }
        if (IsCombinationKey(EventModifiers.Shift, KeyCode.R, EventType.KeyUp))
        {
            DrawWindowNameColor = Color.red;

        }
        if (IsCombinationKey(EventModifiers.Shift, KeyCode.G, EventType.KeyUp))
        {
            DrawWindowNameColor = Color.green;

        }
        if (IsCombinationKey(EventModifiers.Shift, KeyCode.W, EventType.KeyUp))
        {
            DrawWindowNameColor = Color.white;

        }
        if (IsCombinationKey(EventModifiers.Shift, KeyCode.Y, EventType.KeyUp))
        {
            DrawWindowNameColor = Color.yellow;

        }

        if (IsCombinationKey(EventModifiers.Shift, KeyCode.F1, EventType.KeyUp))
        {
            xc.ui.ugui.UIManager.Instance.CloseAllWindow();
        }
        else if (IsCombinationKey(EventModifiers.Shift, KeyCode.F2, EventType.KeyUp))
        {
            xc.ui.ugui.UIManager.Instance.ShowAllWindow();
        }
        else if (IsCombinationKey(EventModifiers.Shift, KeyCode.F3, EventType.KeyUp))
        {
            Net.C2SChatCommon data = new Net.C2SChatCommon();
            data.type = GameConst.CHAT_BCAST_ALL;
            data.info = new Net.PkgChatC2S();
            data.info.content = System.Text.Encoding.UTF8.GetBytes("#group_drop&41");
            Net.NetClient.GetBaseClient().SendData<Net.C2SChatCommon>(xc.protocol.NetMsg.MSG_CHAT_COMMON, data);
        }
        else if (IsCombinationKey(EventModifiers.Shift, KeyCode.F4, EventType.KeyUp))
        {
            Net.C2SChatCommon data = new Net.C2SChatCommon();
            data.type = GameConst.CHAT_BCAST_ALL;
            data.info = new Net.PkgChatC2S();
            data.info.content = System.Text.Encoding.UTF8.GetBytes("#lv_up");
            Net.NetClient.GetBaseClient().SendData<Net.C2SChatCommon>(xc.protocol.NetMsg.MSG_CHAT_COMMON, data);
        }

        if (bEnterInput)
        {
            ProcessCommand(mCommand);

            // 保存输入历史
            if (!mProcHistoryCmd)
            {
                mCmdHistory.Add(mCommand);
                mCmdHistoryIdx = mCmdHistory.Count;
            }
            else
            {
                ++mCmdHistoryIdx;
            }

            mProcHistoryCmd = false;

            mCommand = "";
        }

        if (bToggleConsole)
            mShowConsole = !mShowConsole;
    }

    /// <summary>
    /// 判断组合按键
    /// </summary>
    /// <param name="prekey"></param>
    /// <param name="postkey"></param>
    /// <param name="postkeyevent"></param>
    /// <returns></returns>
    private bool IsCombinationKey(EventModifiers prekey, KeyCode postkey, EventType postkeyevent)
    {
        if (prekey != EventModifiers.None)
        {
            bool eventDown = (Event.current.modifiers & prekey) != 0;
            if (eventDown && Event.current.rawType == postkeyevent && Event.current.keyCode == postkey)
            {
                Event.current.Use();

                if (postkey != KeyCode.None)
                    Debug.Log(string.Format("{0} + {1}", prekey.ToString(), postkey.ToString()));
                else
                    Debug.Log(string.Format("{0} + {1}", prekey.ToString(), postkeyevent.ToString()));

                return true;
            }
        }
        else
        {
            if (Event.current.rawType == postkeyevent && Event.current.keyCode == postkey)
            {
                Event.current.Use();

                if (postkey != KeyCode.None)
                    Debug.Log(string.Format("{0}", postkey.ToString()));
                else
                    Debug.Log(string.Format("{0}", postkeyevent.ToString()));

                return true;
            }
        }
        return false;
    }

    public void ProcessCommand(string text)
    {
        int i = 0;
        DebugUI.Command cmd = new Command();
        cmd.paramArray = new List<string>();

        string[] substr = text.Split(' ');

        for (i = 0; i < substr.Length; ++i)
        {
            string cur = substr[i];
            if (i == 0)
                cmd.main = cur;
            else
                cmd.paramArray.Add(cur);
        }

        bool anyoneProcessed = false;
        for (i = 0; i < mCmdProcesor.Count; ++i)
        {
            if (cmd.main.Length > 0)
            {
                if (mCmdProcesor[i](cmd))
                    anyoneProcessed = true;
            }
        }

        if (!anyoneProcessed)
            PushLog("Invalid command!");
    }
}