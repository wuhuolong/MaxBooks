using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using xc;
using Net;

public class LuaTestMgr : xc.Singleton<LuaTestMgr>
{
    public void RunTestScript()
    {
        //string script = @"GameDebug.LogError('xc.ClientEvent.WINDOW_DESTROY: ' .. tostring(xc.ClientEvent.WINDOW_DESTROY))
        //ClientUIEventManager.Instance:FireEvent(xc.ClientEvent.WINDOW_DESTROY, CEventBaseArgs('UITaskAndTeamWindow'))";
        //Lua.DoString(script);

        ulong a = 100;
        ulong b = 123456789122;
        ulong c = 123456789123;
        ulong d = 123456789124;
        ulong e = 0;
        LuaTable luaT = LuaScriptMgr.Instance.Require("Test") as LuaTable;
        object[] rets = LuaScriptMgr.Instance.CallLuaFunction(luaT, "Testu64", a, b, c, d, e);
        //c = (ulong)rets[0];
        //GameDebug.Log("Testu64 c: " + c);
// 
//         S2CEquipResult s2cEquipResult = new S2CEquipResult();
//         s2cEquipResult.code = 1;
//         s2cEquipResult.oid = 123456789123;
//         C2SPackBase c2sPackBase = new C2SPackBase(123);
//         byte[] data = c2sPackBase.SerializePack(s2cEquipResult);
//         rets = LuaScriptMgr.Instance.CallLuaFunction(luaT, "TestPbc", 123, data);
        //s2cEquipResult = (S2CEquipResult)rets[0];
        //GameDebug.Log("TestPbc1 oid: " + (string)rets[0]);
    }

    public void Testu64(ulong a, ulong b)
    {
        GameDebug.Log("Testu64 a: " + a + ", b: " + b);
    }

    public void TestPbc(byte[] data)
    {
//         S2CPackBase s2cPack = new S2CPackBase();
//         S2CEquipResult s2cEquipResult = s2cPack.DeserializePack<S2CEquipResult>(data);
//         GameDebug.Log("TestPbc2 oid: " + s2cEquipResult.oid);
    }
}