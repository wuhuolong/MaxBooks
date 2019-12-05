using Net;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using xc;
using xc.debug;
using xc.ui.ugui;
using PackData = xc.PackRecorder.PackData;

public class DebugWindow : MonoBehaviour
{

    private GameObject contentPanel;
    private GameObject togglePanel;

    private DebugBasePanel commandPanel;
    private LogPanel logPanel;
    private NetPanel netPanel;

    private Text txtArrow;


    private RectTransform panelRect;
    private List<DebugBasePanel> panelList;
    private bool isHide = true;
    private Button btnClick;

    private int curSelect = 2;

    private UICacheManager uicache;

    public UICacheManager cache
    {
        get {
            if (uicache == null)
            {
                uicache = new UICacheManager();
            }

            return uicache;
        }
    }


    private void Awake()
    {
        panelList = new List<DebugBasePanel>();

        panelRect = this.transform.Find("Panel").GetComponent<RectTransform>();

        contentPanel = this.transform.Find("Panel/Content").gameObject;
        togglePanel = this.transform.Find("Panel/TogglePanel").gameObject;

        logPanel = new LogPanel(this.transform.Find("Panel/Content/LogPanel").gameObject, this);
        commandPanel = new CommandPanel(this.transform.Find("Panel/Content/CommandPanel").gameObject, this);
        netPanel = new NetPanel(this.transform.Find("Panel/Content/NetPanel").gameObject, this);


        panelList.Add(logPanel);
        panelList.Add(commandPanel);
        panelList.Add(netPanel);



        for (int i = 1; i <= 3; i++)
        {
            var btnObj = this.transform.Find("Panel/TogglePanel/Toggle" + i);
            if (btnObj)
            {
                int index = i;
                btnObj.GetComponent<Button>().onClick.AddListener(() =>
                {
                    this.curSelect = index;
                    HideAllPanels();
                    ShowPanel(index);
                });
            }
        }


        btnClick = this.transform.Find("Panel/Button").GetComponent<Button>();
        btnClick.onClick.AddListener(() =>
        {
            if (isHide)
            {
                ShowWindow();
            }
            else
            {
                HideWindow();
            }
        });


        txtArrow = btnClick.gameObject.transform.Find("Text").GetComponent<Text>();

        HideWindow();
    }

    private void ShowWindow()
    {
        contentPanel.SetActive(true);
        togglePanel.SetActive(true);

        isHide = false;
        panelRect.anchoredPosition = new Vector2(667, panelRect.anchoredPosition.y);
        
        HideAllPanels();

        ShowPanel(this.curSelect);
        txtArrow.text = "<<";
    }

    private void HideWindow()
    {
        isHide = true;
        panelRect.anchoredPosition = new Vector2(118, panelRect.anchoredPosition.y);

        HideAllPanels();

        contentPanel.SetActive(false);
        togglePanel.SetActive(false);

        txtArrow.text = ">>";
    }

    private void ShowPanel(int i)
    {
        panelList[i - 1].Show();
    }

    private void Update()
    {
        foreach (var panel in panelList)
        {
            if (panel.isShow)
            {
                panel.Update();
            }
        }
    }

    private void HideAllPanels()
    {
        foreach (var panel in panelList)
        {
            panel.Hide();
        }
    }

    private void OnDestroy()
    {

        foreach (var panel in panelList)
        {
            panel.Hide();
        }

        foreach (var panel in panelList)
        {
            panel.Destroy();
        }
    }

    public void AddMsg(PackData data)
    {
        if (netPanel != null)
        {
            this.netPanel.PushLog(data);
        }
    }

    public void PushLog(string log, LogType type = LogType.Log)
    {
        this.logPanel.PushLog(log, type);
    }
}




