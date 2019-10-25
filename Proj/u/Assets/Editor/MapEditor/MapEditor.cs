using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class MapEditor : EditorWindow
{
    public static GUIStyle toolbar;
    public static GUIStyle toolbarLabel;
    public static GUIStyle toolbarDropdown;
    public static GUIStyle toolbarButton;

    private Dictionary<int, System.Action> m_EventCallback = new Dictionary<int, System.Action>();

    public static Texture BgTexture;
    public static Texture InvisibleTex;
    public static Texture BlockTex;
    public static Texture NormalTex;
    //UI param
    Rect tex_bg_rect = new Rect(50, 50, 450, 300);
    Rect window_rect;
    private static MapEditor m_wind;
    public PageType Pagetype { get; set; }
    public enum PageType
    {
        Total,
        Editor,
        EditorSub,
    }

    //level data
    public uint curLevelId = 0;
    public LevelMapData Level_Data { get; set; }
    public  LevelMapArray Level_Config
    {
        get
        {
            return Level_Data.GetConfigByMapID(curLevelId);
        }
    }
    //[MenuItem("Editor/ReSetData")]
    //private static LevelMapData ReSetData()
    //{
    //    LevelMapData data = LevelLoader.Load();
    //    X.Res.LevelConfig_ARRAY dataarray = ResBinReader.Read<X.Res.LevelConfig_ARRAY>("LevelConfig");
    //    X.Res.LevelConfig level;
    //    LevelMapArray map;
    //    LevelMapData data2 = new LevelMapData();
    //    data2.Configs = new List<LevelMapArray>();
    //    data2.Name = data.Name;

    //    data2.Tools = new ToolMapArray();
    //    //data2.Tools.FillTypeArray = new string[1];
    //    data2.Tools.FillTypeMap = new Dictionary<string, int[]>();
    //    data2.Tools.WidthMap = new Dictionary<string, int>();
    //    data2.Tools.FillTypeMap.Add("0", new int[9]);
    //    data2.Tools.WidthMap.Add("0", 3);
    //    List<uint> list = new List<uint>();
    //    for (int i = 0; i < dataarray.Items.Count; i++)
    //    {
    //        level = dataarray.Items[i];
    //        map = data.GetConfigByID(level.LevelId);
    //        if (map == null)
    //        {
    //            map = new LevelMapArray();
    //            map.Id = level.LevelId;
    //        }
    //        data2.Configs.Add(map);
    //    }
    //    LevelLoader.Save(data2);
    //    return data2;
    //}
    [MenuItem("Editor/OpenMapEditor")]
    public static void OpenMapEditor()
    {
        Debug.Log("OpenMapEditor");
        // Get existing open window or if none, make a new one:
        MapEditor window = (MapEditor)EditorWindow.GetWindow(typeof(MapEditor));
        window.titleContent = new GUIContent("xMap");
        window.Show();
        window.isinit = false;
        window.window_rect = window.position;
        m_wind = window;
    }
    bool isinit = false;
    private void Init()
    {
        if (isinit)
        {
            return;
        }
        isinit = true;
        toolbar = GUI.skin.FindStyle("toolbar");
        toolbarButton = GUI.skin.FindStyle("toolbarButton");
        toolbarLabel = GUI.skin.FindStyle("toolbarButton");
        toolbarDropdown = GUI.skin.FindStyle("toolbarDropdown");

        m_EventCallback.Add((int)EventType.MouseDown, this.OnMouseClick);
        m_EventCallback.Add((int)EventType.MouseDrag, this.OnMouseCover);

        Level_Data = LevelLoader.Load();
        Pagetype = PageType.Total;
        EditorType = ToolType.None;

        string path = "Assets/Editor/Texture/Cell/{0}";
        string filepath = string.Format(path, "budong.png");
        BlockTex = EditorTool.LoadTextureFile(filepath);

        filepath = string.Format(path, "green.png");
        NormalTex = EditorTool.LoadTextureFile(filepath);

        filepath = string.Format(path, "jichugezi.png");
        InvisibleTex = EditorTool.LoadTextureFile(filepath);


        //shit
        SubMapEditorPage.IsInit = false;
        EditorPage.IsInit = false;
    }

    void OnGUI()
    {
        if (m_wind == null)
        {
            OpenMapEditor();
        }
        m_wind.Init();
        EditorGUILayout.BeginVertical();
        DrawToolbarGUI();//(new Rect(0,0,this.window_rect.width,50f));
        GUILayout.Space(30f);
        switch (Pagetype)
        {
            case PageType.Total:
                DataPage.OnGui(this);
                break;
            case PageType.Editor:
                EditorPage.OnGui(this);
                break;
            case PageType.EditorSub:
                SubMapEditorPage.OnGui(this);
                break;
            default:
                break;
        }
        EditorGUILayout.EndVertical();
        m_wind.HandleInput();
    }

    private void DrawToolbarGUI()
    {
        Rect rect = new Rect(0, 0, Screen.width, 50f);
        //rect.height = 50f;
        GUILayout.BeginArea(rect, MapEditor.toolbar);
        GUILayout.BeginHorizontal();
        //float curToolbarWidth = 0;
        //if (isEditorMap)
        {
            if (GUILayout.Button("File", MapEditor.toolbarDropdown, GUILayout.Width(50)))
            {
                GenericMenu menu = new UnityEditor.GenericMenu();
                //menu.AddSeparator("");
                menu.AddItem(new GUIContent("LoadTex"), false, () =>
                {
                    MapEditor.BgTexture = EditorTool.LoadTexture();
                });
                //menu.DropDown(new Rect(0, 0, 20, 30));
                menu.ShowAsContext();
            }


            if (GUILayout.Button("工具", MapEditor.toolbarDropdown, GUILayout.Width(75)))
            {
                GenericMenu menu = new UnityEditor.GenericMenu();
                //menu.AddSeparator("");
                menu.AddItem(new GUIContent("鼠标"), false, () => { this.SetState(0); });
                menu.AddItem(new GUIContent("笔刷"), false, () => { this.SetState(1); });
                menu.AddItem(new GUIContent("移动"), false, () => { this.SetState(2); });
                //menu.DropDown(new Rect(0, 0, 20, 30));
                menu.ShowAsContext();
            }
            string state = GetToolName();//new GUIContent(state, "当前编辑状态")
            GUILayout.Label("当前编辑状态:" + state,GUILayout.Width(200));
        }
        if ((Pagetype == PageType.Editor|| Pagetype == PageType.EditorSub) && EditorType == ToolType.Brush)
        {
            if (GUILayout.Button("选择格子类型", MapEditor.toolbarDropdown, GUILayout.Width(100)))
            {
                GenericMenu menu = new UnityEditor.GenericMenu();
                //menu.AddSeparator("");
                menu.AddItem(new GUIContent("不可见"), false, () => { this.SetCellType(0); });
                menu.AddItem(new GUIContent("阻挡"), false, () => { this.SetCellType(1); });
                menu.AddItem(new GUIContent("可编辑"), false, () => { this.SetCellType(2); });
                //menu.DropDown(new Rect(0, 0, 20, 30));
                menu.ShowAsContext();
            }
            string state = GetCellName();//new GUIContent(state, "当前编辑状态")
            GUILayout.Label("选定格子:" + state);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
    private Event curEvent;
    private void HandleInput()
    {
        curEvent = Event.current;
        Action ac = null;
        m_EventCallback.TryGetValue((int)curEvent.type, out ac);
        if (ac != null)
        {
            ac();
        }
    }
    //关于层级就按照检查顺序来吧，先是Grid，再bottom，最后底板
    private void OnMouseClick()
    {
        //Debug.Log(Event.current.mousePosition);
        //Debug.Log("OnMouseClick");
    }
    private void OnMouseCover()
    {
        //Debug.Log("OnMouseCover");
    }
    //[MenuItem("Editor/test")]
    //private static void Test()
    //{
    //    //string str = "fakeresources_data_levelconfig_json.xxx";
    //    //Debug.Log("==>"+XGamePath.GetAbNameByPath(str));
    //    //int[] array = new int[]
    //    //{
    //    //    0,1,2,
    //    //    3,4,5,
    //    //    6,7,8,
    //    //};
    //    //int[] array2 = MatrixUtil.MatrixTrans(3,3, 5, 4, array);
    //    //int[] array3 = MatrixUtil.MatrixTrans(3,3, 1, 4, array);
    //    //int[] array4 = MatrixUtil.MatrixTrans(3, 3, 1, 2, array);
    //    //Debug.Log(array2.ToString());
    //    //Debug.Log(array3.ToString());
    //    //Debug.Log(array4.ToString());
    //    //int i = 094;
    //    //LevelLoader.Test();
    //    //EditorUtility.DisplayPopupMenu(new Rect(0, 0, 100, 200), "111111", new MenuCommand());
    //}


    #region function
    /// <summary>
    /// 编辑器编辑流程，选择关卡ID，判断是否存在对应的地图，没有则填写参数后生成，有就生成对应的地图
    /// 根据配置 levelconfig 生成 地块
    /// 编辑模式有两种移动和笔刷
    /// </summary>

    public enum ToolType
    {
        None,
        Brush,
        Move,
    }
    public ToolType EditorType { get; private set; }

    //设置工具类型
    private void SetState(int type)
    {
        EditorType = (ToolType)type;
    }
    public  LevelMapArray.CellType CellType { get; private set; }

    //设置笔刷格子类型
    private void SetCellType(int type)
    {
        CellType = ( LevelMapArray.CellType)type;
    }
    private string GetToolName()
    {
        switch (EditorType)
        {
            case ToolType.None:
                return "鼠标";
            case ToolType.Brush:
                return "笔刷";
            case ToolType.Move:
                return "移动";
            default:
                return "???";
        }
    }
    private string GetCellName()
    {
        switch (CellType)
        {
            case  LevelMapArray.CellType.Invisible:
                return "不可见";
            case  LevelMapArray.CellType.Block:
                return "阻挡";
            case  LevelMapArray.CellType.Normal:
                return "可编辑";
            default:
                return "???";
        }
    }
    public void SaveEdit()
    {
        LevelLoader.Save(this.Level_Data);
    }
    public void DeleteConfig(int id)
    {
        LevelLoader.Save(this.Level_Data);
    }
    #endregion


}
static class EditorPage
{
    private static bool isEdit = false;
    private static bool isShowbg = false;
    private static void DrawToolbarGUI()
    {

    }
    private static bool isDo;
    public static bool IsInit = false;
    private static void Init(MapEditor wind)
    {
        if (IsInit)
        {
            return;
        }
        IsInit = true;
        GenGrid(wind.Level_Config);
    }
    public static void OnGui(MapEditor wind)
    {
        Init(wind);
        isDo = false;
         LevelMapArray config = wind.Level_Config;
        GUILayout.BeginHorizontal();
        if (isEdit)
        {
            isEdit = !GUILayout.Button("确认", GUILayout.Width(50));
        }
        else
        {
            isEdit = GUILayout.Button("编辑", GUILayout.Width(50));
        }
        if (isEdit)
        {
            int owidth = config.MapWidth;
            int oheight = config.MapHeight;
            GUILayout.Label("宽度:", GUILayout.Width(50));
            string tempx = GUILayout.TextField(config.MapWidth.ToString(), GUILayout.Width(50));
            config.MapWidth = int.Parse(tempx);
            GUILayout.Space(10f);
            GUILayout.Label("高度:", GUILayout.Width(50));
            tempx = GUILayout.TextField(config.MapHeight.ToString(), GUILayout.Width(50));
            config.MapHeight = int.Parse(tempx);
            config.FitArray(owidth,oheight);

            tempx = config.ConfigID.ToString();
            GUILayout.Label("对应配置表ID:", GUILayout.Width(100));
            tempx = GUILayout.TextField(tempx, GUILayout.Width(50));
            config.ConfigID = uint.Parse(tempx);

            config.FitArray(owidth, oheight);
            GUILayout.Label("格子大小:", GUILayout.Width(50));
            tempx = GUILayout.TextField(CellSize.ToString(), GUILayout.Width(50));
            CellSize = int.Parse(tempx);
            config.FitArray(owidth, oheight);
            GUILayout.Label("间距:", GUILayout.Width(50));
            tempx = GUILayout.TextField(CellOffset.ToString(), GUILayout.Width(50));
            CellOffset = int.Parse(tempx);
        }
        else
        {
            GUILayout.Label("宽度:", GUILayout.Width(50));
            GUILayout.Label("" + config.MapWidth, GUILayout.Width(50));
            GUILayout.Space(10f);
            GUILayout.Label("高度:", GUILayout.Width(50));
            GUILayout.Label("" + config.MapHeight, GUILayout.Width(50));
        }



        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("生成"))
        {
            GenGrid(config);
        }
        if (GUILayout.Button("读取底图"))
        {
            MapEditor.BgTexture = EditorTool.LoadTexture();
        }
        if (GUILayout.Button("保存"))
        {
            wind.SaveEdit();
        }
        if (GUILayout.Button("返回总览"))
        {
            IsInit = false;
            wind.Pagetype = MapEditor.PageType.Total;
            return;
        }
        if (!isShowbg && GUILayout.Button("显示底图")){
            isShowbg = true;
        }
        if (isShowbg && GUILayout.Button("显示网格"))
        {
            isShowbg = false;
        }
        GUILayout.EndHorizontal();
        ShowBg(wind);
        if (!isEdit&&!isShowbg)
        {
            ShowGrid(wind);
        }
        if (isDo)
        {
            //wind.SaveEdit();
        }
    }
    private static int CellSize = 30;
    private static int CellOffset = 2;
    private static Rect rect = new Rect(30f, 90f, CellSize, CellSize);
    private static List<Rect> list = new List<Rect>();
    private static Vector2 m_OriginPos;
    private static Vector2 offset = Vector2.zero;

    private static void GenGrid( LevelMapArray config)
    {
        int total = config.MapWidth * config.MapHeight;
        list.Clear();
        Rect rec = new Rect(30f, 90f, CellSize, CellSize); ;
        for (int i = 1; i <= total; i++)
        {
            list.Add(rec);
            if (i % config.MapWidth == 0)
            {
                rec.y += (CellSize + CellOffset);
                rec.x = rect.x;
            }
            else
            {
                rec.x += (CellSize + CellOffset);
            }
        }
    }
    private static Rect temprect;
    private static void ShowBg(MapEditor wind)
    {
        if (MapEditor.BgTexture)
        {
            temprect = new Rect(rect.position, new Vector2(MapEditor.BgTexture.width, MapEditor.BgTexture.height));
            GUI.Box(temprect, MapEditor.BgTexture);
        }
        else
        {
            int width = (CellSize + CellOffset) * wind.Level_Config.MapWidth;
            int heigth = (CellSize + CellOffset) * wind.Level_Config.MapHeight;
            temprect = new Rect(rect.position, new Vector2(width, heigth));
            GUI.Box(temprect, MapEditor.BgTexture);
        }

    }
    private static void ShowGrid(MapEditor wind)
    {        
        if (wind.EditorType == MapEditor.ToolType.Move && Event.current.type == EventType.MouseDown && temprect.Contains(Event.current.mousePosition))
        {
            m_OriginPos = Event.current.mousePosition;
            //Debug.Log("移动开始==>"+ m_OriginPos);
        }
        if (wind.EditorType == MapEditor.ToolType.Move && Event.current.type == EventType.MouseDrag && temprect.Contains(Event.current.mousePosition))
        {
            offset = Event.current.mousePosition - m_OriginPos;
            //Debug.Log("移动zhong==>"+ offset);
        }
        if (list.Count == 0)
        {
            return;
        }
        for (int i = 0; i < list.Count; i++)
        {
            Rect rect = list[i];
            if (wind.EditorType == MapEditor.ToolType.Brush && (Event.current.type == EventType.MouseDown || Event.current.type == EventType.MouseDrag) && rect.Contains(Event.current.mousePosition))
            {
                //Debug.Log("格子被选中==>" + i);
                wind.Level_Config.MapArray[i] = (int)wind.CellType;
                isDo = true;
            }
            Texture tex = null;
            switch (( LevelMapArray.CellType)wind.Level_Config.MapArray[i])
            {
                case  LevelMapArray.CellType.Invisible:
                    tex = MapEditor.InvisibleTex;
                    break;
                case  LevelMapArray.CellType.Block:
                    tex = MapEditor.BlockTex;
                    break;
                case  LevelMapArray.CellType.Normal:
                    tex = MapEditor.NormalTex;
                    break;
                default:
                    break;
            }

            GUI.Box(new Rect(list[i].position + offset, list[i].size), MapEditor.InvisibleTex);
            GUI.DrawTexture(new Rect(list[i].position + offset,list[i].size), tex, ScaleMode.StretchToFill, true);
        }
    }
}
static class DataPage
{
    private static List<LevelMapArray> m_deletegroup = new List< LevelMapArray>();
    private static Vector2 m_scroll = Vector2.zero;
    private static bool isaddmode = false;
    private static uint id = 0;
    public static void OnGui(MapEditor wind)
    {
        m_deletegroup.Clear();
        LevelMapData data = wind.Level_Data;
        m_scroll = GUILayout.BeginScrollView(m_scroll);
        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label(data.Name);
        GUILayout.Label("关卡数：" + data.Configs.Count);
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal();
        bool isadd = false;
        if (isaddmode)
        {
            string temp = "0";
            isadd = GUILayout.Button("确认");
            GUILayout.Label("关卡ID",GUILayout.Width(50));
            temp = GUILayout.TextField(id.ToString());
            id = uint.Parse(temp);
        }
        else
        {
            isaddmode = GUILayout.Button("添加",GUILayout.Width(50));
        }
        if (isadd)
        {
            AddConfig(wind, id);
            isaddmode = false;
        }
        if (GUILayout.Button("编辑工具格子", GUILayout.Width(150)))
        {
            wind.Pagetype = MapEditor.PageType.EditorSub;            
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("地图ID", GUILayout.Width(200));
        GUILayout.Label("对应的关卡ID", GUILayout.Width(250));
        GUILayout.Label("规格：", GUILayout.Width(200));
        GUILayout.EndHorizontal();

        foreach (var k in data.Configs)
        {
            ConfigItem.OnGui(k, wind);
        }
        GUILayout.EndVertical();
        GUILayout.EndScrollView();
        if (m_deletegroup.Count>0)
        {
            wind.Level_Data.DeleteConfig(m_deletegroup);
        }
    }
    static void AddConfig(MapEditor wind,uint id)
    {
         LevelMapArray config = new  LevelMapArray();
        config.Id = id;
        wind.Level_Data.Configs.Add(config);
        wind.SaveEdit();
    }
    static class ConfigItem
    {
        public static void OnGui( LevelMapArray config, MapEditor wind)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(config.Id.ToString());
            GUILayout.Label(string.Format("{0}", config.ConfigID));
            GUILayout.Label(string.Format("{0} X {1}", config.MapWidth, config.MapHeight));
            bool isEdit = GUILayout.Button("修改", GUILayout.Width(50));
            if (isEdit)
            {
                wind.curLevelId = config.Id;
                wind.Pagetype = MapEditor.PageType.Editor;
            }
            bool isDelete = GUILayout.Button("删除", GUILayout.Width(50));
            if (isDelete)
            {
                m_deletegroup.Add(config);
            }
            GUILayout.EndHorizontal();
        }
    }
}

static class SubMapEditorPage
{
    static byte m_selectIndex;
    public static string m_StrSelect
    {
        get
        {
            return m_selectIndex.ToString();
        }
        set
        {
            m_selectIndex = byte.Parse(value);
        }
    }
    static byte m_SelectIndex
    {
        get
        {
            return m_selectIndex;
        }
        set
        {
            if (m_selectIndex != value)
            {
                isdirty = true;
                m_selectIndex = value;
            }
        }
    }
    static bool isdirty = false;
    static bool isAddMode = false;
    static string tempSttr;
    static int m_Index;
    private static bool isEdit = false;
    private static bool isShowbg = false;
    private static void DrawToolbarGUI(MapEditor wind)
    {
        GUILayout.BeginVertical();
        OnTopTool(wind);
        OnTopTool2(wind);

        GUILayout.EndVertical();
    }
    private static bool isDo;
    public static bool IsInit = false;
    private static void Init(MapEditor wind)
    {
        if (IsInit)
        {
            return;
        }
        IsInit = true;
        m_StrSelect = "0";
        GenGrid(wind.Level_Data.Tools);
    }
    private static void OnTopTool(MapEditor wind)
    {
        Init(wind);
        ToolMapArray config = wind.Level_Data.Tools;
        GUILayout.BeginHorizontal();
        if (isEdit)
        {
            isEdit = !GUILayout.Button("确认", GUILayout.Width(50));
            GenGrid(config);
        }
        else
        {
            isEdit = GUILayout.Button("编辑", GUILayout.Width(50));
        }
        if (isEdit)
        {
            int owidth = config.WidthMap[m_StrSelect];
            int oheight = config.FillTypeMap[m_StrSelect].Length / owidth;

            GUILayout.Label("宽度:", GUILayout.Width(50));
            string tempx = GUILayout.TextField(owidth.ToString(), GUILayout.Width(50));
            int fwidth = int.Parse(tempx);
            config.WidthMap[m_StrSelect] = fwidth;
            GUILayout.Space(10f);

            GUILayout.Label("高度:", GUILayout.Width(50));
            tempx = GUILayout.TextField(oheight.ToString(), GUILayout.Width(50));
            int fheight = int.Parse(tempx);
            GUILayout.Space(10f);

            config.FitArray(owidth, oheight, fwidth, fheight, m_StrSelect);

            GUILayout.Label("格子大小:", GUILayout.Width(50));
            tempx = GUILayout.TextField(CellSize.ToString(), GUILayout.Width(50));
            CellSize = int.Parse(tempx);
            GUILayout.Label("间距:", GUILayout.Width(50));
            tempx = GUILayout.TextField(CellOffset.ToString(), GUILayout.Width(50));
            CellOffset = int.Parse(tempx);
        }
        else
        {
            int width = config.WidthMap[m_StrSelect];
            int height = config.FillTypeMap[m_StrSelect].Length / width;
            GUILayout.Label("宽度:", GUILayout.Width(50));
            GUILayout.Label("" + width, GUILayout.Width(50));
            GUILayout.Space(10f);
            GUILayout.Label("高度:", GUILayout.Width(50));
            GUILayout.Label("" + height, GUILayout.Width(50));
        }



        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("生成"))
        {
            GenGrid(config);
        }
        if (GUILayout.Button("读取底图"))
        {
            MapEditor.BgTexture = EditorTool.LoadTexture();
        }
        if (GUILayout.Button("保存"))
        {
            wind.SaveEdit();
        }
        if (GUILayout.Button("返回总览"))
        {
            IsInit = false;
            wind.Pagetype = MapEditor.PageType.Total;
            return;
        }
        if (!isShowbg && GUILayout.Button("显示底图"))
        {
            isShowbg = true;
        }
        if (isShowbg && GUILayout.Button("显示网格"))
        {
            isShowbg = false;
        }
        GUILayout.EndHorizontal();
    }
    private static void OnTopTool2(MapEditor wind)
    {
        ToolMapArray tool = wind.Level_Data.Tools;
        GUILayout.BeginHorizontal();
        if (isAddMode)
        {
            bool isadd = GUILayout.Button("确定", GUILayout.Width(75));
            GUILayout.Label("格子数目", GUILayout.Width(75));
            tempSttr = GUILayout.TextField(tempSttr, GUILayout.Width(75));
            if (isadd)
            {
                int length = int.Parse(tempSttr);
                tool.SetTypeLength(length);
                isAddMode = false;
            }
        }
        if (!isAddMode)
        {
            if (GUILayout.Button("添加", GUILayout.Width(75)))
            {
                tempSttr = tool.Length.ToString();
                isAddMode = true;
            }
            if (tool.Length == 0)
            {
                GUILayout.Label("需要添加工具格子", GUILayout.Width(100));
            }
            else
            {
                m_SelectIndex = (byte)EditorGUILayout.Popup(m_SelectIndex, tool.FillTypeArray, GUILayout.Width(100));
                if (isdirty)
                {
                    GenGrid(tool);
                    isdirty = false;
                }
            }
        }
            GUILayout.EndHorizontal();
    }
    public static void OnGui(MapEditor wind)
    {
        isDo = false;
        DrawToolbarGUI(wind);
        ShowBg(wind);
        if (!isEdit && !isShowbg)
        {
            ShowGrid(wind);
        }
        if (isDo)
        {
            //wind.SaveEdit();
        }
    }
    private static int CellSize = 30;
    private static int CellOffset = 2;
    private static Rect rect = new Rect(50f, 150f, CellSize, CellSize);
    private static List<Rect> list = new List<Rect>();
    private static Vector2 m_OriginPos;
    private static Vector2 offset = Vector2.zero;

    private static void GenGrid(ToolMapArray config)
    {
        int total = config.FillTypeMap[m_StrSelect].Length;
        list.Clear();
        Rect rec = new Rect(50f, 150f, CellSize, CellSize);
        for (int i = 1; i <= total; i++)
        {
            list.Add(rec);
            if (i % config.WidthMap[m_StrSelect] == 0)
            {
                rec.y += (CellSize + CellOffset);
                rec.x = rect.x;
            }
            else
            {
                rec.x += (CellSize + CellOffset);
            }
        }
    }
    private static Rect temprect;
    private static void ShowBg(MapEditor wind)
    {
        //if (MapEditor.BgTexture)
        //{
        //    temprect = new Rect(rect.position, new Vector2(MapEditor.BgTexture.width, MapEditor.BgTexture.height));
        //    GUI.Box(temprect, MapEditor.BgTexture);
        //}
        //else
        //{
        //    int width = (CellSize + CellOffset) * wind.Level_Config.MapWidth;
        //    int heigth = (CellSize + CellOffset) * wind.Level_Config.MapHeight;
        //    temprect = new Rect(rect.position, new Vector2(width, heigth));
        //    GUI.Box(temprect, MapEditor.BgTexture);
        //}

    }
    private static void ShowGrid(MapEditor wind)
    {
        if (wind.EditorType == MapEditor.ToolType.Move && Event.current.type == EventType.MouseDown && temprect.Contains(Event.current.mousePosition))
        {
            m_OriginPos = Event.current.mousePosition;
            //Debug.Log("移动开始==>"+ m_OriginPos);
        }
        if (wind.EditorType == MapEditor.ToolType.Move && Event.current.type == EventType.MouseDrag && temprect.Contains(Event.current.mousePosition))
        {
            offset = Event.current.mousePosition - m_OriginPos;
            //Debug.Log("移动zhong==>"+ offset);
        }
        if (list.Count == 0)
        {
            return;
        }
        for (int i = 0; i < list.Count; i++)
        {
            Rect rect = list[i];

            if (wind.EditorType == MapEditor.ToolType.Brush && (Event.current.type == EventType.MouseDown || Event.current.type == EventType.MouseDrag) && rect.Contains(Event.current.mousePosition))
            {
                //Debug.Log("格子被选中==>" + i);
                wind.Level_Data.Tools.FillTypeMap[m_StrSelect][i] = (int)wind.CellType;
                isDo = true;
            }
            Texture tex = null;
            switch ((LevelMapArray.CellType)wind.Level_Data.Tools.FillTypeMap[m_StrSelect][i])
            {
                case LevelMapArray.CellType.Invisible:
                    tex = MapEditor.InvisibleTex;
                    break;
                case LevelMapArray.CellType.Block:
                    tex = MapEditor.BlockTex;
                    break;
                case LevelMapArray.CellType.Normal:
                    tex = MapEditor.NormalTex;
                    break;
                default:
                    break;
            }

            GUI.Box(new Rect(list[i].position + offset, list[i].size), MapEditor.InvisibleTex);
            GUI.DrawTexture(new Rect(list[i].position + offset, list[i].size), tex, ScaleMode.StretchToFill, true);
        }
    }
}
public static class EditorTool
{
    public static Texture2D Tint(Texture2D tex, Color color)
    {
        Texture2D tintedTex = UnityEngine.Object.Instantiate(tex);
        for (int x = 0; x < tex.width; x++)
            for (int y = 0; y < tex.height; y++)
                tintedTex.SetPixel(x, y, tex.GetPixel(x, y) * color);
        tintedTex.Apply();
        return tintedTex;
    }

    public static Texture LoadTexture()
    {
        string path = EditorUtility.OpenFilePanel("Load Node Canvas", Application.dataPath, "png");
        if (!path.Contains(Application.dataPath))
        {
            //if (!string.IsNullOrEmpty(path))
            //    ShowNotification(new GUIContent("You should select an asset inside your project folder!"));
        }
        else
        {
            if (File.Exists(path))
            {
                return LoadTextureFile(path);
            }
            else
            {
                //EditorUtility.DisplayPopupMenu(new Rect(0, 0, 100, 200), "111111", new MenuCommand(this));
                Debug.Log("???");
            }
        }
        return null;
    }
    public static Texture LoadTextureFile(string filepath)
    {
        filepath = filepath.Substring(filepath.LastIndexOf("Asset"));
        Texture tex = AssetDatabase.LoadAssetAtPath<Texture>(filepath);
        if (tex == null)
        {
            Debug.Log("读不到图啊==>" + filepath);
        }
        return tex;
    }
}
