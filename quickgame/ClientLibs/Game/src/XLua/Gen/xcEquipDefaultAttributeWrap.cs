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
    public class xcEquipDefaultAttributeWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Equip.DefaultAttribute), L, translator, 0, 0, 5, 1);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Data", _g_get_Data);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Desc", _g_get_Desc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Values", _g_get_Values);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Score", _g_get_Score);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Values", _s_set_Values);
            
			XUtils.EndObjectRegister(typeof(xc.Equip.DefaultAttribute), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Equip.DefaultAttribute), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Equip.DefaultAttribute));
			
			
			XUtils.EndClassRegister(typeof(xc.Equip.DefaultAttribute), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<System.Collections.Generic.List<uint>>(L, 3))
				{
					uint equip_attr_id = LuaAPI.xlua_touint(L, 2);
					System.Collections.Generic.List<uint> args = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
					
					xc.Equip.DefaultAttribute __cl_gen_ret = new xc.Equip.DefaultAttribute(equip_attr_id, args);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Equip.DefaultAttribute constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.DefaultAttribute __cl_gen_to_be_invoked = (xc.Equip.DefaultAttribute)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Data(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.DefaultAttribute __cl_gen_to_be_invoked = (xc.Equip.DefaultAttribute)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Data);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Desc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.DefaultAttribute __cl_gen_to_be_invoked = (xc.Equip.DefaultAttribute)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Desc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Values(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.DefaultAttribute __cl_gen_to_be_invoked = (xc.Equip.DefaultAttribute)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Values);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Score(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.DefaultAttribute __cl_gen_to_be_invoked = (xc.Equip.DefaultAttribute)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Score);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Values(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.DefaultAttribute __cl_gen_to_be_invoked = (xc.Equip.DefaultAttribute)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Values = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
