using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace xc.debug
{
    /// <summary>
    /// 1.双击图标快捷发送命令
    /// 2.上下箭头选择发送过的命令
    /// 3.回车键直接发送命令
    /// </summary>
    public class CommandPanel : DebugBasePanel
    {
        public class CommandInfo
        {
            public string commandStr = "";
            public string commandDesc = "";
            public string commandParam = "";

            public string defaultCommand = "";

            public string docCommand = "";

            public Action<CommandInfo, string []> action;
            public bool show = true;

            public CommandInfo (string commandstr, string commandDesc, Action<CommandInfo, string []> action = null, string param = null, bool isShow = true, string docCommand = "")
            {
                this.show = isShow;
                this.commandStr = commandstr;
                this.commandDesc = commandDesc;
                this.action = action;
                this.commandParam = param;
                this.docCommand = docCommand;
            }

            public string GetCommandStr ()
            {
                if (!string.IsNullOrEmpty (docCommand)) {
                    return docCommand;
                }

                if (string.IsNullOrEmpty (commandParam)) {
                    return commandStr;
                }

                return commandStr + "&" + commandParam;
            }
        }

        private int count = -1;

        private List<string> sendCommandInfo = new List<string> ();

        private GameObject template;

        //private float doubleClickTimer = 0.25f;
        private float lastClickTime = -1;

        public CommandPanel (GameObject panel, DebugWindow debug) : base (panel, debug)
        {
        }

        protected override void OnHidePanel ()
        {
            base.OnHidePanel ();
        }

        private InputField sendText;
        private Button btnSend;

        protected override void OnLoadFinish ()
        {
            base.OnLoadFinish ();

            LoadDocCommands ();


            this.sendText = this.panel.transform.Find ("InputField").GetComponent<InputField> ();

            sendText.text = "";

            btnSend = this.panel.transform.Find ("BtnSend").GetComponent<Button> ();

            btnSend.onClick.AddListener (OnSendCurCommand);

            this.template = this.panel.transform.Find ("ScrollView/Viewport/Content/ItemTemplate").gameObject;
            template.SetActive (false);

            foreach (var info in DebugCommandConfig.COMMAND_LIST) {
                if (!info.show) {
                    continue;
                }

                GameObject newObj = GameObject.Instantiate (this.template);

                newObj.SetActive (true);
                newObj.transform.SetParent (this.template.transform.parent, false);

                Text text = newObj.transform.Find ("Content").GetComponent<Text> ();

                text.text = info.commandDesc;

                newObj.GetComponent<Button> ().onClick.AddListener (() => {
                    this.SetSendText (info.GetCommandStr ());

                    lastClickTime = Time.time;
                });
            }
        }

        private void LoadDocCommands ()
        {
#if UNITY_EDITOR
            TextAsset textObj = EditorResourceLoader.LoadAssetAtPath("Assets/Res/DB/debug_command.csv", typeof(TextAsset)) as TextAsset;

            if (textObj != null)
            {
                string strData = xc.CommonTool.BytesToUtf8(textObj.bytes);

                if (!string.IsNullOrEmpty(strData))
                {
                    csv.Table table = new csv.Table();
                    table.InitFromString(strData);

                    for (int i = 0; i < table.Count; i++)
                    {
                        List<CommandInfo> list = DebugCommandConfig.COMMAND_LIST;

                        string id = table.Select(i, "id");
                        string name = table.Select(i, "name");
                        string command = table.Select(i, "doc_command");

                        string doc_name = "doc_" + id;
                        var info = new CommandInfo(doc_name, name, DebugCommandConfig.OnDefaultCommandProcessor, null, true, command);

                        list.Add(info);
                    }
                }
            }
#endif

        }

        public void SetAndSendCommand(string command)
        {
            this.SetSendText(command);
            this.OnSendCurCommand();
        }

        private void OnSendCurCommand()
        {
            string commands = this.sendText.text;

            commands = commands.Trim();

            string[] param = new string[] { };
            string str = "";
            if (string.IsNullOrEmpty(commands))
            {
                return;
            }

            CommandInfo info;

            if (commands.Contains("$"))
            {
                info = DebugCommandConfig.GetCommandInfo("default");
                info.defaultCommand = commands;
            }
            else
            {
                var com_split = commands.Split('&');
                var commandName = com_split[0];

                str = "";
                List<string> temp = new List<string>();
                for (int i = 1; i < com_split.Length; i++)
                {
                    temp.Add(com_split[i]);
                    str += "&" + com_split[i];
                }

                param = temp.ToArray();

                info = DebugCommandConfig.GetCommandInfo(commandName);

                if (info == null)
                {
                    info = DebugCommandConfig.GetCommandInfo("default");
                    info.defaultCommand = commandName;
                }
            }

            if (info.action != null)
            {
                info.action(info, param);
            }

            this.SetSendText("");

            this.count = -1;

            this.sendCommandInfo.Add(commands);

            if (string.IsNullOrEmpty(str))
            {
                GameDebug.LogRed("发送GM命令" + commands);
            }
            else
            {
                GameDebug.LogRed("发送GM命令" + commands + "参数" + str);
            }
        }

        private void SetSendText(string commandStr)
        {
            this.sendText.text = commandStr;
        }

        public override void Update()
        {
            if (this.sendText == null || !this.isShow)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                this.OnSendCurCommand();
                return;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (this.sendCommandInfo.Count == 0)
                    return;

                if (count == -1)
                {
                    count = this.sendCommandInfo.Count;
                }

                count--;

                if (count < 0) count = 0;

                this.SetSendText(this.sendCommandInfo[count]);

                return;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (this.sendCommandInfo.Count == 0)
                    return;

                if (count == -1)
                {
                    return;
                }

                count++;

                if (count >= this.sendCommandInfo.Count) count = this.sendCommandInfo.Count - 1;

                this.SetSendText(this.sendCommandInfo[count]);

                return;
            }
        }

        protected override void OnShowPanel()
        {
            base.OnShowPanel();
        }
    }
}