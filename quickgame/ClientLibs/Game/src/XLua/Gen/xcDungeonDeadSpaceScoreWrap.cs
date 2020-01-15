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
    public class xcDungeonDeadSpaceScoreWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DungeonDeadSpaceScore), L, translator, 0, 0, 3, 3);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "lv", _g_get_lv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "score", _g_get_score);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "exp", _g_get_exp);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "lv", _s_set_lv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "score", _s_set_score);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "exp", _s_set_exp);
            
			XUtils.EndObjectRegister(typeof(xc.DungeonDeadSpaceScore), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DungeonDeadSpaceScore), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DungeonDeadSpaceScore));
			
			
			XUtils.EndClassRegister(typeof(xc.DungeonDeadSpaceScore), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4)))
				{
					uint lv = LuaAPI.xlua_touint(L, 2);
					uint score = LuaAPI.xlua_touint(L, 3);
					ulong exp = LuaAPI.lua_touint64(L, 4);
					
					xc.DungeonDeadSpaceScore __cl_gen_ret = new xc.DungeonDeadSpaceScore(lv, score, exp);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DungeonDeadSpaceScore constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DungeonDeadSpaceScore __cl_gen_to_be_invoked = (xc.DungeonDeadSpaceScore)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.lv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_score(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DungeonDeadSpaceScore __cl_gen_to_be_invoked = (xc.DungeonDeadSpaceScore)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.score);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_exp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DungeonDeadSpaceScore __cl_gen_to_be_invoked = (xc.DungeonDeadSpaceScore)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushuint64(L, __cl_gen_to_be_invoked.exp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DungeonDeadSpaceScore __cl_gen_to_be_invoked = (xc.DungeonDeadSpaceScore)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.lv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_score(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DungeonDeadSpaceScore __cl_gen_to_be_invoked = (xc.DungeonDeadSpaceScore)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.score = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_exp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DungeonDeadSpaceScore __cl_gen_to_be_invoked = (xc.DungeonDeadSpaceScore)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.exp = LuaAPI.lua_touint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
