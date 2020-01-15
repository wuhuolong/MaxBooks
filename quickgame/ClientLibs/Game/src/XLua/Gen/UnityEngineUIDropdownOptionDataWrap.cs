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
    public class UnityEngineUIDropdownOptionDataWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Dropdown.OptionData), L, translator, 0, 0, 2, 2);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "text", _g_get_text);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "image", _g_get_image);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "text", _s_set_text);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "image", _s_set_image);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Dropdown.OptionData), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.UI.Dropdown.OptionData), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Dropdown.OptionData));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.UI.Dropdown.OptionData), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.UI.Dropdown.OptionData __cl_gen_ret = new UnityEngine.UI.Dropdown.OptionData();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string text = LuaAPI.lua_tostring(L, 2);
					
					UnityEngine.UI.Dropdown.OptionData __cl_gen_ret = new UnityEngine.UI.Dropdown.OptionData(text);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<UnityEngine.Sprite>(L, 2))
				{
					UnityEngine.Sprite image = (UnityEngine.Sprite)translator.GetObject(L, 2, typeof(UnityEngine.Sprite));
					
					UnityEngine.UI.Dropdown.OptionData __cl_gen_ret = new UnityEngine.UI.Dropdown.OptionData(image);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && translator.Assignable<UnityEngine.Sprite>(L, 3))
				{
					string text = LuaAPI.lua_tostring(L, 2);
					UnityEngine.Sprite image = (UnityEngine.Sprite)translator.GetObject(L, 3, typeof(UnityEngine.Sprite));
					
					UnityEngine.UI.Dropdown.OptionData __cl_gen_ret = new UnityEngine.UI.Dropdown.OptionData(text, image);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.UI.Dropdown.OptionData constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_text(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Dropdown.OptionData __cl_gen_to_be_invoked = (UnityEngine.UI.Dropdown.OptionData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.text);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_image(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Dropdown.OptionData __cl_gen_to_be_invoked = (UnityEngine.UI.Dropdown.OptionData)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.image);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_text(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Dropdown.OptionData __cl_gen_to_be_invoked = (UnityEngine.UI.Dropdown.OptionData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.text = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_image(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Dropdown.OptionData __cl_gen_to_be_invoked = (UnityEngine.UI.Dropdown.OptionData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.image = (UnityEngine.Sprite)translator.GetObject(L, 2, typeof(UnityEngine.Sprite));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
