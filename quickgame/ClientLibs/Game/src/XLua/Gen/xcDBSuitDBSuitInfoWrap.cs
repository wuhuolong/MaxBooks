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
    public class xcDBSuitDBSuitInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBSuit.DBSuitInfo), L, translator, 0, 1, 10, 10);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetCostGoods", _m_GetCostGoods);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Lv", _g_get_Lv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PreviewName", _g_get_PreviewName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SuitId", _g_get_SuitId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ColorNeed", _g_get_ColorNeed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StarNeed", _g_get_StarNeed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedInfos", _g_get_NeedInfos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CostGoodsIdList", _g_get_CostGoodsIdList);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CostGoodsList", _g_get_CostGoodsList);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Lv", _s_set_Lv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PreviewName", _s_set_PreviewName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SuitId", _s_set_SuitId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ColorNeed", _s_set_ColorNeed);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StarNeed", _s_set_StarNeed);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NeedInfos", _s_set_NeedInfos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CostGoodsIdList", _s_set_CostGoodsIdList);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CostGoodsList", _s_set_CostGoodsList);
            
			XUtils.EndObjectRegister(typeof(xc.DBSuit.DBSuitInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBSuit.DBSuitInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBSuit.DBSuitInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBSuit.DBSuitInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBSuit.DBSuitInfo __cl_gen_ret = new xc.DBSuit.DBSuitInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBSuit.DBSuitInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCostGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.List<xc.GoodsItem> __cl_gen_ret = __cl_gen_to_be_invoked.GetCostGoods( pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Lv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PreviewName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.PreviewName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SuitId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SuitId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ColorNeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ColorNeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StarNeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StarNeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NeedInfos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CostGoodsIdList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CostGoodsIdList);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CostGoodsList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CostGoodsList);
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
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Lv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PreviewName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PreviewName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SuitId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SuitId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ColorNeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ColorNeed = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StarNeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StarNeed = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NeedInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NeedInfos = (System.Collections.Generic.List<xc.DBSuit.DBSuitInfo.NeedInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBSuit.DBSuitInfo.NeedInfo>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CostGoodsIdList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CostGoodsIdList = (System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<uint, uint>>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<uint, uint>>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CostGoodsList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit.DBSuitInfo __cl_gen_to_be_invoked = (xc.DBSuit.DBSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CostGoodsList = (System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<xc.GoodsItem>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<xc.GoodsItem>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
