using Net;
using System;
using System.Collections.Generic;
using xc;
using xc.protocol;
using static xc.debug.CommandPanel;

/// <summary>
/// 配置测试使用的快捷命令
/// </summary>
public static class DebugCommandConfig
{
    #region function

    public static CommandInfo GetCommandInfo(string command)
    {
        foreach (var info in COMMAND_LIST)
        {
            if (info.commandStr == command)
            {
                return info;
            }
        }

        return null;
    }

    #endregion function

    /// <summary>
    /// 命令格式: new CommandInfo("command", "描述", 回调函数, "默认参数1&默认参数2")
    ///
    /// 输入示例: get_money&111
    ///          add_monster&boss&2231
    ///          add_item&gold&222
    ///          add_all_coin
    ///
    /// 输入的命令和参数用空格分割
    ///
    /// 参数用&分割，回调函数传入的参数是分割后的字符串数组
    ///
    /// </summary>
    public static List<CommandInfo> COMMAND_LIST = new List<CommandInfo>()
    {
        new CommandInfo("default", "默认命令", OnDefaultCommandProcessor, null, false),//默认命令处理函数，找不到命令时回调这里的方法,不显示在面板上

        new CommandInfo("doc_command", "表格配置命令处理", OnDefaultCommandProcessor, null, false),

        new CommandInfo("#weak", "弱化剩一血", OnCCommandProcessor),
        new CommandInfo("#add_goods", "添加物品", OnCCommandProcessor, "100001&1"),
        new CommandInfo("#lv", "添加等级", OnCCommandProcessor, "70"),

        new CommandInfo("#rich", "变身土豪", OnCCommandProcessor),
        new CommandInfo("#e_new", "添加装备", OnCCommandProcessor, "1000906&8"),

        new CommandInfo("diaobao", "一键变强", OnOneKeyPower),

        //new CommandInfo("doc_1", "doc command", OnDocCommandProcessor, null, true, "c:#weak$c:#rich")
        //new CommandInfo("your_command_name", "自定义命令", OnUserDefineCommand, "参数1&参数2&Itype&Sname"),
    };

    public static void OnDefaultCommandProcessor(CommandInfo command, string[] args)
    {
        string commandStr = command.defaultCommand;

        ToParseDefaultCommand(commandStr, args);

        //ToProcessDefaultCommand(commandStr, args);
        
    }

    private static void ToParseDefaultCommand(string commandStr, string[] args)
    {
        string[] commands = commandStr.Split('$');

        if (commands.Length <= 0)
        {
            return;
        }

        foreach (var str in commands)
        {
            string[] splits = str.Split('&');

            List<string> param = new List<string>(splits);
            string cmd = splits[0];

            if (splits.Length > 0)
            {
                param.RemoveAt(0);
            }

            ToProcessDefaultCommand(cmd, param.ToArray());
        }
    }

    private static void ToProcessDefaultCommand(string commandStr, string[] args)
    {
        //GameDebug.Log(commandStr);

        //c:#
        if (commandStr.ToLower().Length >= 2 &&  commandStr.ToLower()[0] == 'c' && commandStr.ToLower()[1] == ':')
        {
            if (((int)xc.Game.GetInstance().GameMode & (int)xc.Game.EGameMode.GM_Net) == (int)xc.Game.EGameMode.GM_Net)
            {
                //commandStr = commandStr.Substring(2, command.commandStr.Length);
                SendCCommandConnect(commandStr, args);
            }
            return;
        }

        //x:#
        if (commandStr.ToLower().Length >= 2 && commandStr.ToLower()[0] == 'x' && commandStr.ToLower()[1] == ':')
        {
            if (((int)xc.Game.GetInstance().GameMode & (int)xc.Game.EGameMode.GM_Net) == (int)xc.Game.EGameMode.GM_Net)
            {
                SendGMCommandThroughMajorConnect(commandStr, args);
            }
            return;
        }

        DebugCommand.ToProcessCommand(commandStr, new List<string>(args), MainGame.DebugUI);
    }

    private static void OnOneKeyPower(CommandInfo arg1, string[] arg2)
    {
        ToProcessOnCCommand("#lv&70");
        ToProcessOnCCommand("#rich");
        ToProcessOnCCommand("#e_new&10000905&8");
        ToProcessOnCCommand("#e_new&10000906&8");
    }

    private static void OnCCommandProcessor(CommandInfo info, string[] param)
    {
        string command = info.commandStr;

        for (int i = 0; i < param.Length; i++)
        {
            command += "&" + param[i];
        }

        ToProcessOnCCommand(command);
    }

    private static void ToProcessOnCCommand(string command)
    {
        C2SChatCommon data = new C2SChatCommon();
        data.type = GameConst.CHAT_BCAST_ALL;
        data.info = new PkgChatC2S();
        data.info.content = System.Text.Encoding.UTF8.GetBytes(command);
        NetClient.GetBaseClient().SendData<C2SChatCommon>(NetMsg.MSG_CHAT_COMMON, data);
    }

    /// <summary>
    /// 通过主链接发送GM指令
    /// </summary>
    /// <param name="cmd"></param>
    private static void SendGMCommandThroughMajorConnect(string cmd, string[] args)
    {
        string str = "";
        for (int i = 2; i < cmd.ToLower().Length; i++)
        {
            str = str + cmd.ToLower()[i];
        }

        for (int i = 0; i < args.Length; i++)
        {
            str += "&" + args[i];
        }

        C2SChatCommon data = new C2SChatCommon();
        data.type = GameConst.CHAT_BCAST_ALL;
        data.info.content = System.Text.Encoding.UTF8.GetBytes(str);

        NetClient.GetBaseClient().SendData<C2SChatCommon>(NetMsg.MSG_CHAT_COMMON, data);
    }

    private static void SendCCommandConnect(string commandStr, string[] args)
    {
        string str = "";
        for (int i = 2; i < commandStr.ToLower().Length; i++)
        {
            str = str + commandStr.ToLower()[i];
        }

        for (int i = 0; i < args.Length; i++)
        {
            str += "&" + args[i];
        }


        C2SChatCommon data = new C2SChatCommon();
        data.type = GameConst.CHAT_BCAST_ALL;
        data.info = new PkgChatC2S();
        data.info.content = System.Text.Encoding.UTF8.GetBytes(str);
        NetClient.GetBaseClient().SendData<C2SChatCommon>(NetMsg.MSG_CHAT_COMMON, data);
    }
}