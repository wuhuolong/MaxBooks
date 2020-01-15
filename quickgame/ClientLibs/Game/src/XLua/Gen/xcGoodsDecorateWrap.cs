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
    public class xcGoodsDecorateWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GoodsDecorate), L, translator, 0, 4, 22, 4);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateGoodsByTypeId", _m_CreateGoodsByTypeId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshDecorateUp", _m_RefreshDecorateUp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateAttr", _m_UpdateAttr);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clone", _m_Clone);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "can_use", _g_get_can_use);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DbData", _g_get_DbData);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DefaultExtraDesc", _g_get_DefaultExtraDesc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LvStep", _g_get_LvStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxStrengthLv", _g_get_MaxStrengthLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Pos", _g_get_Pos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SwallowedExpValue", _g_get_SwallowedExpValue);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsUnlock", _g_get_IsUnlock);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsWeared", _g_get_IsWeared);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BasicAttrs", _g_get_BasicAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LegendAttrs", _g_get_LegendAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LegendAttrsDefaultScore", _g_get_LegendAttrsDefaultScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BaseScore", _g_get_BaseScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StrengthLv", _g_get_StrengthLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Star", _g_get_Star);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Score", _g_get_Score);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AfterBreakScore", _g_get_AfterBreakScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RawName", _g_get_RawName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NetDecorate", _g_get_NetDecorate);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerStar", _g_get_ServerStar);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerForceScore", _g_get_ServerForceScore);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LegendAttrs", _s_set_LegendAttrs);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NetDecorate", _s_set_NetDecorate);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ServerStar", _s_set_ServerStar);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ServerForceScore", _s_set_ServerForceScore);
            
			XUtils.EndObjectRegister(typeof(xc.GoodsDecorate), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GoodsDecorate), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GoodsDecorate));
			
			
			XUtils.EndClassRegister(typeof(xc.GoodsDecorate), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GoodsDecorate __cl_gen_ret = new xc.GoodsDecorate();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<Net.PkgGoodsInfo>(L, 3))
				{
					uint typeId = LuaAPI.xlua_touint(L, 2);
					Net.PkgGoodsInfo decorate = (Net.PkgGoodsInfo)translator.GetObject(L, 3, typeof(Net.PkgGoodsInfo));
					
					xc.GoodsDecorate __cl_gen_ret = new xc.GoodsDecorate(typeId, decorate);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsDecorate constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateGoodsByTypeId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.CreateGoodsByTypeId( gid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshDecorateUp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RefreshDecorateUp(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateAttr(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 2);
                    Net.PkgGoodsInfo decorate = (Net.PkgGoodsInfo)translator.GetObject(L, 3, typeof(Net.PkgGoodsInfo));
                    
                    __cl_gen_to_be_invoked.UpdateAttr( gid, decorate );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clone(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.GoodsDecorate __cl_gen_ret = __cl_gen_to_be_invoked.Clone(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_can_use(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.can_use);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DbData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DbData);
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
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.DefaultExtraDesc);
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
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LvStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxStrengthLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MaxStrengthLv);
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
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Pos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SwallowedExpValue(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SwallowedExpValue);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsUnlock(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsUnlock);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsWeared(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsWeared);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BasicAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BasicAttrs);
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
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LegendAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LegendAttrsDefaultScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LegendAttrsDefaultScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.BaseScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StrengthLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StrengthLv);
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
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Star);
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
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Score);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AfterBreakScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.AfterBreakScore);
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
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RawName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.RawName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NetDecorate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NetDecorate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerStar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ServerStar);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerForceScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.ServerForceScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LegendAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LegendAttrs = (xc.Equip.EquipAttributes)translator.GetObject(L, 2, typeof(xc.Equip.EquipAttributes));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NetDecorate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NetDecorate = (Net.PkgGoodsInfo)translator.GetObject(L, 2, typeof(Net.PkgGoodsInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ServerStar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ServerStar = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ServerForceScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsDecorate __cl_gen_to_be_invoked = (xc.GoodsDecorate)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ServerForceScore = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
