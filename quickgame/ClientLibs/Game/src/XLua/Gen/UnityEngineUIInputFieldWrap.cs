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
    public class UnityEngineUIInputFieldWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.UI.InputField), L, translator, 0, 0, 5, 5);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "text", _g_get_text);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "onEndEdit", _g_get_onEndEdit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "onValueChanged", _g_get_onValueChanged);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "onValidateInput", _g_get_onValidateInput);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "characterLimit", _g_get_characterLimit);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "text", _s_set_text);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "onEndEdit", _s_set_onEndEdit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "onValueChanged", _s_set_onValueChanged);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "onValidateInput", _s_set_onValidateInput);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "characterLimit", _s_set_characterLimit);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.InputField), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.UI.InputField), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.InputField));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.UI.InputField), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.UI.InputField does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_text(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.InputField __cl_gen_to_be_invoked = (UnityEngine.UI.InputField)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.text);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onEndEdit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.InputField __cl_gen_to_be_invoked = (UnityEngine.UI.InputField)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onEndEdit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onValueChanged(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.InputField __cl_gen_to_be_invoked = (UnityEngine.UI.InputField)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onValueChanged);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onValidateInput(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.InputField __cl_gen_to_be_invoked = (UnityEngine.UI.InputField)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onValidateInput);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_characterLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.InputField __cl_gen_to_be_invoked = (UnityEngine.UI.InputField)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.characterLimit);
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
			
                UnityEngine.UI.InputField __cl_gen_to_be_invoked = (UnityEngine.UI.InputField)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.text = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onEndEdit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.InputField __cl_gen_to_be_invoked = (UnityEngine.UI.InputField)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onEndEdit = (UnityEngine.UI.InputField.SubmitEvent)translator.GetObject(L, 2, typeof(UnityEngine.UI.InputField.SubmitEvent));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onValueChanged(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.InputField __cl_gen_to_be_invoked = (UnityEngine.UI.InputField)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onValueChanged = (UnityEngine.UI.InputField.OnChangeEvent)translator.GetObject(L, 2, typeof(UnityEngine.UI.InputField.OnChangeEvent));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onValidateInput(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.InputField __cl_gen_to_be_invoked = (UnityEngine.UI.InputField)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onValidateInput = translator.GetDelegate<UnityEngine.UI.InputField.OnValidateInput>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_characterLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.InputField __cl_gen_to_be_invoked = (UnityEngine.UI.InputField)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.characterLimit = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
