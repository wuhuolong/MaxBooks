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
    public class xcGoodsCompositeStuffDataWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GoodsCompositeStuffData), L, translator, 0, 0, 5, 5);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CompositeMaxUnBindNum", _g_get_CompositeMaxUnBindNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CompositeMaxTotalNum", _g_get_CompositeMaxTotalNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CompositeId", _g_get_CompositeId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Stuffs", _g_get_Stuffs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Moneys", _g_get_Moneys);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CompositeMaxUnBindNum", _s_set_CompositeMaxUnBindNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CompositeMaxTotalNum", _s_set_CompositeMaxTotalNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CompositeId", _s_set_CompositeId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Stuffs", _s_set_Stuffs);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Moneys", _s_set_Moneys);
            
			XUtils.EndObjectRegister(typeof(xc.GoodsCompositeStuffData), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GoodsCompositeStuffData), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GoodsCompositeStuffData));
			
			
			XUtils.EndClassRegister(typeof(xc.GoodsCompositeStuffData), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GoodsCompositeStuffData __cl_gen_ret = new xc.GoodsCompositeStuffData();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsCompositeStuffData constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CompositeMaxUnBindNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsCompositeStuffData __cl_gen_to_be_invoked = (xc.GoodsCompositeStuffData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.CompositeMaxUnBindNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CompositeMaxTotalNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsCompositeStuffData __cl_gen_to_be_invoked = (xc.GoodsCompositeStuffData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.CompositeMaxTotalNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CompositeId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsCompositeStuffData __cl_gen_to_be_invoked = (xc.GoodsCompositeStuffData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.CompositeId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Stuffs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsCompositeStuffData __cl_gen_to_be_invoked = (xc.GoodsCompositeStuffData)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Stuffs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Moneys(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsCompositeStuffData __cl_gen_to_be_invoked = (xc.GoodsCompositeStuffData)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Moneys);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CompositeMaxUnBindNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsCompositeStuffData __cl_gen_to_be_invoked = (xc.GoodsCompositeStuffData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CompositeMaxUnBindNum = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CompositeMaxTotalNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsCompositeStuffData __cl_gen_to_be_invoked = (xc.GoodsCompositeStuffData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CompositeMaxTotalNum = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CompositeId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsCompositeStuffData __cl_gen_to_be_invoked = (xc.GoodsCompositeStuffData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CompositeId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Stuffs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsCompositeStuffData __cl_gen_to_be_invoked = (xc.GoodsCompositeStuffData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Stuffs = (System.Collections.Generic.List<xc.GoodsItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.GoodsItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Moneys(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsCompositeStuffData __cl_gen_to_be_invoked = (xc.GoodsCompositeStuffData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Moneys = (System.Collections.Generic.List<System.Collections.Generic.Dictionary<ushort, uint>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<System.Collections.Generic.Dictionary<ushort, uint>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
