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
    public class xcDBMagicEquipDBMagicEquipItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBMagicEquip.DBMagicEquipItem), L, translator, 0, 0, 8, 8);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Gid", _g_get_Gid);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PosId", _g_get_PosId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StrengthMax", _g_get_StrengthMax);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Star", _g_get_Star);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SwallowExpValue", _g_get_SwallowExpValue);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DefaultAppendDesc", _g_get_DefaultAppendDesc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AppendAttrNum", _g_get_AppendAttrNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BaseAttrs", _g_get_BaseAttrs);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Gid", _s_set_Gid);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PosId", _s_set_PosId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StrengthMax", _s_set_StrengthMax);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Star", _s_set_Star);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SwallowExpValue", _s_set_SwallowExpValue);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DefaultAppendDesc", _s_set_DefaultAppendDesc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AppendAttrNum", _s_set_AppendAttrNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BaseAttrs", _s_set_BaseAttrs);
            
			XUtils.EndObjectRegister(typeof(xc.DBMagicEquip.DBMagicEquipItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBMagicEquip.DBMagicEquipItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBMagicEquip.DBMagicEquipItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBMagicEquip.DBMagicEquipItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBMagicEquip.DBMagicEquipItem __cl_gen_ret = new xc.DBMagicEquip.DBMagicEquipItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBMagicEquip.DBMagicEquipItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Gid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Gid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PosId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PosId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StrengthMax(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StrengthMax);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Star(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Star);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SwallowExpValue(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SwallowExpValue);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultAppendDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.DefaultAppendDesc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AppendAttrNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.AppendAttrNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BaseAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Gid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Gid = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PosId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PosId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StrengthMax(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StrengthMax = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Star(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Star = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SwallowExpValue(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SwallowExpValue = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DefaultAppendDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DefaultAppendDesc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AppendAttrNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AppendAttrNum = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BaseAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMagicEquip.DBMagicEquipItem __cl_gen_to_be_invoked = (xc.DBMagicEquip.DBMagicEquipItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BaseAttrs = (System.Collections.Generic.List<xc.DBTextResource.DBAttrItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBTextResource.DBAttrItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
