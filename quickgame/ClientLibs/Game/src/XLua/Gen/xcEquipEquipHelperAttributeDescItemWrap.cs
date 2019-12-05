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
    public class xcEquipEquipHelperAttributeDescItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Equip.EquipHelper.AttributeDescItem), L, translator, 0, 0, 4, 4);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PropName", _g_get_PropName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ValueStr", _g_get_ValueStr);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PropSortId", _g_get_PropSortId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsMiddle", _g_get_IsMiddle);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PropName", _s_set_PropName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ValueStr", _s_set_ValueStr);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PropSortId", _s_set_PropSortId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsMiddle", _s_set_IsMiddle);
            
			XUtils.EndObjectRegister(typeof(xc.Equip.EquipHelper.AttributeDescItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Equip.EquipHelper.AttributeDescItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Equip.EquipHelper.AttributeDescItem));
			
			
			XUtils.EndClassRegister(typeof(xc.Equip.EquipHelper.AttributeDescItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Equip.EquipHelper.AttributeDescItem __cl_gen_ret = new xc.Equip.EquipHelper.AttributeDescItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Equip.EquipHelper.AttributeDescItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PropName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipHelper.AttributeDescItem __cl_gen_to_be_invoked = (xc.Equip.EquipHelper.AttributeDescItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.PropName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ValueStr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipHelper.AttributeDescItem __cl_gen_to_be_invoked = (xc.Equip.EquipHelper.AttributeDescItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ValueStr);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PropSortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipHelper.AttributeDescItem __cl_gen_to_be_invoked = (xc.Equip.EquipHelper.AttributeDescItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PropSortId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsMiddle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipHelper.AttributeDescItem __cl_gen_to_be_invoked = (xc.Equip.EquipHelper.AttributeDescItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsMiddle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PropName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipHelper.AttributeDescItem __cl_gen_to_be_invoked = (xc.Equip.EquipHelper.AttributeDescItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PropName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ValueStr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipHelper.AttributeDescItem __cl_gen_to_be_invoked = (xc.Equip.EquipHelper.AttributeDescItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ValueStr = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PropSortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipHelper.AttributeDescItem __cl_gen_to_be_invoked = (xc.Equip.EquipHelper.AttributeDescItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PropSortId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsMiddle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipHelper.AttributeDescItem __cl_gen_to_be_invoked = (xc.Equip.EquipHelper.AttributeDescItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsMiddle = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
