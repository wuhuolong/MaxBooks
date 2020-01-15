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
    public class xcuiUIItemNewSlotTypeParseWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.UIItemNewSlot.TypeParse), L, translator, 0, 0, 8, 8);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "_mType", _g_get__mType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "_mNum", _g_get__mNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "_mGrade", _g_get__mGrade);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "_mFunc", _g_get__mFunc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "_mFunc1", _g_get__mFunc1);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "_mFunc2", _g_get__mFunc2);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "_mCustomFunc", _g_get__mCustomFunc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "_mParam", _g_get__mParam);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "_mType", _s_set__mType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "_mNum", _s_set__mNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "_mGrade", _s_set__mGrade);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "_mFunc", _s_set__mFunc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "_mFunc1", _s_set__mFunc1);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "_mFunc2", _s_set__mFunc2);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "_mCustomFunc", _s_set__mCustomFunc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "_mParam", _s_set__mParam);
            
			XUtils.EndObjectRegister(typeof(xc.ui.UIItemNewSlot.TypeParse), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.UIItemNewSlot.TypeParse), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.UIItemNewSlot.TypeParse));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.UIItemNewSlot.TypeParse), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			translator.Push(L, default(xc.ui.UIItemNewSlot.TypeParse));
			return 1;
			
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__mType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked._mType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__mNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked._mNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__mGrade(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked._mGrade);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__mFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                translator.Push(L, __cl_gen_to_be_invoked._mFunc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__mFunc1(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                translator.Push(L, __cl_gen_to_be_invoked._mFunc1);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__mFunc2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                translator.Push(L, __cl_gen_to_be_invoked._mFunc2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__mCustomFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                translator.Push(L, __cl_gen_to_be_invoked._mCustomFunc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__mParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                translator.PushAny(L, __cl_gen_to_be_invoked._mParam);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__mType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                __cl_gen_to_be_invoked._mType = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, __cl_gen_to_be_invoked);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__mNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                __cl_gen_to_be_invoked._mNum = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, __cl_gen_to_be_invoked);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__mGrade(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                __cl_gen_to_be_invoked._mGrade = LuaAPI.xlua_touint(L, 2);
            
                translator.Update(L, 1, __cl_gen_to_be_invoked);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__mFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                __cl_gen_to_be_invoked._mFunc = translator.GetDelegate<xc.ui.UIItemNewSlot.OnClickFunc>(L, 2);
            
                translator.Update(L, 1, __cl_gen_to_be_invoked);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__mFunc1(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                __cl_gen_to_be_invoked._mFunc1 = translator.GetDelegate<xc.ui.UIItemNewSlot.OnClickFunc1>(L, 2);
            
                translator.Update(L, 1, __cl_gen_to_be_invoked);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__mFunc2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                __cl_gen_to_be_invoked._mFunc2 = translator.GetDelegate<xc.ui.UIItemNewSlot.OnClickFunc2>(L, 2);
            
                translator.Update(L, 1, __cl_gen_to_be_invoked);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__mCustomFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                __cl_gen_to_be_invoked._mCustomFunc = translator.GetDelegate<xc.ui.UIItemNewSlot.OnClickCustomFunc>(L, 2);
            
                translator.Update(L, 1, __cl_gen_to_be_invoked);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__mParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                __cl_gen_to_be_invoked._mParam = translator.GetObject(L, 2, typeof(object));
            
                translator.Update(L, 1, __cl_gen_to_be_invoked);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
