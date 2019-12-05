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
    public class TrigramItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(TrigramItem), L, translator, 0, 0, 2, 6);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ID", _g_get_ID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OnToggleChanged", _g_get_OnToggleChanged);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NameText", _s_set_NameText);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EnableToogle", _s_set_EnableToogle);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SelectToggle", _s_set_SelectToggle);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SetTrigramImage", _s_set_SetTrigramImage);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ID", _s_set_ID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OnToggleChanged", _s_set_OnToggleChanged);
            
			XUtils.EndObjectRegister(typeof(TrigramItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(TrigramItem), L, __CreateInstance, 1, 1, 1);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(TrigramItem));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "LastSelectImage", _g_get_LastSelectImage);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "LastSelectImage", _s_set_LastSelectImage);
            
			XUtils.EndClassRegister(typeof(TrigramItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					TrigramItem __cl_gen_ret = new TrigramItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to TrigramItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LastSelectImage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, TrigramItem.LastSelectImage);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrigramItem __cl_gen_to_be_invoked = (TrigramItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnToggleChanged(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrigramItem __cl_gen_to_be_invoked = (TrigramItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OnToggleChanged);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NameText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrigramItem __cl_gen_to_be_invoked = (TrigramItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NameText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EnableToogle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrigramItem __cl_gen_to_be_invoked = (TrigramItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EnableToogle = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SelectToggle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrigramItem __cl_gen_to_be_invoked = (TrigramItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SelectToggle = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SetTrigramImage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrigramItem __cl_gen_to_be_invoked = (TrigramItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SetTrigramImage = (UnityEngine.Sprite)translator.GetObject(L, 2, typeof(UnityEngine.Sprite));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LastSelectImage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    TrigramItem.LastSelectImage = (UnityEngine.UI.Image)translator.GetObject(L, 1, typeof(UnityEngine.UI.Image));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrigramItem __cl_gen_to_be_invoked = (TrigramItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnToggleChanged(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrigramItem __cl_gen_to_be_invoked = (TrigramItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OnToggleChanged = translator.GetDelegate<TrigramItem.ToggleChanged>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
