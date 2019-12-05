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
    public class xcDBSpecialMonDBSpecialMonItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBSpecialMon.DBSpecialMonItem), L, translator, 0, 0, 7, 7);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ActorId", _g_get_ActorId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SpecialType", _g_get_SpecialType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DungeonId", _g_get_DungeonId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Tag", _g_get_Tag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TagGroup", _g_get_TagGroup);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SysId", _g_get_SysId);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ActorId", _s_set_ActorId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SpecialType", _s_set_SpecialType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DungeonId", _s_set_DungeonId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Tag", _s_set_Tag);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TagGroup", _s_set_TagGroup);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SysId", _s_set_SysId);
            
			XUtils.EndObjectRegister(typeof(xc.DBSpecialMon.DBSpecialMonItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBSpecialMon.DBSpecialMonItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBSpecialMon.DBSpecialMonItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBSpecialMon.DBSpecialMonItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBSpecialMon.DBSpecialMonItem __cl_gen_ret = new xc.DBSpecialMon.DBSpecialMonItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBSpecialMon.DBSpecialMonItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActorId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ActorId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SpecialType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.SpecialType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DungeonId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.DungeonId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Tag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Tag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TagGroup(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.TagGroup);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SysId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SysId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ActorId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ActorId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SpecialType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SpecialType = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DungeonId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DungeonId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Tag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Tag = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TagGroup(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TagGroup = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SysId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSpecialMon.DBSpecialMonItem __cl_gen_to_be_invoked = (xc.DBSpecialMon.DBSpecialMonItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SysId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
