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
    public class xcDBSuitRefineDBSuitRefineItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBSuitRefine.DBSuitRefineItem), L, translator, 0, 0, 7, 7);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Pos", _g_get_Pos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Step", _g_get_Step);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Level", _g_get_Level);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Cost", _g_get_Cost);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Addition", _g_get_Addition);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Attrs", _g_get_Attrs);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Pos", _s_set_Pos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Step", _s_set_Step);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Level", _s_set_Level);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Cost", _s_set_Cost);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Addition", _s_set_Addition);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Attrs", _s_set_Attrs);
            
			XUtils.EndObjectRegister(typeof(xc.DBSuitRefine.DBSuitRefineItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBSuitRefine.DBSuitRefineItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBSuitRefine.DBSuitRefineItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBSuitRefine.DBSuitRefineItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBSuitRefine.DBSuitRefineItem __cl_gen_ret = new xc.DBSuitRefine.DBSuitRefineItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBSuitRefine.DBSuitRefineItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Id);
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
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Pos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Step(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Step);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Level);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Cost(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Cost);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Addition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Addition);
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
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Attrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.lua_tostring(L, 2);
            
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
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Pos = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Step(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Step = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Level = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Cost(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Cost = (System.Collections.Generic.List<xc.DBTextResource.DBGoodsItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBTextResource.DBGoodsItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Addition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Addition = LuaAPI.xlua_touint(L, 2);
            
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
			
                xc.DBSuitRefine.DBSuitRefineItem __cl_gen_to_be_invoked = (xc.DBSuitRefine.DBSuitRefineItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Attrs = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
