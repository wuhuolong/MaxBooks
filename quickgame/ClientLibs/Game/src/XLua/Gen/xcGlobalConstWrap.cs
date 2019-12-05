#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class xcGlobalConstWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GlobalConst), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.GlobalConst), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GlobalConst), L, __CreateInstance, 19, 1, 1);
			
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnitScale", xc.GlobalConst.UnitScale);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FrameLength", xc.GlobalConst.FrameLength);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MilliToSecond", xc.GlobalConst.MilliToSecond);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MonsterDestroyDelay", xc.GlobalConst.MonsterDestroyDelay);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AttrConvert", xc.GlobalConst.AttrConvert);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AttrConvertInv", xc.GlobalConst.AttrConvertInv);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BuffIconFolder", xc.GlobalConst.BuffIconFolder);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ReliveEffectLink", xc.GlobalConst.ReliveEffectLink);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DefaultTestScene", xc.GlobalConst.DefaultTestScene);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LoginScene", xc.GlobalConst.LoginScene);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "StandardRadius", xc.GlobalConst.StandardRadius);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DeathAnimation", xc.GlobalConst.DeathAnimation);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "IsBanshuVersion", xc.GlobalConst.IsBanshuVersion);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ResPath", xc.GlobalConst.ResPath);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MountSysId", xc.GlobalConst.MountSysId);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MinPlayerCount", xc.GlobalConst.MinPlayerCount);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CreateActorScene", xc.GlobalConst.CreateActorScene);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SelectActorScene", xc.GlobalConst.SelectActorScene);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GlobalConst));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "VoiceEngineType", _g_get_VoiceEngineType);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "VoiceEngineType", _s_set_VoiceEngineType);
            
			XUtils.EndClassRegister(typeof(xc.GlobalConst), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GlobalConst __cl_gen_ret = new xc.GlobalConst();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GlobalConst constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VoiceEngineType(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.GlobalConst.VoiceEngineType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_VoiceEngineType(RealStatePtr L)
        {
            
            try {
			    xc.GlobalConst.VoiceEngineType = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
