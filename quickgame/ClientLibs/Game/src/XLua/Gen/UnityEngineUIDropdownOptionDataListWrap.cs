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
    public class UnityEngineUIDropdownOptionDataListWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Dropdown.OptionDataList), L, translator, 0, 0, 1, 1);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "options", _g_get_options);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "options", _s_set_options);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Dropdown.OptionDataList), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.UI.Dropdown.OptionDataList), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Dropdown.OptionDataList));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.UI.Dropdown.OptionDataList), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.UI.Dropdown.OptionDataList __cl_gen_ret = new UnityEngine.UI.Dropdown.OptionDataList();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.UI.Dropdown.OptionDataList constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_options(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Dropdown.OptionDataList __cl_gen_to_be_invoked = (UnityEngine.UI.Dropdown.OptionDataList)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.options);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_options(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Dropdown.OptionDataList __cl_gen_to_be_invoked = (UnityEngine.UI.Dropdown.OptionDataList)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.options = (System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
