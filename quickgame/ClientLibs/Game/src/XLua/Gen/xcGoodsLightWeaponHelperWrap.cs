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
    public class xcGoodsLightWeaponHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GoodsLightWeaponHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.GoodsLightWeaponHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GoodsLightWeaponHelper), L, __CreateInstance, 9, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "AddInstalledSoul", _m_AddInstalledSoul_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBagSortedSouls", _m_GetBagSortedSouls_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SortFunc", _m_SortFunc_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTotalAttrs", _m_GetTotalAttrs_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTotalLv", _m_GetTotalLv_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "HasInstalledSoul", _m_HasInstalledSoul_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstalledSoulByTypeAndIndex", _m_GetInstalledSoulByTypeAndIndex_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTheBestSouls", _m_GetTheBestSouls_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GoodsLightWeaponHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.GoodsLightWeaponHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GoodsLightWeaponHelper __cl_gen_ret = new xc.GoodsLightWeaponHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsLightWeaponHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddInstalledSoul_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsLightWeaponSoul soul = (xc.GoodsLightWeaponSoul)translator.GetObject(L, 1, typeof(xc.GoodsLightWeaponSoul));
                    
                    xc.GoodsLightWeaponHelper.AddInstalledSoul( soul );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagSortedSouls_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.GoodsLightWeaponSoul> __cl_gen_ret = xc.GoodsLightWeaponHelper.GetBagSortedSouls(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SortFunc_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsLightWeaponSoul a = (xc.GoodsLightWeaponSoul)translator.GetObject(L, 1, typeof(xc.GoodsLightWeaponSoul));
                    xc.GoodsLightWeaponSoul b = (xc.GoodsLightWeaponSoul)translator.GetObject(L, 2, typeof(xc.GoodsLightWeaponSoul));
                    
                        int __cl_gen_ret = xc.GoodsLightWeaponHelper.SortFunc( a, b );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTotalAttrs_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint Pos_Type = LuaAPI.xlua_touint(L, 1);
                    
                        xc.ActorAttribute __cl_gen_ret = xc.GoodsLightWeaponHelper.GetTotalAttrs( Pos_Type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTotalLv_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint Pos_Type = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsLightWeaponHelper.GetTotalLv( Pos_Type );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasInstalledSoul_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint Pos_Type = LuaAPI.xlua_touint(L, 1);
                    uint Pos_Index = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = xc.GoodsLightWeaponHelper.HasInstalledSoul( Pos_Type, Pos_Index );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstalledSoulByTypeAndIndex_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint Pos_Type = LuaAPI.xlua_touint(L, 1);
                    uint Pos_Index = LuaAPI.xlua_touint(L, 2);
                    
                        xc.GoodsLightWeaponSoul __cl_gen_ret = xc.GoodsLightWeaponHelper.GetInstalledSoulByTypeAndIndex( Pos_Type, Pos_Index );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTheBestSouls_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.Dictionary<uint, System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>> __cl_gen_ret = xc.GoodsLightWeaponHelper.GetTheBestSouls(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
