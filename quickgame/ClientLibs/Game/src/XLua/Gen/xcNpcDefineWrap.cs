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
    public class xcNpcDefineWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.NpcDefine), L, translator, 0, 0, 12, 12);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NpcId", _g_get_NpcId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ActorId", _g_get_ActorId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IdleAni", _g_get_IdleAni);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LightMode", _g_get_LightMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Radius", _g_get_Radius);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ConstTitle", _g_get_ConstTitle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ConstText", _g_get_ConstText);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ConstBtnText", _g_get_ConstBtnText);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ConstBtnPic", _g_get_ConstBtnPic);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Function", _g_get_Function);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FunctionParams", _g_get_FunctionParams);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VoiceIds", _g_get_VoiceIds);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NpcId", _s_set_NpcId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ActorId", _s_set_ActorId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IdleAni", _s_set_IdleAni);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LightMode", _s_set_LightMode);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Radius", _s_set_Radius);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ConstTitle", _s_set_ConstTitle);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ConstText", _s_set_ConstText);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ConstBtnText", _s_set_ConstBtnText);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ConstBtnPic", _s_set_ConstBtnPic);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Function", _s_set_Function);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FunctionParams", _s_set_FunctionParams);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "VoiceIds", _s_set_VoiceIds);
            
			XUtils.EndObjectRegister(typeof(xc.NpcDefine), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.NpcDefine), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.NpcDefine));
			
			
			XUtils.EndClassRegister(typeof(xc.NpcDefine), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.NpcDefine __cl_gen_ret = new xc.NpcDefine();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.NpcDefine constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NpcId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NpcId);
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
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ActorId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IdleAni(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.IdleAni);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LightMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                translator.PushxcNpcDefineELightMode(L, __cl_gen_to_be_invoked.LightMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Radius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.Radius);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ConstTitle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ConstTitle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ConstText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ConstText);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ConstBtnText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ConstBtnText);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ConstBtnPic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ConstBtnPic);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Function(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                translator.PushxcNpcDefineEFunction(L, __cl_gen_to_be_invoked.Function);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FunctionParams(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.FunctionParams);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VoiceIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VoiceIds);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NpcId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NpcId = LuaAPI.xlua_touint(L, 2);
            
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
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ActorId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IdleAni(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IdleAni = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LightMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                xc.NpcDefine.ELightMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.LightMode = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Radius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Radius = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ConstTitle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ConstTitle = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ConstText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ConstText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ConstBtnText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ConstBtnText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ConstBtnPic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ConstBtnPic = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Function(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                xc.NpcDefine.EFunction __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Function = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FunctionParams(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FunctionParams = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_VoiceIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcDefine __cl_gen_to_be_invoked = (xc.NpcDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.VoiceIds = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
