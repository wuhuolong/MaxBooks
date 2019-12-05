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
    public class xcDBDecorateDBDecorateItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBDecorate.DBDecorateItem), L, translator, 0, 0, 9, 9);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Gid", _g_get_Gid);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Pos", _g_get_Pos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StrengthMax", _g_get_StrengthMax);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LvStep", _g_get_LvStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SwallowExpValue", _g_get_SwallowExpValue);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DefaultExtraDesc", _g_get_DefaultExtraDesc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DefaultStar", _g_get_DefaultStar);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Attrs", _g_get_Attrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LegendAttrs", _g_get_LegendAttrs);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Gid", _s_set_Gid);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Pos", _s_set_Pos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StrengthMax", _s_set_StrengthMax);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LvStep", _s_set_LvStep);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SwallowExpValue", _s_set_SwallowExpValue);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DefaultExtraDesc", _s_set_DefaultExtraDesc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DefaultStar", _s_set_DefaultStar);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Attrs", _s_set_Attrs);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LegendAttrs", _s_set_LegendAttrs);
            
			XUtils.EndObjectRegister(typeof(xc.DBDecorate.DBDecorateItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBDecorate.DBDecorateItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBDecorate.DBDecorateItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBDecorate.DBDecorateItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBDecorate.DBDecorateItem __cl_gen_ret = new xc.DBDecorate.DBDecorateItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBDecorate.DBDecorateItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Gid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Gid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Pos);
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
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StrengthMax);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LvStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LvStep);
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
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SwallowExpValue);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultExtraDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.DefaultExtraDesc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultStar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.DefaultStar);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Attrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Attrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LegendAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LegendAttrs);
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
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Gid = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Pos = LuaAPI.xlua_touint(L, 2);
            
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
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StrengthMax = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LvStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LvStep = LuaAPI.xlua_touint(L, 2);
            
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
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SwallowExpValue = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DefaultExtraDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DefaultExtraDesc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DefaultStar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DefaultStar = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Attrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Attrs = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LegendAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDecorate.DBDecorateItem __cl_gen_to_be_invoked = (xc.DBDecorate.DBDecorateItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LegendAttrs = (System.Collections.Generic.List<System.Collections.Generic.List<uint>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<System.Collections.Generic.List<uint>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
