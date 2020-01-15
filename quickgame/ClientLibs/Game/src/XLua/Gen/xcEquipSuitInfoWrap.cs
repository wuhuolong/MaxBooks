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
    public class xcEquipSuitInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.EquipSuitInfo), L, translator, 0, 3, 12, 12);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateAttr", _m_UpdateAttr);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SuitAttrs", _g_get_SuitAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Lv", _g_get_Lv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PreviewName", _g_get_PreviewName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SuitId", _g_get_SuitId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UpgradeNeed", _g_get_UpgradeNeed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CostGoods", _g_get_CostGoods);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ActiveNum", _g_get_ActiveNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RealNum", _g_get_RealNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxNum", _g_get_MaxNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EquipPos", _g_get_EquipPos);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SuitAttrs", _s_set_SuitAttrs);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Lv", _s_set_Lv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PreviewName", _s_set_PreviewName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SuitId", _s_set_SuitId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UpgradeNeed", _s_set_UpgradeNeed);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CostGoods", _s_set_CostGoods);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ActiveNum", _s_set_ActiveNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RealNum", _s_set_RealNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MaxNum", _s_set_MaxNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EquipPos", _s_set_EquipPos);
            
			XUtils.EndObjectRegister(typeof(xc.EquipSuitInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.EquipSuitInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.EquipSuitInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.EquipSuitInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4))
				{
					uint id = LuaAPI.xlua_touint(L, 2);
					uint lv = LuaAPI.xlua_touint(L, 3);
					uint equipPos = LuaAPI.xlua_touint(L, 4);
					
					xc.EquipSuitInfo __cl_gen_ret = new xc.EquipSuitInfo(id, lv, equipPos);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.EquipSuitInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateAttr(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint lv = LuaAPI.xlua_touint(L, 2);
                    uint num = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.UpdateAttr( lv, num );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint lv = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.Update( lv );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SuitAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SuitAttrs);
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
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
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
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
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
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
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
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SuitId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UpgradeNeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UpgradeNeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CostGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CostGoods);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActiveNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ActiveNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RealNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.RealNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MaxNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EquipPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.EquipPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SuitAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SuitAttrs = (System.Collections.Generic.Dictionary<uint, xc.ActorAttribute>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, xc.ActorAttribute>));
            
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
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
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
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
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
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
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
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SuitId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UpgradeNeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UpgradeNeed = (System.Collections.Generic.List<xc.DBSuit.DBSuitInfo.NeedInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBSuit.DBSuitInfo.NeedInfo>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CostGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CostGoods = (System.Collections.Generic.List<xc.Goods>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.Goods>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ActiveNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ActiveNum = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RealNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RealNum = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MaxNum = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EquipPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipSuitInfo __cl_gen_to_be_invoked = (xc.EquipSuitInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EquipPos = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
